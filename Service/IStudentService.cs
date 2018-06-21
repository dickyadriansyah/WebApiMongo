using DataModel;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IStudentService
    {
        bool Insert(Student student);
        Student Get(string i);
        bool Update(string id, Student student);
        bool Delete(string id);
        IQueryable<Student> GetAll();
    }
}
