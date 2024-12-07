using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Models
{
    public class PaymentDetailModel
    {
        public Guid PaymentID { get; set; }
        public int FoodId { get; set; }
        public string Note { get; set; }
        public int Quantity { get; set; }
    }
}
