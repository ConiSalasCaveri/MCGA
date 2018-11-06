using MCGA.Business;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
    public class EspecialidadProcess : ICrud<Especialidad>
    {
        private EspecialidadComponent component = new EspecialidadComponent();
        public void Create(Especialidad entity)
        {
            component.Create(entity);
        }

        public void Delete(Especialidad entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<Especialidad> Get()
        {
            return component.Get();
        }

        public Especialidad GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(Especialidad entity)
        {
            component.Update(entity);
        }

        public IList<EspecialidadDummy> GetAutocomplete(string filter)
        {
            return component.GetAutocomplete(filter);
        }

        public IList<EspecialidadDummy> GetAutocompleteWithProfesional(int idProfesional, string filter)
        {
            return component.GetAutocompleteWithProfesional(idProfesional, filter);
        }

        public IList<EspecialidadDummy> GetByProfesional(int especialidadId)
        {
            return component.GetByProfesional(especialidadId);
        }
    }
}
