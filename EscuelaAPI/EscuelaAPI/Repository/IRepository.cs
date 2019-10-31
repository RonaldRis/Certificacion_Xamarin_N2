using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaAPI.Repository
{
    interface IRepository<T>
    {
        IEnumerable<T> getAll();
        T getById(int id);
        bool post(T item);
        bool put(int id, T item);
        bool delete(int id);

    }
}
