using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Business
{
    interface ICrud<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> Get();
        T GetDetail(int? id);
        void Dispose();
    }
}
