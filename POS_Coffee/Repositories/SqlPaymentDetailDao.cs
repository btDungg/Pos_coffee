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
    public class SqlPaymentDetailDao : IPaymentDetailDao
    {
        private readonly PosDbContext _dbContext;
        public SqlPaymentDetailDao(PosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<PaymentDetailModel>> GetAllPaymentDetail()
        {
            var paymentDetails = await _dbContext.PaymentDetails.ToListAsync();
            return paymentDetails;
        }
    }
}
