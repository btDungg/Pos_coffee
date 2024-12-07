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
    public class SqlAccountDao : IAccountDao
    {
        private readonly PosDbContext _dbcontext;
        public SqlAccountDao(PosDbContext context)
        {
            _dbcontext = context;
        }
        public async Task<AccountModel> getAccountByUsername(string username)
        {
            var account =await _dbcontext.Accounts.FirstOrDefaultAsync(x => x.username == username);
            if (account == null)
            {
                return null;
            }
            return account;
        }
    }
}
