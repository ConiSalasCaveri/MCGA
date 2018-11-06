using MCGA.Business;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
    public class ProfesionalEspecialidadProcess : ICrud<EspecialidadesProfesional>
    {
        private ProfesionalEspecialidadComponent component = new ProfesionalEspecialidadComponent();
        public void Create(EspecialidadesProfesional entity)
        {
            component.Create(entity);
        }

        public void Delete(EspecialidadesProfesional entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<EspecialidadesProfesional> Get()
        {
            return component.Get();
        }

        public EspecialidadesProfesional GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(EspecialidadesProfesional entity)
        {
            component.Update(entity);
        }
    }
}
