using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Lib.DAL
{
    public interface IBaseDAL<T>
    {
        public  List<T> readAll();
        public  T create(T entity);
        public  T update(T entity);
        public T delete(T entity);

        public T getDetailsbyOid(T entity);


    }
}
