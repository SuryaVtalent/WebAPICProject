using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPICProject.Models;

namespace WebAPICProject.DataAcc.IRepository
{
    public interface IEmpRepo
    {
        public Task<List<Employee>> AllEmployees();
        public Task<Employee>GetEmpById(int EmpId);
        public Task<List<Employee>> GetEmpByGender(string Gender);
        public Task<Employee> GetEmpByEmailandPassword(string Email, string Password);
        public Task<Employee> GetEmpByDeptNo(int DeptNo);
        public Task<int> InsertEmployee(Employee Emp);
        public Task<int> UpdateEmployee(Employee Emp);
        public Task<int> DeleteEmployee(int EmpId);
        public Task<int> DeleteAllEmployee(int EmpId);
    }
}
