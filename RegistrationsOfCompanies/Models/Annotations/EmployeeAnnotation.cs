using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationsOfCompanies.Models
{
    [MetadataType(typeof(EmployeeAnnotation))]
    public partial class Employee
    {

    }
    public class EmployeeAnnotation
    {
        [Required(ErrorMessage = "Field is required")]
        public int designation_id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public Nullable<decimal> number_of_resources { get; set; }
    }
}