using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class SuppliedBy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SuppliedByID { get; set; }

        [DisplayName("Supplier ID")]
        [Required(ErrorMessage = "Please select a supplier ")]
        public int SupplierID { get; set; }

        [DisplayName("Project Code")]
        [Required(ErrorMessage = "Please select the Project code ")]
        public string Project_Code { get; set; }

        //Contains multiple suppliers and projects
        public Supplier Supplier { get; set; }
        public Project Project { get; set; }
    }
}
