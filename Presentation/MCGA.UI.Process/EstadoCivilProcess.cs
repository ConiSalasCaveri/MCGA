using MCGA.Business;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
    public class EstadoCivilProcess : ICrud<EstadoCivil>
    {
        private EstadoCivilComponent component = new EstadoCivilComponent();
        public void Create(EstadoCivil entity)
        {
            component.Create(entity);
        }

        public void Delete(EstadoCivil entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<EstadoCivil> Get()
        {
            return component.Get();
        }

        public EstadoCivil GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(EstadoCivil entity)
        {
            component.Update(entity);
        }
        public DbSet SelectList()
        {
            return component.SelectList();
        }
    }
}
