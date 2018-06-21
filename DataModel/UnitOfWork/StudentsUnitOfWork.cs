using DataModel.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.UnitOfWork
{
    public class StudentsUnitOfWork
    {

        private MongoDatabase _database;

        protected StudentRepository<Student> _students;

        public StudentsUnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }

        public StudentRepository<Student> Students
        {
            get
            {
                if (_students == null)
                    _students = new StudentRepository<Student>(_database, "student");
                return _students;
            }
        }


    }
}
