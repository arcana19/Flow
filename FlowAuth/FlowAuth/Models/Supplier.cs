using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class Supplier
    {
        //ID of supplier

        public int SupplierID { get; set; }

        //Supplier name
        //Annotation to display supplier name
        [DisplayName("Name")]
        //Annotation to validate name
        [Required(ErrorMessage = "Please enter the supplier name")]
        public string Supplier_name { get; set; }

        //Supplier services
        //Annotation to display supplier services
        [DisplayName("Services")]
        //Annotattion to validate supplier services
        [Required(ErrorMessage = "Please enter the supplier services")]
        public string Supplier_services { get; set; }

        //Supplier registration number
        //Annotation to display supplier registration number
        [DisplayName(" Registration Number")]
        //Annotation to validate to supplier registration number
        [Required(ErrorMessage = "The supplier's registration number is required")]
        public string Supplier_reg_no { get; set; }

        //Supplier banking details
        //Annotation to display supplier's banking details
        [DisplayName("Bank Name")]
        //Annotation to validate banking details entry
        [Required(ErrorMessage = "Name of bank is required")]
        public string Supplier_bank_name { get; set; }

        //Account number
        //Annotation to display supplier's banking details
        [DisplayName("Account Number")]
        //Annotation to validate banking details entry
        [Required(ErrorMessage = "Account number is required")]
        public string Supplier_bank_accNumber { get; set; }

        //Account type
        //Annotation to display supplier's banking details
        [DisplayName("Account Type")]
        //Annotation to validate banking details entry
        [Required(ErrorMessage = "Account type is required")]
        public string Supplier_bank_accType { get; set; }

        //Account type
        //Annotation to display supplier's banking details
        [DisplayName("Bank Branch")]
        //Annotation to validate banking details entry
        [Required(ErrorMessage = "Bank branch is required")]
        public string Supplier_bank_branch { get; set; }

        //Supplier VAT number
        //Annotation to display supplier's vat number
        [DisplayName("VAT Number")]
        //Annotation to validate VAT number entry
        public double Supplier_vatNo { get; set; }

        //Supplier address
        //Annotation to display supplier address
        [DisplayName("Address")]
        //Annotation to validate supplier address entry
        [Required(ErrorMessage = "Supplier address is required")]
        public string Supplier_address { get; set; }

        //Supplier contact name
        //Annotation to display supplier contact
        [DisplayName("Name of contact")]
        //Annotation to validate contact name
        [Required(ErrorMessage = "Please enter a contact name")]
        public string Supplier_contactName { get; set; }

        //Suppier contact number
        //Annotation to display supplier contact number
        [DisplayName("Contact Number")]
        //Annotation to validate supplier contact number
        [Required(ErrorMessage = "Please enter supplier's contact number")]
        public int Supplier_contactNo { get; set; }

        //Suppliers can have multiple projects
        //public virtual ICollection<ManageSupplier> manageSuppliers { get; set; }
        public ICollection<SuppliedBy> SuppliedBys { get; set; }
    }
}
