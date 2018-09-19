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
    public class AfiliadoComponent : ICrud<Afiliado>
    {
        private MedicureContext db = new MedicureContext();

        public void Create(Afiliado entity)
        {
            db.Afiliado.Add(entity);
            db.SaveChanges();
        }
//C:\MCGA\MCGA\Business\MCGA.Business\AfiliadoComponent.cs
        public void Delete(Afiliado entity)
        {
            db.Afiliado.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<Afiliado> Get()
        {
            var afiliado = db.Afiliado.Include(a => a.TipoDocumento).Include(a => a.TipoSexo);
            return afiliado.ToList();
        }

        public Afiliado GetDetail(int? id)
        {
            return db.Afiliado.Find(id);
        }

        public void Update(Afiliado entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
