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

        public Task<List<CartItemModel>> AddPaymentDetail(List<CartItemModel> cartItems, Guid paymentID)
        {
            throw new NotImplementedException();
        }

        public List<PaymentModel> GetAllPayment()
        {
            var list = new List<PaymentModel>();
            return list;
        }

        Task<PaymentModel> IPaymentDao.AddPayment(PaymentModel payment)
        {
            throw new NotImplementedException();
        }

        Task<List<PaymentModel>> IPaymentDao.GetAllPayment()
        {
            throw new NotImplementedException();
        }

        Task<List<PaymentDetailModel>> IPaymentDao.GetPaymentDetailById(Guid paymentID)
        {
            throw new NotImplementedException();
        }
    }
}
