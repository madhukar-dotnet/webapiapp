using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    public class EmployeeController : ApiController
    {
        private Employee[] emps = new Employee[]
      {
            new Employee{EmpId=1,EmpName="Vanaja",Salary=10000},
            new Employee{EmpId=2,EmpName="Suneetha",Salary=20000},
            new Employee{EmpId=3,EmpName="Madhu",Salary=30000},
      };
        // GET: /Studens/
        public IEnumerable<Employee> GetAllStudens()
        {
            return emps;
        }

        public IHttpActionResult Get(int id)
        {
            Employee emp = (Employee)emps.Where(x => x.EmpId == id);

            if (emp == null)
            {
                return NotFound();
            }

            return Ok(emp);
        }
        [AllActionFilterAttribute]
        public IHttpActionResult Post(Employee emp)
        {
            try
            {
                //if (!ModelState.IsValid)
                //    return BadRequest();// Request.CreateResponse(HttpStatusCode.BadRequest, "Model is not valid.");

                Employee emp1 = new Employee { EmpId = emp.EmpId, EmpName = emp.EmpName, Salary = emp.Salary };

                emps.ToList().Add(emp1);
                return Created(Request.RequestUri.ToString(), "Employee created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [AllActionFilterAttribute]
        public IHttpActionResult Put(Employee emp)
        {
            try
            {
                //if (!ModelState.IsValid)
                //    return BadRequest("Not a valid model");

                Employee existingemp = emps.Where(e => e.EmpId == emp.EmpId).FirstOrDefault<Employee>();

                if (existingemp != null)
                {
                    emps.ToList().Remove(existingemp);
                    Employee emp1 = new Employee { EmpId = emp.EmpId, EmpName = emp.EmpName, Salary = emp.Salary };
                    emps.ToList().Add(emp1);

                }
                else
                {
                    return NotFound();
                };
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid employee id");
                Employee existingemp = emps.Where(e => e.EmpId == id).FirstOrDefault<Employee>();

                if (existingemp != null)
                {
                    emps.ToList().Remove(existingemp);
                }
                else
                {
                    return NotFound();
                };
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
