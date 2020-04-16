using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDbProjet.Repositories
{
    public interface IBiereDal<Tkey,T>: IRepositories<Tkey,T> where T:class
    {
        T getByName(string name);
    }
}
