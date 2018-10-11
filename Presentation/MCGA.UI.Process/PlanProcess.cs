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
    public class PlanProcess : ICrud<Plan>
    {
        private PlanComponent component = new PlanComponent();
        public void Create(Plan entity)
        {
            component.Create(entity);
        }

        public void Delete(Plan entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<Plan> Get()
        {
            return component.Get();
        }

        public Plan GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(Plan entity)
        {
            component.Update(entity);
        }
        public DbSet SelectList()
        {
            return component.SelectList();
        }
    }
}
