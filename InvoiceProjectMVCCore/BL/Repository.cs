using InvoiceProjectMVCCore.BL;
using InvoiceProjectMVCCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Project_MVCCore.BL
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        InvoiceProjectContext db;
        public Repository()
        {
            db = new InvoiceProjectContext();
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
           TEntity entity=db.Set<TEntity>().Find(id);
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            TEntity entity = db.Set<TEntity>().Find(id);
            return entity;
        }

        public void Update(TEntity entity)
        {
            db.Entry<TEntity>(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
