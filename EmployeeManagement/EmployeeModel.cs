using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string Status { get; set; }
    }
}
