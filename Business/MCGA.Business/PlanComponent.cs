using MCGA.Data;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Business
{
    public class PlanComponent : ICrud<Plan>
    {
        private MedicureContext db = new MedicureContext();
        public void Create(Plan entity)
        {
            entity.createdon = DateTime.Now;
            db.Plan.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Plan entity)
        {
            entity.deletedon = DateTime.Now;
            entity.isdeleted = true;
            db.Entry(entity).State = EntityState.Modified;
            // db.Plan.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<Plan> Get()
        {
            return db.Plan.ToList();
        }

        public Plan GetDetail(int? id)
        {
            return db.Plan.Find(id);
        }

        public void Update(Plan entity)
        {
            entity.changedon = DateTime.Now;
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        public DbSet SelectList()
        {
            return db.Plan;
        }
    }
}
