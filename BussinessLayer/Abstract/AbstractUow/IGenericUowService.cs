using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstactUow
{
    public interface IGenericUowService<T>
    {
        void TInsert(T t);
        void TUpDate(T t);
        void TMultuUpdate(List<T> t);
        T TGetById(int id);
    }
}
