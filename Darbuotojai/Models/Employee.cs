using System;

namespace Darbuotojai.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalIdentification { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public EmployeeState State { get; set; } = EmployeeState.Active;
    }
}
