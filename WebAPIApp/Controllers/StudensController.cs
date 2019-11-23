using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    public class StudensController : ApiController
    {
        //
        Student[] students = new Student[]
       {
            new Student{StudentId=1,StudentName="Vanaja",Standard="8th"},
            new Student{StudentId=2,StudentName="Suneetha",Standard="9th"},
            new Student{StudentId=3,StudentName="Madhu",Standard="10th"},
       };
        // GET: /Studens/
        public IEnumerable<Student> GetAllStudens()
        {
            return students;
        }

        public HttpResponseMessage Get(int id)
        {
            Student stud = students.Where(s => s.StudentId == id).FirstOrDefault<Student>();

            if (stud != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, stud);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");
            }


        }
        [AllActionFilterAttribute]
        public HttpResponseMessage Post(Student student)
        {
            try
            {
                //if (!ModelState.IsValid)
                //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Model is not valid.");

                //Student stud = students.Where(s => s.StudentId == student.StudentId).FirstOrDefault<Student>();

                //if (stud != null)
                //{
                //    students.ToList().Remove(stud);
                Student stud1 = new Student { StudentId = student.StudentId, StudentName = student.StudentName, Standard = student.Standard };

                students.ToList().Add(stud1);
                return Request.CreateResponse(HttpStatusCode.Created, "Student created successfully.");
                //}
                //else
                //{
                //    return Request.CreateResponse(HttpStatusCode.NotFound, "Error messag");
                //}
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [AllActionFilterAttribute]
        public HttpResponseMessage Put(Student stud)
        {
            try
            {
                //if (!ModelState.IsValid)
                //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Model is not valid.");

                Student existingstud = students.Where(s => s.StudentId == stud.StudentId).FirstOrDefault<Student>();

                if (existingstud != null)
                {
                    students.ToList().Remove(existingstud);
                    Student stud1 = new Student { StudentId = stud.StudentId, StudentName = stud.StudentName, Standard = stud.Standard };
                    students.ToList().Add(stud1);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "student is not found");
                };
                return Request.CreateResponse(HttpStatusCode.OK, "student is modified");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Model is not valid.");
                Student existingstud = students.Where(s => s.StudentId == id).FirstOrDefault<Student>();

                if (existingstud != null)
                {
                    students.ToList().Remove(existingstud);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "student is not found");
                };
                return Request.CreateResponse(HttpStatusCode.OK, "student is deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

	}
}