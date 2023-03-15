using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(int id);

    }
}
