using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolOffset_Services.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Delete(int id);
        void Update(T item);
    }
}
