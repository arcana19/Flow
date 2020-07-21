using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class TaskDescription
    {
        [Key]
        //This is where the tasks will be addded
        public int TaskDescriptionID { get; set; }


        //Annotation to display task name
        [DisplayName("Name")]
        [Required(ErrorMessage = "Please enter a task name")]
        public string Task_name { get; set; }

        //has multiple logs
        public ICollection<Log> Logs { get; set; }
    }
}
