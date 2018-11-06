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
        public IList<EspecialidadDummy> GetAutocomplete(string filter = "")
        {
            return db.Especialidad
                .Where(x => x.descripcion.Contains(filter))
                .Select(x => new EspecialidadDummy { Id = x.Id, Descripcion = x.descripcion})
                .OrderBy(x => x.Id)
                .ToList();
        }

        public IList<EspecialidadDummy> GetAutocompleteWithProfesional(int idProfesional, string filter = "")
        {
            var especialidadesProfesional = db.EspecialidadesProfesional
                .Where(x => x.ProfesionalId == idProfesional)
                .Select(x => x.EspecialidadId)
                .ToList();

            var especialidades = db.Especialidad
                .Where(x => x.descripcion.Contains(filter))                
                .ToList();

            var especialidadDummies = especialidades
                .Where(x => !especialidadesProfesional.Contains(x.Id))
                .Select(x => new EspecialidadDummy { Id = x.Id, Descripcion = x.descripcion })
                .OrderBy(x => x.Id)
                .ToList();
            return especialidadDummies;
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

        public IList<EspecialidadDummy> GetByProfesional(int profesionalId)
        {
            var especialidadIds = db.EspecialidadesProfesional
                .Where(x => x.ProfesionalId == profesionalId)
                .Select(x => x.EspecialidadId)
                .ToList();

            var especialidades = db.Especialidad                
                .ToList();

            var especialidadDummies = especialidades
                .Where(x => especialidadIds.Contains(x.Id))
                .Select(x => new EspecialidadDummy { Id = x.Id, Descripcion = x.descripcion })
                .OrderBy(x => x.Id)
                .ToList();

            return especialidadDummies;
        }
    }
}
