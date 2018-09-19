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
    public class TipoDocumentoComponent : ICrud<TipoDocumento>
    {
        private MedicureContext db = new MedicureContext();

        public void Create(TipoDocumento entity)
        {
            db.TipoDocumento.Add(entity);
            db.SaveChanges();
        }

        public void Delete(TipoDocumento entity)
        {
            db.TipoDocumento.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<TipoDocumento> Get()
        {
            return db.TipoDocumento.ToList();
        }

        public TipoDocumento GetDetail(int? id)
        {
            return db.TipoDocumento.Find(id);
        }

        public void Update(TipoDocumento entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        public DbSet SelectList()
        {
            return db.TipoDocumento;
        }
    }
}
