using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Services.XmlRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int ID);
        void Insert(T item);
        void Update(T item);
        void Delete(int ID);
    }
}
