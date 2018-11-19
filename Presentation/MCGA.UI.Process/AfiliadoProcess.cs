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
    public class AfiliadoProcess : ICrud<Afiliado>
    {
        private AfiliadoComponent component = new AfiliadoComponent();
        public void Create(Afiliado entity)
        {
            component.Create(entity);
        }

        public void Delete(Afiliado entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<Afiliado> Get()
        {
            return component.Get();
        }

        public Afiliado GetDetail(int? id)
        {
            return component.GetDetail(id);
        }
        public IList<AfiliadoDummy> GetAutocomplete(string filter)
        {
            return component.GetAutocomplete(filter);
        }
        public void Update(Afiliado entity)
        {
            component.Update(entity);
        }
        public DbSet SelectList()
        {
            return component.SelectList();
        }
    }
}
