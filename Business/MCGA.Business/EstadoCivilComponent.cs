using MCGA.Data;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Business
{
    public class EstadoCivilComponent : ICrud<EstadoCivil>
    {
        private MedicureContext db = new MedicureContext();
        public void Create(EstadoCivil entity)
        {            
            db.EstadoCivil.Add(entity);
            db.SaveChanges();
        }

        public void Delete(EstadoCivil entity)
        {
            db.EstadoCivil.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<EstadoCivil> Get()
        {
            return db.EstadoCivil.ToList();
        }

        public EstadoCivil GetDetail(int? id)
        {
            return db.EstadoCivil.Find(id);
        }

        public void Update(EstadoCivil entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public DbSet SelectList()
        {
            return db.EstadoCivil;
        }
    }
}
