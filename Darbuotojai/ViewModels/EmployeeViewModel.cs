using System;
using System.ComponentModel.DataAnnotations;

namespace Darbuotojai.ViewModels
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Personal Identification")]
        public string PersonalIdentification { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
