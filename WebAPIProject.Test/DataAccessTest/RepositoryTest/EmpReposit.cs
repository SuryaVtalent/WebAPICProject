using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPICProject.DataAcc.IRepository;
using WebAPICProject.Models;

namespace WebAPIProject.Test.DataAccessTest.RepositoryTest
{
    internal class EmpReposit : IEmpRepo
    {
        //Create Mock Functionality to not effect the Main Database for testing
        //Create Object instance Like DB Context in EmpRepository

        public List<Employee> _db=new List<Employee>();//This is for All List of Employees

        public Task<List<Employee>> AllEmployees()
        {
            return Task.FromResult(_db);
        }

        public Task<int> DeleteAllEmployee()
        {
            var Trec = TotalRecords();
            _db.Clear();
            return Task.FromResult(Trec);
        }

        public Task<int> DeleteEmployee(int EmpId)
        {
            Employee emp = null;   //Default it will be Null 

            foreach (Employee e in _db)
            {
                if (e.EmpId == EmpId)
                {
                    emp = e; break;
                }
            }
            _db.Remove(emp);
            return Task.FromResult(SaveChanges());

        }

        public Task<Employee> GetEmpByDeptNo(int DeptNo)
        {
            Employee emp = null;

            foreach (Employee e in _db)
            {
                if (e.DeptNo == DeptNo)
                {
                    emp = e;
                    break;
                }
            }
            return Task.FromResult(emp);
        }

        public Task<Employee> GetEmpByEmailandPassword(string Email, string Password)
        {
            Employee emp = null;
            foreach (Employee e in _db)
            {
                if (e.Email==Email && e.Password==Password)
                {
                    emp = e;break;
                }
            }
            return Task.FromResult(emp);
        }

        public Task<List<Employee>> GetEmpByGender(string Gender)
        {
            List<Employee> Lemp = new List<Employee>();

            foreach (Employee e in _db)
            {
                if (e.Gender==Gender)
                {
                    Lemp.Add(e);
                }
            }
            return Task.FromResult(Lemp);
        }

        public Task<Employee> GetEmpById(int EmpId)
        {
            Employee emp = null;
            foreach (Employee e in _db)
            {
                if (e.EmpId == EmpId)
                {
                    emp = e; break;
                }
            }
            return Task.FromResult(emp);
        }

        public Task<int> InsertEmployee(Employee Emp)
        {
            _db.Add(Emp);
            return Task.FromResult(SaveChanges());
        }

        public Task<int> UpdateEmployee(Employee Emp)
        {
            foreach (Employee e in _db )
            {
                if (e.EmpId==Emp.EmpId)
                {
                    e.EName = Emp.EName; e.Email = Emp.Email; e.Salary = Emp.Salary; e.Address = Emp.Address;
                    e.Phone = Emp.Phone; e.Password = Emp.Password; e.Gender = Emp.Gender; e.DeptNo = Emp.DeptNo;

                    break;
                }
            }
            return Task.FromResult(SaveChanges());
        }

        //This method is used to return the value of integer
        //Savechanges method is not available in Test Mocking so we created to Save the Count

        public int SaveChanges()
        {
            return 1;
        }

        //This method is used for try to Return List of Records
        public int TotalRecords()
        {
            return _db.Count;
        }

        public Task<int> DeleteAllEmployee(int EmpId)
        {
            throw new NotImplementedException();
        }
    }
}
