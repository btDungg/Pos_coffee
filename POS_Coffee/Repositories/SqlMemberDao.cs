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
        public async Task<List<MembersModel>> GetAllMembers()
        {
            try
            {
                var members = await _dbcontext.Members.ToListAsync();
                return members;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching members: {ex.Message}");
                throw new Exception("An error occurred while retrieving the members.", ex);
            }
        }

        public async Task AddMember(MembersModel newMember)
        {
            try
            {
                // Add the new member to the Members table
                await _dbcontext.Members.AddAsync(newMember);

                // Save changes to the database
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding member: {ex.Message}");
                throw new Exception("An error occurred while adding the member.", ex);
            }
        }

        public async Task UpdateMemberPoints(string phoneNumber, int newPoints)
        {
            try
            {
                var member = await _dbcontext.Members
                    .FirstOrDefaultAsync(m => m.phoneNumber == phoneNumber);

                if (member != null)
                {
                    member.point = member.point + newPoints;

                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine($"Member with phone number {phoneNumber} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating member points: {ex.Message}");
                throw new Exception("An error occurred while updating the member points.", ex);
            }
        }



    }
}
