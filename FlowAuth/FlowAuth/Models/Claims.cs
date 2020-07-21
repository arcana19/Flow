using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class Claim
    {
        [Key]
        public int ClaimID { get; set; }

        //Claim 
        //Annotation to display claim amount
        [DisplayName("Amount")]
        //Annotation to validate cliam amount
        [Required(ErrorMessage = "Please enter claim amount")]
        public double Claim_amount { get; set; }


        //Cliam Description
        //Annotation to display claim description
        [DisplayName("Description")]
        //Annotation to validate claim description
        [Required(ErrorMessage = "Please enter the description")]
        public String Claim_description { get; set; }

        //Client Name
        //Annotation to display claim status
        [DisplayName("Status")]
        //Annotation to validate claim status
        public String Claim_status { get; set; }

        //Day of claim
        //Annotation to display claim Date
        [DisplayName("Date of claim")]
        //Annotation to validate claim date
        [DataType(DataType.Date)]
        //sets the data format
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Please select the day of claim ")]
        public DateTime Claim_date { get; set; }

        public int StaffID { get; set; }

        public Staff Staff { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [DisplayName("Approver")]
        public AppUser AppUser { get; set; }
    }
}
