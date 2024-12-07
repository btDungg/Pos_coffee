using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public interface IPaymentDao
    {
        Task<List<PaymentModel>> GetAllPayment();

        Task<PaymentModel> AddPayment(PaymentModel payment);

        Task<List<CartItemModel>> AddPaymentDetail (List<CartItemModel> cartItems, Guid paymentID);

        Task<List<PaymentDetailModel>> GetPaymentDetailById(Guid paymentID);
    }
}
