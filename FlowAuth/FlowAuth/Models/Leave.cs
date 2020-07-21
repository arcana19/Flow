using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public enum LeaveType
    {
        [Description("Annaul")] Annual,
        [Description("Maternity")] Maternity,
        [Description("Medical")] Medical,
        [Description("Study")] Study,
        [Description("Other")] Other
    }


    public class Leave
    {
        [Key]
        public int LeaveID { get; set; }


        [DisplayName("Type of Leave")]
        [Required(ErrorMessage = "Please select a leave type")]
        public LeaveType Leave_type { get; set; }


        //Validation of leave type
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Leave_type == LeaveType.Other && Leave_motivation == "")
                yield return new ValidationResult("Please add a motivation/comment for leave taken");
        }

        //Annotation to diplay the leave days taken
        [DisplayName("Days Taken")]
        public int Leave_days_taken
        {
            get
            {
                return (Leave_endDate - Leave_startDate).Days;

            }
            set
            {
                value = (Leave_endDate - Leave_startDate).Days;
            }
        }


        //Start date of leave
        //Annotation to display leave start date
        [DisplayName("Start Date")]
        //Annotation to validate leave start date
        [DataType(DataType.Date)]
        //sets the data format
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Please select a start date ")]
        public DateTime Leave_startDate { get; set; }

        //end date of leave
        [DisplayName("End Date")]
        //Annotation to validate leave end date
        [DataType(DataType.Date)]
        //sets the data format
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Please select an end date ")]
        public DateTime Leave_endDate { get; set; }


        //Annotation for leave motivation
        [DisplayName("Comments/Motivation for Leave")]
        public String Leave_motivation { get; set; }

        //Annotation for the leave status
        [DisplayName("Leave Status")]
        [DefaultValue("Pending")]
        public String Leave_status { get; set; }

        
        public int StaffID { get; set; }

        public Staff Staff { get; set; }


        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [DisplayName("Approver")]
        public AppUser AppUser { get; set; }


    }
}
