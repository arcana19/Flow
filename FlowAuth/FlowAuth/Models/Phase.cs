using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class Phase
    {
        [Key]
        public int PhaseID { get; set; }

        [DisplayName("Phase")]
        //Annotation to validate phase name
        [Required(ErrorMessage ="Please select a phase")]
        public int PhaseNameID { get; set; }

        [DisplayName("Project_Code")]
        //Annotation to validate phase name
        [Required(ErrorMessage = "Please select Project_Code")]
        public string Project_Code { get; set; }


        [DisplayName("Start Date")]
        //Annotation to validate project start date
        [DataType(DataType.Date)]
        //sets the data format
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Please select a start date ")]
        public DateTime Phase_startDate { get; set; }

        [DisplayName("Due Date")]
        //Annotation to validate project due date
        [DataType(DataType.Date)]
        //sets the data format
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Please select an end date ")]
        public DateTime Phase_endDate { get; set; }
        

        [DisplayName("Budget")]
        //Annotation to validate budget
        [Required(ErrorMessage ="Please specify budget")]
        public double Phase_budget { get; set; }

        public PhaseName PhaseName { get; set; }
        public Project Project { get; set; } 
   
    }
}
