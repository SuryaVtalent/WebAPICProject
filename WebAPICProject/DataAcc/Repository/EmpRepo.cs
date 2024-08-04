using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICProject.DataAcc.IRepository;
using WebAPICProject.DataAccess;
using WebAPICProject.Models;

namespace WebAPICProject.DataAcc.Repository
{
    public class EmpRepo:IEmpRepo
    {
        public DBContextt EmpRep;

        public EmpRepo(DBContextt _EmpRep)
        {
            EmpRep= _EmpRep;
        }

        public async Task<List<Employee>> AllEmployees()
        {
          return await EmpRep.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmpById(int EmpId)
        {
            return await EmpRep.Employees.FindAsync(EmpId);
        }


        public async Task<Employee> GetEmpByEmailandPassword(string Email, string Password)
        {
          return await EmpRep.Employees.Where(x=>x.Email==Email&& x.Password==Password).SingleOrDefaultAsync();
        }

        public async Task<List<Employee>> GetEmpByGender(string Gender)
        {
          return await  EmpRep.Employees.Where(x=>x.Gender==Gender).ToListAsync();
        }

        public async Task<Employee> GetEmpByDeptNo(int DeptNo)
        {
            return await EmpRep.Employees.Where(x => x.DeptNo == DeptNo).SingleOrDefaultAsync();
        }
        public async Task<int> InsertEmployee(Employee Emp)
        {
           await EmpRep.Employees.AddAsync(Emp);
            return await EmpRep.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(Employee Emp)
        {
            EmpRep.Employees.Update(Emp);
            return await EmpRep.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployee(int EmpId)
        {
            var emp = EmpRep.Employees.Find(EmpId);
            EmpRep.Employees.Remove(emp);
            return await EmpRep.SaveChangesAsync();
        }

        public async Task<int> DeleteAllEmployee(int EmpId)
        {

            EmpRep.Employees.RemoveRange(EmpRep.Employees.ToList());
            return await EmpRep.SaveChangesAsync();
        }
    }
}
