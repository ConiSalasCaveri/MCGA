using MCGA.Business;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
    public class TipoReservaProcess : ICrud<TipoReseva>
    {
        private TipoReservaComponent component = new TipoReservaComponent();
        public void Create(TipoReseva entity)
        {
            component.Create(entity);
        }

        public void Delete(TipoReseva entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<TipoReseva> Get()
        {
            return component.Get();
        }

        public TipoReseva GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(TipoReseva entity)
        {
            component.Update(entity);
        }
    }
}
