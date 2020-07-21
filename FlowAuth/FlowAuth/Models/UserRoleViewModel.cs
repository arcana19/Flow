using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class UserRoleViewModel
    {
        
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string Username { get; set; }
        public bool IsSelected { get; set; }

    }
}
