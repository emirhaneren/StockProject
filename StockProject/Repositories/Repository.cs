using StockProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Repositories
{
    public class Repository<T> where T:class,new()
    {
        DbStockProjectEntities db = new DbStockProjectEntities();

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        //Bulma Metodu, Linq expression,where şart
        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
        //Şartlı Listeleme
        public List<T> GetListById(Expression<Func<T,bool>> filter)
        {
            return db.Set<T>().Where(filter).ToList();
        }
    }
}
