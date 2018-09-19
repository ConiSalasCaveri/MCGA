using MCGA.Data;
using MCGA.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MCGA.Business
{
    public class TipoDiaComponent : ICrud<TipoDia>
    {
        private MedicureContext db = new MedicureContext();

        public void Create(TipoDia entity)
        {
            db.TipoDia.Add(entity);
            db.SaveChanges();
        }

        public void Delete(TipoDia entity)
        {
            db.TipoDia.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<TipoDia> Get()
        {
           return db.TipoDia.ToList();
        }
        
        public TipoDia GetDetail(int? id)
        {
           return db.TipoDia.Find(id);
        }

        public void Update(TipoDia entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        public DbSet SelectList()
        {
            return db.TipoDia;
        }
    }
}
