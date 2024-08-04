using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICProject.DataAcc.IRepository;
using WebAPICProject.DataAccess;
using WebAPICProject.Models;

namespace WebAPICProject.DataAcc.Repository
{
    public class DeptRepo:IDeptRepo

    {
        public DBContextt DeptRep;

        public DeptRepo(DBContextt _DeptRep)
        {
            DeptRep = _DeptRep;
        }

        public async Task<List<Department>> AllDepartment()
        {
          return await DeptRep.Departments.ToListAsync();
        }

        public async Task<Department> GetDeptById(int DeptNo)
        {
          return await DeptRep.Departments.FindAsync(DeptNo);
        }

        public async Task<List<Department>> GetDeptByLocation(string Location)
        {
          return await DeptRep.Departments.Where(x=>x.Location==Location).ToListAsync();
        }

        public async Task<int> InsertDepartment(Department Dept)
        {
           await DeptRep.Departments.AddAsync(Dept);
            return await DeptRep.SaveChangesAsync();

        }

        public async Task<int> UpdateDepartment(Department Dept)
        {
            DeptRep.Departments.Update(Dept);
            return await DeptRep.SaveChangesAsync();
        }

        public async Task<int> DeleteDepartment(int DeptNo)
        {
            var dept = DeptRep.Departments.Find(DeptNo);
            DeptRep.Departments.Remove(dept);
            return await DeptRep.SaveChangesAsync();
        }
    }
}
