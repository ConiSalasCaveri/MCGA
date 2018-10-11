using MCGA.Data;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Business
{
    public class ProfesionalComponent : ICrud<Profesional>
    {
        private MedicureContext db = new MedicureContext();

        public void Create(Profesional entity)
        {
            entity.createdon = DateTime.Now;
            entity.isdeleted = false;
            db.Profesional.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Profesional entity)
        {
            entity.deletedon = DateTime.Now;
            entity.isdeleted = true;
            db.Entry(entity).State = EntityState.Modified;
            // db.Profesional.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<Profesional> Get()
        {
            var profesionals = db.Profesional.Include(x => x.TipoDocumento);
            return profesionals.ToList();
        }

        public Profesional GetDetail(int? id)
        {
            return db.Profesional.Find(id);
        }

        public void Update(Profesional entity)
        {
            entity.changedon = DateTime.Now;
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
