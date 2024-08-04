using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPICProject.Models;

namespace WebAPICProject.DataAcc.IRepository
{
    public interface IDeptRepo
    {
        public Task<List<Department>> AllDepartment();
        public Task<Department> GetDeptById(int DeptNo);
        public Task<List<Department>> GetDeptByLocation(string Location);

        public Task<int> InsertDepartment(Department Dept);
        public Task<int> UpdateDepartment(Department Dept);
        public Task<int> DeleteDepartment(int DeptNo);
    }
}
