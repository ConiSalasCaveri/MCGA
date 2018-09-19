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
    public class EspecialidadComponent : ICrud<Especialidad>
    {
        private MedicureContext db = new MedicureContext();
        public void Create(Especialidad entity)
        {
            db.Especialidad.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Especialidad entity)
        {
            db.Especialidad.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<Especialidad> Get()
        {
            return db.Especialidad.ToList();
        }

        public Especialidad GetDetail(int? id)
        {
            return db.Especialidad.Find(id);
        }

        public void Update(Especialidad entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
