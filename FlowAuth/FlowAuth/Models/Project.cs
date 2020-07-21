using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class Project
    {// properties of a Project

        //Project Code
        //Defining project code as a primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //Annotation to display project code
        [DisplayName("Project Code")]
        //Annotation to validate project code
        [Required(ErrorMessage = "Please enter the project code")]
        public string Project_Code { get; set; }

        [DisplayName("Description")]
        //Annotation to validate the nature of the project
        [Required(ErrorMessage = "Please enter the project description")]
        public string Project_description { get; set; }

        //Project location
        //Annotation to display the project location
        [DisplayName("Site Location")]
        //Annotation to validate project location
        [Required(ErrorMessage = "Please enter the project location")]
        public string Project_location { get; set; }

        //Nature of project
        //Annotation to display project nature
        [DisplayName("Nature Of Project")]
        //Annotation to validate the nature of the project
        [Required(ErrorMessage = "Please state the nature of the project")]
        public string Project_nature { get; set; }

        //Start date of project
        //Annotation to display project start date
        [DisplayName("Start Date")]
        //Annotation to validate project start date
        [DataType(DataType.Date)]
        //sets the data format
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Please select a start date ")]
        public DateTime Project_startDate { get; set; }


        //project due date
        //Annotation to display project due date
        [DisplayName("Due Date")]
        //Annotation to validate project due date
        [DataType(DataType.Date)]
        //sets the data format
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Please select an due date ")]
        public DateTime Project_dueDate { get; set; }

        //end of project
        //Annotation to display project end date
        //Annotation to validate project end date
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Project_endDate { get; set; }                   //only management can enter the project end date

        //Budget of project
        //Annotation to display project budget
        [DisplayName("Budget Allocated")]
        //Annotation to validate project budget
        [Required(ErrorMessage = "Please enter project budget")]
        public double Project_budget { get; set; }

        //Status of project
        //Annotation to display project status
        [DisplayName("Status")]
        //Annotation to validate project status
        [Required(ErrorMessage = "Please enter project status")]
        public string Project_status { get; set; }

        //ID of each client
        //Annotation to display the client id
        [DisplayName("Client name")]
        [Required(ErrorMessage = "Please select a client ")]
        public int ClientID { get; set; }

        //Has one
        public Client Client { get; set; }

        //Has many
        public ICollection<Log> Logs { get; set; }
        public ICollection<Assigned> Assigneds { get; set; }  
        public ICollection<SuppliedBy> SuppliedBys { get; set; }
        public ICollection<Phase> Phases { get; set; }

    }
}
