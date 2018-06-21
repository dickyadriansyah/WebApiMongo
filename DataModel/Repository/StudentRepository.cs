using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
    public class StudentRepository<T> where T : class
    {

        private MongoDatabase _database;
        private string _tableName;
        private MongoCollection<T> _collection;

        public StudentRepository(MongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<T>(tblName);
        }

        public void Add(T entity)
        {
            _collection.Insert(entity);
        }

        public T Get(Func<T, Boolean> where)
        {
            return _collection.FindAll().Where(where).FirstOrDefault<T>();
        }

        public T Get(int i)
        {
            return _collection.FindOneById(i);
        }

        public T Get(string id)
        {
            return _collection.FindOneById(ObjectId.Parse(id));
        }

        public IQueryable<T> GetAll()
        {
            MongoCursor<T> cursor = _collection.FindAll();
            return cursor.AsQueryable<T>();
        }
        

        public void Update(Expression<Func<T, ObjectId>> queryExpression, ObjectId id, T entity)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Update(query, Update<T>.Replace(entity));
        }

        public void Delete(Expression<Func<T, ObjectId>> queryExpression, ObjectId id)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Remove(query);
        }
    }
}
