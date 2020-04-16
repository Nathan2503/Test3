using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDbProjet.Repositories
{
    public interface IClientDal<Tkey,T> : IRepositories<Tkey,T> where T: class
    {
        void Create(T parametre);
        void Delete(Tkey id);
        void Update(T parametre);
    }
}
