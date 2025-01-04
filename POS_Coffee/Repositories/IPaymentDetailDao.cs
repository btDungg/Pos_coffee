using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public interface IPaymentDetailDao
    {
        Task<List<PaymentDetailModel>> GetAllPaymentDetail();
    }
}
