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
    public class TipoDocumentoProcess : ICrud<TipoDocumento>
    {
        private TipoDocumentoComponent component = new TipoDocumentoComponent();
        public void Create(TipoDocumento entity)
        {
            component.Create(entity);
        }

        public void Delete(TipoDocumento entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<TipoDocumento> Get()
        {
            return component.Get();
        }

        public TipoDocumento GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(TipoDocumento entity)
        {
            component.Update(entity);
        }
        public DbSet SelectList()
        {
            return component.SelectList();
        }
    }
}
