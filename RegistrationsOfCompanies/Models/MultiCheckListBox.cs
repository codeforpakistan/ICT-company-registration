using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationsOfCompanies.Models
{
    public class MultiCheckListBox
    {
        public int ID { get; set; }
        public string DisplayLabel { get; set; }
        public bool Checked { get; set; }
        public string checkboxOnClick { get; set; }  // for javascript Event
    }
}