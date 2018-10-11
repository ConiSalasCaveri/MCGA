using MCGA.Business;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
    public class TurnoProcess : ICrud<Turno>
    {
        private TurnoComponent component = new TurnoComponent();
        public void Create(Turno entity)
        {
            component.Create(entity);
        }

        public void Delete(Turno entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<Turno> Get()
        {
            return component.Get();
        }

        public Turno GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(Turno entity)
        {
            throw new NotImplementedException();
        }
    }
}
