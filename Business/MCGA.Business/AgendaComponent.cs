using MCGA.Data;
using MCGA.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MCGA.Business
{
    public class AgendaComponent : ICrud<Agenda>
    {
        private MedicureContext db = new MedicureContext();
        public void Create(Agenda entity)
        {
            db.Agenda.Add(entity);
            db.SaveChanges();
        }
//C:\MCGA\MCGA\Business\MCGA.Business\AgendaComponent.cs
        public void Delete(Agenda entity)
        {
            db.Agenda.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<Agenda> Get()
        {
            var agenda = db.Agenda.Include(a => a.TipoDia);
            return agenda.ToList();
        }

        public Agenda GetDetail(int? id)
        {
            return db.Agenda.Find(id);
        }

        public void Update(Agenda entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
