using DalDbProjet.Models;
using DalDbProjet.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDbProjet.Services
{
    public class ContactDalService : ServiceBase<ContactDalService>, IRepositories<int, ContactDal>
    {
        private static string connectionString = @"";

        public List<ContactDal> GetAll()
        {
            List<ContactDal> la = new List<ContactDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueContact";
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            ContactDal a = new ContactDal();
                            a.contactId = (int)read["contactId"];
                            a.adCodePostal = (string)read["adCodePostal"];
                            a.adNumero = (string)read["adNumero"];
                            a.adVille = (string)read["adVille"];
                            //a.clientPwd = (string)read["biereImage"];
                            a.adRue = (string)read["adRue"];
                            a.mailInfon = (string)read["mailInfon"];
                            a.nomBrasserie = (string)read["nomBrasserie"];
                            a.telephone = (string)read["telephone"];

                            la.Add(a);
                        }
                    }
                }
            }
            return la;
        }

        public ContactDal GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
