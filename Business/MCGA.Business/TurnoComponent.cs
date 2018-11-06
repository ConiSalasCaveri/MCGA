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
    public class TurnoComponent : ICrud<Turno>
    {
        private MedicureContext db = new MedicureContext();
        public void Create(Turno entity)
        {
            entity.createdon = DateTime.Now;
            db.Turno.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Turno entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<Turno> Get()
        {
            var turno = db.Turno.Include(t => t.Afiliado);
            return turno.ToList();
        }

        public Turno GetDetail(int? id)
        {
            return db.Turno.Find(id);
        }

        public void Update(Turno entity)
        {
            throw new NotImplementedException();
        }

        public int getEspecialidadProfesionalId(int profesionalId, int especialidaId)
        {
            var especialidadprofesionalId = db.EspecialidadesProfesional
                 .Where(x => x.ProfesionalId == profesionalId && x.EspecialidadId == especialidaId)
                 .Select(x => x.Id)
                 .FirstOrDefault();

            return especialidadprofesionalId;
        }
    }
}
