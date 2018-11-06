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
    public class ProfesionalEspecialidadComponent : ICrud<EspecialidadesProfesional>
    {
        private MedicureContext db = new MedicureContext();
        public void Create(EspecialidadesProfesional entity)
        {
            entity.createdon = DateTime.Now;
            db.EspecialidadesProfesional.Add(entity);
            db.SaveChanges();

        }

        public void Delete(EspecialidadesProfesional entity)
        {
            db.EspecialidadesProfesional.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<EspecialidadesProfesional> Get()
        {
            return db.EspecialidadesProfesional.ToList();
        }

        public EspecialidadesProfesional GetDetail(int? id)
        {
            return db.EspecialidadesProfesional.Find(id);
        }

        public void Update(EspecialidadesProfesional entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
