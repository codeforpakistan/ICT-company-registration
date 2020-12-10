using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationsOfCompanies.Models
{
    public class registration_mvvm
    {
        public registration_vm registration { get; set; }
        public List<employees_vm> employees_vm { get; set; }
        public List<dev_bpo_vm> dev_bpo_vm { get; set; }
        
    }
}