using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public class MockPaymentDao : IPaymentDao
    {
        public void AddPayment(PaymentModel payment)
        {
            var list = GetAllPayment();
            list.Add(payment);
        }

        public List<PaymentModel> GetAllPayment()
        {
            var list = new List<PaymentModel>();
            return list;
        }
    }
}
