using FlowAuth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class Log
    {
        public Log()
        {
            Log_date = DateTime.Today;
        }
        //ID primary key for log
        public int LogID { get; set; }

        //makes use of the project id
        //public int Project_Code { get; set; }  
        [DisplayName("Project Code")]
        [Required(ErrorMessage = "Please select a project ")]
        public string Project_Code { get; set; }


        [DisplayName("Staff name")]
        [Required(ErrorMessage = "Please select a staff  ")]
        public int StaffID { get; set; }

        //Has a task name
        //Annotation to display the task name
        [DisplayName("Task name")]
        [Required(ErrorMessage = "Please select a task ")]
        public int TaskDescriptionID { get; set; }

        private DateTime log_date = new DateTime();
        //day of log
        //Annotation to display log date
        [DisplayName("Log Date")]
        //Annotation to validate log date
        [DataType(DataType.Date)]
        //sets the data format
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        //[Required]
        public DateTime Log_date { get;set; }

        //Records the log hours
        [DisplayName("Log Hours")]
        [Required(ErrorMessage = "Please enter the hours ")]
        public double Log_hours { get; set; }

        public Project Project { get; set; }
        public Staff Staff { get; set; }
        public TaskDescription TaskDescription { get; set; }
    }
}
