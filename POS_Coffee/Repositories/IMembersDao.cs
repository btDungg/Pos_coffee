using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public interface IMembersDao
    {
        Task<MembersModel> getMember(string phoneNumber);
        Task<List<MembersModel>> GetAllMembers();
        Task AddMember(MembersModel newMember);
        Task UpdateMemberPoints(string phoneNumber, int newPoints);
    }
}
