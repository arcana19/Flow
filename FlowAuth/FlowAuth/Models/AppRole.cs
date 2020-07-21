using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Models
{
    public class AppRole:IdentityRole<int>
    {
        //Three different constructors
        public AppRole() : base() { }

        public AppRole(string roleName) : base(roleName) { }

        public AppRole(string roleName,string description) : base(roleName)
        {
            this.Description = description;
        }

        //The extension to  the identity role class by adding properties
        public string Description { get; set; }
    }
}
