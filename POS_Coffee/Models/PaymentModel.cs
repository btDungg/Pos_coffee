using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Models
{
    public class PaymentModel
    {
        public Guid Id { get; set; }
        public List<CartItemModel> CartItems { get; set; }
        public float Discount {  get; set; }
        public decimal TotalPrice { get; set; }
        public decimal AmountReceived { get; set; }
        public decimal PriceAfterDiscount {  get; set; }
        public decimal Change {  get; set; }
        public string PaymetMethod { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
