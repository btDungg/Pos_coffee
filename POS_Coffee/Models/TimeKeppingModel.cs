using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Models
{
    public class TimeKeppingModel
    {
        public int EmployeeID { get; set; }
        public double Hours { get; set; }
        public DateOnly WorkDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public AccountModel Employee {  get; set; }
    }
}
