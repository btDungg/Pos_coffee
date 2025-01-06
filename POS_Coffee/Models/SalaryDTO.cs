using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Models
{
    public class SalaryDTO
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public float TotalHours { get; set; }
        public decimal TotalSalary { get; set; }
    }
}
