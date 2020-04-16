using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDbProjet.Repositories
{
    public interface IRepositories<Tkey,T> where T:class
    {
        T GetOne(Tkey id);
        List<T> GetAll();
    }
}
