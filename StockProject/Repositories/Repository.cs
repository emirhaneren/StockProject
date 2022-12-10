using StockProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void TUpdate()
        {
            db.SaveChanges();
        }
    }
}
