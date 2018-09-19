using MCGA.Data;
using MCGA.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MCGA.Business
{
    public class TipoReservaComponent : ICrud<TipoReseva>
    {
        private MedicureContext db = new MedicureContext();
        public void Create(TipoReseva entity)
        {
            db.TipoReseva.Add(entity);
            db.SaveChanges();
        }

        public void Delete(TipoReseva entity)
        {
            db.TipoReseva.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<TipoReseva> Get()
        {
            return db.TipoReseva.ToList();
        }

        public TipoReseva GetDetail(int? id)
        {
            return db.TipoReseva.Find(id);
        }

        public void Update(TipoReseva entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
