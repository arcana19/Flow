using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class AppUser:IdentityUser<int>
    {
        public AppUser() : base() { }

        public override string Email { get => base.Email; set => base.Email = value; }
        public string FullName { get; set; }
        //public string LastName { get; set; }

        [Required(ErrorMessage ="Enter your staff number provided by admin")]
        public int StaffID { get; set; }
        [ForeignKey("StaffID")]
        public Staff Staff { get; set; }

        //with many
        public ICollection<Claim> Claims { get; set; }
        public ICollection<Leave> Leaves { get; set; }
    }
}
