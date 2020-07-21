using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class PhaseName
    {

        [Key]
        //This is where the tasts will be addded
        public int PhaseNameID { get; set; }


        //Annotation to display phase name
        [DisplayName("Phase Name")]
        [Required(ErrorMessage = "Please enter a phase name")]
        public string Phase_name { get; set; }

        //has multiple phases
        public ICollection<Phase> Phases { get; set; }
    }
}

