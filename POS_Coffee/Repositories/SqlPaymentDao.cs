using Microsoft.EntityFrameworkCore;
using POS_Coffee.Data;
using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public class SqlPaymentDao : IPaymentDao
    {
        private readonly PosDbContext _dbContext;
        public SqlPaymentDao(PosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PaymentModel> AddPayment(PaymentModel payment)
        {
            await _dbContext.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<List<CartItemModel>> AddPaymentDetail(List<CartItemModel> cartItems, Guid paymentID)
        {
            foreach (var cartItem in cartItems)
            {
                var detail = new PaymentDetailModel
                {
                    PaymentID = paymentID,
                    FoodId = cartItem.Id,
                    Note = cartItem.Note,
                    Quantity = cartItem.Quantity
                };
                await _dbContext.AddAsync(detail);  
            }
            await _dbContext.SaveChangesAsync();
            return cartItems;
        }

        public async Task<List<PaymentModel>> GetAllPayment()
        {
            var payments = await  _dbContext.Payments.ToListAsync();
            return payments;
        }

        public async Task<List<PaymentDetailModel>> GetPaymentDetailById(Guid paymentID)
        {
            var items = await _dbContext.PaymentDetails.Where(x => x.PaymentID == paymentID).ToListAsync();
            return items;
        }
    }
}
