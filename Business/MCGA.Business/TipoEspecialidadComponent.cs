
using MCGA.Data;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Business
{
    public class TipoEspecialidadComponent : ICrud<TipoEspecialidad>
    {
        private MedicureContext db = new MedicureContext();

        public void Create(TipoEspecialidad entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TipoEspecialidad entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IList<TipoEspecialidad> Get()
        {
            throw new NotImplementedException();
        }

        public IList<TipoEspecialidad> GetAutocomplete(string filter = "")
        {
            return db.TipoEspecialidad
                .Where(x => x.descripcion.Contains(filter))
                .OrderBy(x => x.Id)
                .ToList();
        }

        public TipoEspecialidad GetDetail(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoEspecialidad entity)
        {
            throw new NotImplementedException();
        }
    }
}
