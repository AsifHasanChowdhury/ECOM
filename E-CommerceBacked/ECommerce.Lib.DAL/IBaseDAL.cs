using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Lib.DAL
{
    internal interface IBaseDAL<T>
    {
        List<T> readAll();
        T create(T entity);
        T update(T entity);
        T delete(T entity);


    }
}
