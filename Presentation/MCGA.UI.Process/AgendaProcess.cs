using MCGA.Business;
using MCGA.Entities;
using System.Collections.Generic;

namespace MCGA.UI.Process
{
    public class AgendaProcess : ICrud<Agenda>
    {
        private AgendaComponent component = new AgendaComponent();
        public void Create(Agenda entity)
        {
            component.Create(entity);
        }

        public void Delete(Agenda entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<Agenda> Get()
        {
            return component.Get();
        }

        public Agenda GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(Agenda entity)
        {
            component.Update(entity);
        }
    }
}
