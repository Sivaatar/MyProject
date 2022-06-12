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
    public class DepartmentController : ControllerBase
    {
        Db dbop = new Db();
        String msg = string.Empty;
        // GET: api/<DepartmentController>////
        [HttpGet]
        public List<Department> readall()
        {
            Department emp = new Department();
            emp.type = "readall";
            DataSet ds = dbop.DepartmentGet(emp, out msg);
            List<Department> list = new List<Department>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Department
                {
                    DepartmentId = Convert.ToInt32(dr["DepartmentId"]),
                    DepartmentName = dr["DepartmentName"].ToString()
                });

            }

            return list;
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public List<Department> Read(int id)
        {

            Department emp = new Department();
            emp.DepartmentId = id;
            emp.type = "Read";
            DataSet ds = dbop.DepartmentGet(emp, out msg);
            List<Department> list = new List<Department>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Department
                {
                    DepartmentId = Convert.ToInt32(dr["DepartmentId"]),
                    DepartmentName = dr["DepartmentName"].ToString(),
                });

            }

            return list;
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public string insert(int Id,string name ,[FromBody] Department emp)
        {
            string msg = string.Empty;
            try
            {
                emp.type = "insert";
                emp.DepartmentId = Id;
                emp.DepartmentName = name;
                msg = dbop.DepartmentOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;

        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        public string update(int Id,string Name,[FromBody] Department emp)
        {
            string msg = string.Empty;
            try
            {
                emp.type = "update";
                emp.DepartmentId = Id;
                emp.DepartmentName = Name;
                msg = dbop.DepartmentOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                Department emp = new Department();
                emp.DepartmentId = id;
                emp.type = "delete";
                msg = dbop.DepartmentOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
