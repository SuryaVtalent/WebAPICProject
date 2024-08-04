using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPICProject.DataAcc.IRepository;
using WebAPICProject.Models;

namespace WebAPICProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpWebAPIController : ControllerBase
    {

        public IEmpRepo EmpRef;

        public EmpWebAPIController(IEmpRepo _EmpRef)
        {
             EmpRef = _EmpRef;
        }

        //This Method is used to Insert the Records

        [HttpPost]
        [Route("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee(Employee Emp)
        {
            try
            {
             var count = await EmpRef.InsertEmployee(Emp);
                if (count>0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are Inserted");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong"+e.Message+"Will resolve soon");
            }
        }

        [HttpGet]
        [Route("AllEmployees")]
        public async Task<IActionResult> AllEmployees()
        {
            try
            {
              var EmpList =await EmpRef.AllEmployees();
                if (EmpList.Count>0)
                {
                    return Ok(EmpList);
                }
                else
                {
                    return BadRequest("Records are not Available");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong"+e.Message+"Will resolve soon");
            }
        }

        [HttpGet]
        [Route("GetEmpById")]
        public async Task<IActionResult> GetEmpById(int EmpId)
        {
            try
            {
                var empid = await EmpRef.GetEmpById(EmpId);
                if (empid!=null)
                {
                    return Ok(empid);
                }
                else
                {
                    return BadRequest("Records are not Available");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

        [HttpGet]
        [Route("GetEmpByGender")]
        public async Task<IActionResult> GetEmpByGender(string Gender)
        {
            try
            {
                var EmpList = await EmpRef.GetEmpByGender(Gender);
                if (EmpList.Count > 0)
                {
                    return Ok(EmpList);
                }
                else
                {
                    return BadRequest("Records are not Available");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

        [HttpGet]
        [Route("GetEmpByEmailandPassword")]
        public async Task<IActionResult> GetEmpByEmailandPassword(string Email, string Password)
        {
            try
            {
                var empid = await EmpRef.GetEmpByEmailandPassword(Email,Password);
                if (empid !=null)
                {
                    return Ok(empid);
                }
                else
                {
                    return BadRequest("Records are not Available");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

        [HttpGet]
        [Route("GetEmpByDeptNo")]
        public async Task<IActionResult> GetEmpByDeptNo(int DeptNo)
        {
            try
            {
                var empid = await EmpRef.GetEmpByDeptNo(DeptNo);
                if (empid != null)
                {
                    return Ok(empid);
                }
                else
                {
                    return BadRequest("Records are not Available");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }


        [HttpDelete]
        [Route("DeleteAllEmployee")]
        public async Task<IActionResult> DeleteAllEmployee(int EmpId)
        {
            try
            {
                var count = await EmpRef.DeleteAllEmployee(EmpId);
                if (count>0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are not Deleted");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee Emp)
        {
            try
            {
                var count = await EmpRef.UpdateEmployee(Emp);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are Updated");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {
            try
            {
                var count = await EmpRef.DeleteEmployee(EmpId);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are Deleted");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }
    }
}
