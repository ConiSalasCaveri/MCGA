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
    public class TipoDiaProcess : ICrud<TipoDia>
    {
        private TipoDiaComponent component = new TipoDiaComponent();
        public void Create(TipoDia entity)
        {
            component.Create(entity);
        }

        public void Delete(TipoDia entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<TipoDia> Get()
        {
            return component.Get();
        }

        public TipoDia GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(TipoDia entity)
        {
            component.Update(entity);
        }
        public DbSet SelectList()
        {
            return component.SelectList();
        }

        public IList<TipoDia> GetAutocomplete(string filter)
        {
            return component.GetAutocomplete(filter);
        }
    }
}
