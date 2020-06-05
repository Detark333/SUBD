using System;
using System.Collections.Generic;
using System.Text;

namespace SUBD.Interface
{
    public interface ILogic<T>
    {
        List<T> Read();
        void Update(T model);
        void Create(T model);
        void Delete(T model);
        T Get(int Id);
    }
}
