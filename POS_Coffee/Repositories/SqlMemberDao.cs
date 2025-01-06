using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Coffee.Data;
using POS_Coffee.Models;

namespace POS_Coffee.Repositories
{
    internal class SqlMemberDao:IMembersDao
    {
        private readonly PosDbContext _dbcontext;
        public SqlMemberDao(PosDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<MembersModel> getMember(string phoneNumber)
        {
            try
            {
                return await _dbcontext.Members
                    .FirstOrDefaultAsync(m => m.phoneNumber == phoneNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching member: {ex.Message}");
                throw new Exception("An error occurred while retrieving the member.", ex);
            }
        }
    }
}
