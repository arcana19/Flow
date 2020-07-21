using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class Client
    { //Properties of the client
        [Key]
        //ID is the primary key for each client
        public int ClientID { get; set; }

        //Client Name
        //Annotation to display client name
        [DisplayName("Company/Client Name")]
        //Annotation to validate client name
        [Required(ErrorMessage = "Please enter the client name")]
        public string Client_name { get; set; }

        //Client service
        //Annotation to display the client service
        [DisplayName("Client service/occupation")]
        //Annotation to validate client service
        [Required(ErrorMessage = "Please enter the client's service")]
        public string Client_service { get; set; }

        //Company registration
        //Annotation to display the company registration
        [DisplayName("Company Registration number")]
        //Annotation to validate client id number
        public string Company_regNo { get; set; }

        //Client work address
        //Annotation to display the client's work address
        [DisplayName("Company/Client work address")]
        public string Client_work_address { get; set; }

        //Client work number
        //Annotation to display the client's work number
        [DisplayName("Comapny/Client work number")]
        //Annotation to validate work number
        [Required(ErrorMessage = "Please enter the client's work number")]
        public int Client_workNo { get; set; }


        //Client Date Of Birth
        //Annotation to display the client date of birth
        [DisplayName("Client Date Of Birth")]
        //Employing the use of a DateTime Picker
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Client_DOB { get; set; }

        //Client ID Number
        //Annotation to display the client's identification number
        [DisplayName("South African ID Number")]
        //Annotation to validate client id number
        [Required(ErrorMessage = "Please enter the client's ID number")]
        public long Client_id_no { get; set; }


        //Company-Client contact person's detail

        //Client residential address
        //Annotation to display the clients residential address
        [DisplayName("Contact Name")]
        //Annotation to validate client residential address
        [Required(ErrorMessage = "Please enter the client's residential address")]
        public string Client_contactName { get; set; }


        //Client residential address
        //Annotation to display the clients residential address
        [DisplayName("Contact email ")]
        //Annotation to validate client residential address
        [Required(ErrorMessage = "Please enter the client's residential address")]
        public string Client_contactEmail { get; set; }


        //Client work number
        //Annotation to display the client's work number
        [DisplayName("Client contact number")]
        //Annotation to validate work number
        [Required(ErrorMessage = "Please enter the client's work number")]
        public long Client_contactNo { get; set; }

        //Client Account Status
        //Annotation to display client's account status
        [DisplayName("Account Status")]
        //Annotation to validate account status
        [Required(ErrorMessage = "Please specify account status")]
        public string Account_status { get; set; }

        //Each client can have 0 to many projects

        //Clients can have multiples of the following
        public ICollection<Project> Projects { get; set; }

    }
}
