using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FlowAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using FlowAuth.Data;
using FlowAuth.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlowAuth.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            //Add the things you added in appUser

            [Required(ErrorMessage ="Please enter your full name")]
            [DataType(DataType.Text)]
            [StringLength(50,ErrorMessage ="The ")]
            [Display(Name = "Full Name")]
            public string FullName { get; set; }

        }

        public void OnGet(string returnUrl = null)
        {
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName");
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                //the new security feature...helps in using the email to check if that staff member has a profile setup

                int staff_id = 0;
                Staff acc = new Staff();

                var staff = from s in _context.Staffs select s;

                if (!String.IsNullOrEmpty(Input.Email))
                {
                    staff = staff.Where(s => s.Staff_email.Contains(Input.Email));
                    foreach (Staff s in staff)
                    {
                        acc = s;
                    }

                    staff_id = acc.StaffID;
                }

                try
                {
                    var user = new AppUser
                    {
                        Email = Input.Email,
                        UserName = Input.Email,
                        FullName = Input.FullName,
                        StaffID = staff_id,
                        //LastName = Input.LastName,
                        // Cellphone = Input.Cellphone,

                    };

                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { userId = user.Id, code = code },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                catch (Exception err)
                {
                    //The email inputed doesn't appear in  the list
                    ViewData["Message"] = "Set up your staff profile";
                }
            }   
            //ViewBag.Message = "";
            //ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName");

            

            // If we got this far, something failed, redisplay form
            return Page();
        }



    }
}
