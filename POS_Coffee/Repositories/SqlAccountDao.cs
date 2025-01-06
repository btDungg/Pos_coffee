using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS_Coffee.Data;
using POS_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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

        public async Task<AccountModel> AddEmployee(AccountModel employee)
        {
            await _dbcontext.AddAsync(employee);
            await _dbcontext.SaveChangesAsync();
            return employee;
        }

        public async Task<TimeKeppingModel> AddTimeKepping(TimeKeppingModel timeKepping)
        {
            await _dbcontext.AddAsync(timeKepping);
            await _dbcontext.SaveChangesAsync();
            return timeKepping;
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

        public async Task<List<AccountModel>> getAllEmployee()
        {
            var accounts = _dbcontext.Accounts.AsQueryable();
            var employees = await  accounts.Where(a => a.role == "employee").ToListAsync();
            return employees;
        }

        public async Task<AccountModel> getEmployeeById(int employeeId)
        {
            var employee = await _dbcontext.Accounts.FirstOrDefaultAsync(x => x.Id == employeeId);
            if (employee == null)
            {
                return null;
            }
            return employee;
        }

        public List<SalaryDTO> GetSalaryByMonth(int month, int year)
        {
            var result = new List<SalaryDTO>();
            using (var connection = new SqlConnection("Server=localhost;Database=PosCoffeeDb;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                connection.Open();
                using (var command = new SqlCommand("Get_SalaryByMonth", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var salary = new SalaryDTO
                            {
                                EmpID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                Phone = reader.GetString(reader.GetOrdinal("phone")),
                                TotalSalary = (decimal)reader.GetDouble(reader.GetOrdinal("TotalSalary")),
                                TotalHours = (float)reader.GetDouble(reader.GetOrdinal("TotalHours")),
                            };
                            result.Add(salary);
                        }
                    }
                }
            }
            return result;
        }
        public async Task<TimeKeppingModel> GetTimeKeppingModel(int empId, DateOnly workDate)
        {
            var timeKeeping = await _dbcontext.TimeKeppingModels.FirstOrDefaultAsync(x => x.EmployeeID == empId && x.WorkDate == workDate);
            if (timeKeeping == null)
            {
                return null;
            }
            return timeKeeping;
        }
    }
}
