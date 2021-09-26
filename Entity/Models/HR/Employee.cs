using System;

namespace Entity.Models.HR
{
    public class Employee
    {
        public int BusinessEntityID { get; set; }
        public string NationalIDNumber { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
    }
}