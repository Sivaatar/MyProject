using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrentProject.model;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Db dbop = new Db();
        String msg = string.Empty;
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> readall()
        {
            Employee emp = new Employee();
            emp.type = "readall";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach  (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    EmployeeEmail = dr["EmployeeEmail"].ToString(),
                    EmployeeDepartmentId = Convert.ToInt32(dr["EmployeeDepartmentId"]),
                });

            }

            return list; 
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public List<Employee> Read(int id)
        {

            Employee emp = new Employee();
            emp.EmployeeId = id;
            emp.type = "Read";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    EmployeeEmail = dr["EmployeeEmail"].ToString(),
                    EmployeeDepartmentId = Convert.ToInt32(dr["EmployeeDepartmentId"]),
                });

            }

            return list;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public string insert(int Id,string name,string email,int D_Id, [FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {
                emp.type = "insert";
                emp.EmployeeId = Id;
                emp.EmployeeName = name;
                emp.EmployeeEmail = email;
                emp.EmployeeDepartmentId = D_Id;
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;

        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public string update(int Id,[FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {
                emp.type = "update";
                emp.EmployeeId = Id;
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                Employee emp = new Employee();
                emp.EmployeeId = id;
                emp.type = "delete";
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
