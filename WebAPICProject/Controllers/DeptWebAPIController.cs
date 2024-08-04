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
    public class DeptWebAPIController : ControllerBase
    {

        public IDeptRepo DeptRef;

        public DeptWebAPIController(IDeptRepo _DeptRef)
        {
            DeptRef= _DeptRef;
        }

        [HttpPost]
        [Route("InsertDepartment")]
        public async Task<IActionResult> InsertDepartment(Department Dept)
        {
            try
            {
                var count = await  DeptRef.InsertDepartment(Dept);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are Not Inserted");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went Wrong"+e.Message+"Will resolve Soon");
            }
        }

        [HttpGet]
        [Route("AllDepartment")]
        public async Task<IActionResult> AllDepartment()
        {
            try
            {
             var DeptList = await DeptRef.AllDepartment();
                if (DeptList.Count>0)
                {
                    return Ok(DeptList);
                }
                else
                {
                    return BadRequest("Records Not found");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong"+e.Message+"Will resolve Soon");
            }
        }

        [HttpGet]
        [Route("GetDeptById")]
        public async Task<IActionResult> GetDeptById(int DeptNo)
        {
            try
            {
                var Deptid = await DeptRef.GetDeptById(DeptNo);
                if (Deptid !=null)
                {
                    return Ok(Deptid);
                }
                else
                {
                    return BadRequest("Records Not found");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve Soon");
            }
        }

        [HttpGet]
        [Route("GetDeptByLocation")]
        public async Task<IActionResult> GetDeptByLocation(string Location)
        {
            try
            {
                var DeptList = await DeptRef.GetDeptByLocation(Location);
                if (DeptList.Count > 0)
                {
                    return Ok(DeptList);
                }
                else
                {
                    return BadRequest("Records Not found");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve Soon");
            }
        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(Department Dept)
        {
            try
            {
              var count= await DeptRef.UpdateDepartment(Dept);
                if (count>0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are updated");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went Wrong"+e.Message+"Will resolve soon");
            }
        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int DeptNo)
        {
            try
            {
                var count = await DeptRef.DeleteDepartment(DeptNo);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are Not Deleted");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went Wrong" + e.Message + "Will resolve Soon");
            }
        }

    }
}
