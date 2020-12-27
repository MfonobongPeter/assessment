using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Interfaces
{

    public interface IGenericInterface<T> where T : class
    {
        IEnumerable<T> SelectAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        int Save();
    }

}
