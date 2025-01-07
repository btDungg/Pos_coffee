using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Repositories
{
    public interface IAccountDao
    {
        //List<AccountModel>
        //test
        //List<AccountModel> getAllAccount();
        Task<AccountModel> getAccountByUsername(string username);
        Task<List<AccountModel>> getAllEmployee();
        Task<AccountModel> getEmployeeById(int employeeId);
        Task<TimeKeppingModel> AddTimeKepping(TimeKeppingModel timeKepping);
        Task<TimeKeppingModel> GetTimeKeppingModel(int empId, DateOnly workDate);
        Task<AccountModel> AddEmployee (AccountModel employee);
        List<SalaryDTO> GetSalaryByMonth(int month, int year);
        Task<AccountModel> RemoveEmployee(AccountModel employee);
        Task<List<AccountModel>> GetEmployeesByName(string searchQuery);   
        Task<List<TimeKeppingModel>> GetTimeKeppingModelById(int employeeId);   
    }
}
