using DataModel;
using DataModel.UnitOfWork;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMongo.Controllers
{
    public class StudentController : ApiController
    {

        private readonly IStudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }
        

        public HttpResponseMessage Get(string id)
        {
            var student = _studentService.Get(id);
            if (student != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, student);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing for provided id.");
        }
        

        public HttpResponseMessage GetAll()
        {
            var students = _studentService.GetAll();
            if (students.Any())
                return Request.CreateResponse(HttpStatusCode.OK, students);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No students found.");
        }

        public HttpResponseMessage Post([FromBody]Student student)
        {
            if (ModelState.IsValid)
            {
                var data = _studentService.Insert(student);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, student);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.HttpVersionNotSupported, ModelState);
        }
        

        public HttpResponseMessage Put ([FromBody]Student student, string id = "")
        {
            
            if (id != null)
            {
                var data = _studentService.Update(id, student);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.HttpVersionNotSupported, ModelState);
        }

        public HttpResponseMessage Delete(string id)
        {
            if(id != null)
            {
                var data = _studentService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.HttpVersionNotSupported, ModelState);
        }
        
    }
}
