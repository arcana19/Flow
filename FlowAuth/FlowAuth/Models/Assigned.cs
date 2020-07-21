using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class Assigned
    {
        [Key]
        public int AssignedID { get; set; }

        [DisplayName("Staff Full Name")]
        [Required(ErrorMessage = "Please select a Staff member")]
        public int StaffID { get; set; }

        [DisplayName("Project Code")]
        [Required(ErrorMessage = "Please select a Project Code ")]
        public string Project_Code { get; set; }

        //Contains one project and staff
        public Project Project { get; set; }
        public Staff Staff { get; set; }
    }
}
