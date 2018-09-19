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
    public class TipoSexoComponent : ICrud<TipoSexo>
    {
        private MedicureContext db = new MedicureContext();

        public void Create(TipoSexo entity)
        {
            db.TipoSexo.Add(entity);
            db.SaveChanges();
        }

        public void Delete(TipoSexo entity)
        {
            db.TipoSexo.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<TipoSexo> Get()
        {
            return db.TipoSexo.ToList();
        }

        public TipoSexo GetDetail(int? id)
        {
            return db.TipoSexo.Find(id);
        }

        public void Update(TipoSexo entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        public DbSet SelectList()
        {
            return db.TipoSexo;
        }
    }
}
