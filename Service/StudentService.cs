using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataModel.UnitOfWork;
using MongoDB.Bson;

namespace Service
{
    public class StudentService : IStudentService
    {

        private readonly StudentsUnitOfWork _sUnitOfWork;

        public StudentService()
        {
            _sUnitOfWork = new StudentsUnitOfWork();
        }

        public bool Delete(string id)
        {
            bool success = false;
            if (id != null)
            {
                //id = new ObjectId(id);
                _sUnitOfWork.Students.Delete(s => s.id, ObjectId.Parse(id));
                return success = true;
            }


            return success;
        }

        public Student Get(string i)
        {
            return _sUnitOfWork.Students.Get(i);
        }

        public IQueryable<Student> GetAll()
        {
            return _sUnitOfWork.Students.GetAll();
        }

        public bool Insert(Student student)
        {
            bool success = false;
            if(student != null)
            {
                _sUnitOfWork.Students.Add(student);
                return success = true;
            }
            return success;
            
        }

        public bool Update(string id, Student student)
        {
            bool success = false;
            if(student != null)
            {
                student.id = new ObjectId(id);
                _sUnitOfWork.Students.Update(s => s.id, student.id, student);
                return success = true;
            }
            

            return success;
        }
        
    }
}
