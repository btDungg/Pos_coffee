using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public class MockAccountDao : IAccountDao
    {
        public AccountModel getAccountByUsername(string username)
        {
            var accountModels = getAllAccount();
            var account = accountModels.FirstOrDefault(x => x.username == username);
            if(account == null)
            {
                return null;
            }
            return account;
        }

        private List<AccountModel> getAllAccount()
        {
            var accountModels = new List<AccountModel>()
            {
                new AccountModel()
                {
                    Id = 1,
                    username = "emp1",
                    password = "emp1",
                    role = "employee"
                },
                new AccountModel()
                {
                    Id = 2,
                    username = "emp2",
                    password = "emp2",
                    role = "employee"
                },
                new AccountModel()
                {
                    Id = 3,
                    username = "admin1",
                    password = "admin1",
                    role = "admin"
                }
            };
            return accountModels;
        }
    }
}
