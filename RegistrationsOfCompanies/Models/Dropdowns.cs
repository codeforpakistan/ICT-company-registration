using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationsOfCompanies.Models
{
    public class Dropdowns
    {
        public static List<SelectListItem> Company
        {
            get
            {
                List<SelectListItem> _lst = new List<SelectListItem>() {
                    new SelectListItem(){Value="1",Text="Company"}
                   ,new SelectListItem(){ Value="2",Text="Individual/Freelancer"}
                };
                return _lst;
            }
        }

        public static List<SelectListItem> RegistrationWith
        {
            get
            {
                List<SelectListItem> _lst = new List<SelectListItem>()
                {
                     new SelectListItem(){Value="SECP",Text="SECP"}
                    ,new SelectListItem(){Value="Registrar of Firms",Text="Registrar of Firms"}
                    ,new SelectListItem(){Value="Both",Text="Both"}
                    ,new SelectListItem(){Value="None",Text="None"}
                };
                return _lst;
            }
        }
        public static List<SelectListItem> RegistrationWithPseb
        {
            get
            {
                List<SelectListItem> _lst = new List<SelectListItem>()
                {
                     new SelectListItem(){Value="Yes",Text="Yes"}
                    ,new SelectListItem(){Value="No",Text="No"}
                   
                };
                return _lst;
            }
        }
    }

}