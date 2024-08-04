using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPICProject.Models;
using WebAPIProject.Test.DataAccessTest.RepositoryTest;

namespace WebAPIProject.Test.DataAccessTest.RepositoryTest
{
    [TestClass]
    public class EmpRepositTest
    {
        [TestMethod]
        public async Task TestInsertEmployee()
        {
            //create object
            Employee emp = new Employee()
            {
                EmpId=10011,
                EName="Surya",
                Password="12345",
                Gender="Male",
                Phone="9876543210",
                Email="surya@gmail.com",
                Salary=10000,
                Address="Hyderabad",
                DeptNo=10
            };


            //Arrange
            //Create Instance

           EmpReposit obj=new EmpReposit();


            //Act
            var ActualRes =await obj.InsertEmployee(emp);

            //Assert
            Assert.AreEqual(1, ActualRes);//1 Record Inserted
            Assert.AreEqual(1, obj.TotalRecords());//Records Available
            Assert.IsNotNull(obj._db);//Not Null;
            Assert.AreEqual(emp.EmpId,(await obj.GetEmpById(emp.EmpId)).EmpId);
        }

        [TestMethod]
        public async Task TestUpdateEmployee()
        {
            //Creat Object for Insert the Records
            Employee emp = new Employee()
            {
                EmpId = 10011,
                EName = "Surya",
                Password = "12345",
                Gender = "Male",
                Phone = "9876543210",
                Email = "surya@gmail.com",
                Salary = 10000,
                Address = "Hyderabad",
                DeptNo = 10
            };

            //Now Update the Records 

            Employee emp1 = new Employee()
            {
                EmpId = 10031,
                EName = "Greeshma",
                Password = "12345",
                Gender = "Female",
                Phone = "9876543210",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Mumbai",
                DeptNo = 20
            };
            //Arrange
            EmpReposit obj = new EmpReposit();
            await obj.InsertEmployee(emp);
            //Act
            var res =await obj.UpdateEmployee(emp1);
            //Assert
            Assert.AreEqual(1, res);
            Assert.AreEqual(1,obj.TotalRecords());
            Assert.IsNotNull(obj._db);
        }

        [TestMethod]
        public async Task TestDeleteEmployee()
        {
            //create object to Insert the Records
            Employee emp1 = new Employee()
            {
                EmpId = 10011,
                EName = "Surya",
                Password = "12345",
                Gender = "Male",
                Phone = "9876543210",
                Email = "surya@gmail.com",
                Salary = 10000,
                Address = "Hyderabad",
                DeptNo = 10
            };
            Employee emp2 = new Employee()
            {
                EmpId = 10031,
                EName = "Greeshma",
                Password = "12345",
                Gender = "Female",
                Phone = "9876543210",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Mumbai",
                DeptNo = 20
            };
            //Arrange
            EmpReposit obj = new EmpReposit();
            await obj.InsertEmployee(emp1);
            await obj.InsertEmployee(emp2);//Inserted 2 Records
            //Act
            var res = await obj.DeleteEmployee(emp1.EmpId);//Here EmpId to Delete one Record by Entering the Id value

            //Assert
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public async Task TestAllEmployees()
        {
            //create object to Insert the Records
            Employee emp1 = new Employee()
            {
                EmpId = 10011,
                EName = "Surya",
                Password = "12345",
                Gender = "Male",
                Phone = "9876543210",
                Email = "surya@gmail.com",
                Salary = 10000,
                Address = "Hyderabad",
                DeptNo = 10
            };
            Employee emp2 = new Employee()
            {
                EmpId = 10031,
                EName = "Greeshma",
                Password = "12345",
                Gender = "Female",
                Phone = "9876543210",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Mumbai",
                DeptNo = 20
            };

            //Arrange
            EmpReposit obj = new EmpReposit();
            await obj.InsertEmployee(emp1);
            await obj.InsertEmployee(emp2);
            //Act
            var res = await obj.AllEmployees();
            //Assert
            Assert.IsNotNull(obj._db);
            Assert.AreEqual(2,res.Count);
        }

        [TestMethod]
        public async Task TestGetEmpByDeptNo()
        {
            Employee emp1 = new Employee()
            {
                EmpId = 10011,
                EName = "Surya",
                Password = "12345",
                Gender = "Male",
                Phone = "9876543210",
                Email = "surya@gmail.com",
                Salary = 10000,
                Address = "Hyderabad",
                DeptNo = 10
            };
            Employee emp2 = new Employee()
            {
                EmpId = 10031,
                EName = "Greeshma",
                Password = "12345",
                Gender = "Female",
                Phone = "9876543210",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Mumbai",
                DeptNo = 20
            };

            EmpReposit obj=new EmpReposit();
            await obj.InsertEmployee(emp1);
            await obj.InsertEmployee(emp2);

            var res = await obj.GetEmpByDeptNo(emp1.DeptNo);

            Assert.IsNotNull(obj._db);
            Assert.AreEqual(2,obj.TotalRecords());
        }

        [TestMethod]
        public async Task TestGetEmpByEmailandPassword()
        {
            Employee emp1 = new Employee()
            {
                EmpId = 10011,
                EName = "Surya",
                Password = "12345",
                Gender = "Male",
                Phone = "9876543210",
                Email = "surya@gmail.com",
                Salary = 10000,
                Address = "Hyderabad",
                DeptNo = 10
            };
            Employee emp2 = new Employee()
            {
                EmpId = 10031,
                EName = "Greeshma",
                Password = "12345",
                Gender = "Female",
                Phone = "9876543210",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Mumbai",
                DeptNo = 20
            };

            EmpReposit obj=new EmpReposit();
           await obj.InsertEmployee(emp1);
            await obj.InsertEmployee(emp2);

            var res = await obj.GetEmpByEmailandPassword(emp1.Email,emp1.Password);

            Assert.IsNotNull(obj._db);
            Assert.AreEqual(2,obj.TotalRecords());
        }

        [TestMethod]

        public async Task TestGetEmpByGender()
        {
            Employee emp1 = new Employee()
            {
                EmpId = 10011,
                EName = "Surya",
                Password = "12345",
                Gender = "Male",
                Phone = "9876543210",
                Email = "surya@gmail.com",
                Salary = 10000,
                Address = "Hyderabad",
                DeptNo = 10
            };
            Employee emp2 = new Employee()
            {
                EmpId = 10031,
                EName = "Greeshma",
                Password = "12345",
                Gender = "Female",
                Phone = "9876543210",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Mumbai",
                DeptNo = 20
            };

            EmpReposit obj = new EmpReposit();
           await obj.InsertEmployee(emp1);
            await obj.InsertEmployee(emp2);

            var res = await obj.GetEmpByGender(emp1.Gender);

            Assert.IsNotNull(obj._db);
            Assert.AreEqual(2,obj.TotalRecords());
        }
    }
}
