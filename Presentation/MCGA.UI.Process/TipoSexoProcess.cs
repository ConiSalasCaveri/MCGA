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
    public class TipoSexoProcess : ICrud<TipoSexo>
    {

        private TipoSexoComponent component = new TipoSexoComponent();
        public void Create(TipoSexo entity)
        {
            component.Create(entity);
        }

        public void Delete(TipoSexo entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<TipoSexo> Get()
        {
            return component.Get();
        }

        public TipoSexo GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(TipoSexo entity)
        {
            component.Update(entity);
        }
        public DbSet SelectList()
        {
            return component.SelectList();
        }
    }
}
