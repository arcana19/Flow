using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class Staff
    {
        //Primary key for each staff member
        [Key]
        [DisplayName("Staff ID")]
        public int StaffID { get; set; }

        //can be 3 values which are admin,management and staff)
        [DisplayName("Type")]
        //annotation to validate staff type
        [Required(ErrorMessage = "Please select a type")]
        public string Staff_type { get; set; }

        //Annotation to display staff first name
        [DisplayName("Full Name")]
        //Annotation to validate  inputed
        [Required(ErrorMessage = "Please enter your full name")]
        public string Staff_fullName { get; set; }

        //Position of staff member
        [DisplayName("Position")]
        //Annotation to validate staff position
        [Required(ErrorMessage = "Please enter the position of new staff")]
        public string Staff_position { get; set; }


        //This is the nature of employment
        [DisplayName("Nature of Employment")]
        //Annotation to validate nature of employment
        [Required(ErrorMessage = "Please select the nature of employemnet")]
        public string Staff_emp_nature { get; set; }


        //Residential address
        [DisplayName("Residential address")]
        //Annotation to validate staff residence address
        [Required(ErrorMessage = "Please enter the residential address")]
        public string Staff_res_addr { get; set; }

        //Cellphone numbers
        [DisplayName("Staff cellphone")]
        //Annotation to validate cellphone number
        [Required(ErrorMessage = "Please enter your cellphone number")]
        public int Staff_cellphone { get; set; }

        //Private Emial
        [DisplayName("Email address")]
        [EmailAddress]
        //Annotation to validate email address
        [Required(ErrorMessage = "Please enter a valid email address")]             //need to validate emails
        public string Staff_email { get; set; }

        //Date of birth
        [DisplayName("Date of birth")]
        //Employing the use of date functionality
        [DataType(DataType.Date)]
        //sets the data format
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        //Annotation to validate date selection
        [Required(ErrorMessage = "Please select a your date of birth")]
        public DateTime Staff_DOB { get; set; }


        //country of origin
        [DisplayName("Country of birth")]
        //Annotation to validate country of birth
        [Required(ErrorMessage = "Please select a country")]
        public string Staff_country { get; set; }

        //Staff ID number
        [DisplayName("Id number")]
        //Annotation to validate id number
        public long? Staff_idNum { get; set; }

        //Staff ID number
        [DisplayName("Passport number")]
        //Annotation to validate id number
        public long? Staff_passport { get; set; }

        //Staff income tax no.
        [DisplayName("Income tax no.")]
        //10 digits
        public long? Staff_incomeTax { get; set; }

        //medical aid
        [DisplayName("Medical aid name")]
        //Annotation to validate staff medical aid
        [Required(ErrorMessage = "Please select a medical aid")]
        public string Staff_medicalAid { get; set; }                            //Split to medical Aid name 

        //medical aid
        [DisplayName("Medical aid #")]
        //Annotation to validate staff medical aid
        [Required(ErrorMessage = "Please select a medical aid")]
        public long Staff_medicalAidNo { get; set; }                            //Split to medical Aid number

        //Next of kin name
        [DisplayName("Next of kin's name")]
        //Annotation to validate next of kin name
        [Required(ErrorMessage = "Please enter your next of kin's name")]
        public string Staff_nextKin_name { get; set; }

        //Next of kin cellphone number
        [DisplayName("Next of kin's cellphone")]
        //Annotation to validate next of kin's number
        [Required(ErrorMessage = "Please enter a your next of kin's cellphone number")]
        public int Staff_nextKin_cellphone { get; set; }


        //Staff rate and it's calculated by
        [DisplayName("Staff Rate")]
        [Required(ErrorMessage ="Please enter the staff's rate")]
        public double Staff_rate { get; set; }

        //Staff leave days remaining
        [Required]
        [DisplayName("Leave days remaining")]
        public double Staff_leaveDays { get; set; }

        //The last day of employment
        [DisplayName("Last day of employment")]
        //Annotation to set the date format
        [DataType(DataType.Date)]
        //sets the data format
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Staff_lastDay { get; set; }

        public AppUser AppUser { get; set; }

        //Contains many of the following{
        [JsonIgnore]
        public ICollection<Log> Logs { get; set; }
        [JsonIgnore]
        public ICollection<Assigned> Assigneds { get; set; }
        [JsonIgnore]
        public ICollection<Leave> Leaves { get; set; }
        [JsonIgnore]
        public ICollection<Claim> Claims { get; set; }

        public static implicit operator Staff(SelectList v)
        {
            throw new NotImplementedException();
        }
    }
}
