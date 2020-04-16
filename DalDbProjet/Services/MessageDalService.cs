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
    public class MessageDalService : ServiceBase<MessageDalService>, IRepositories<int, MessageDal>
    {
        private static string connectionString = @"";

        public List<MessageDal> GetAll()
        {
            List<MessageDal> la = new List<MessageDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueMessageAlert";
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            MessageDal a = new MessageDal();
                            a.messageAlertId = (int)read["messageAlertId"];
                            a.messageContenu = (string)read["messageContenu"];
                            a.messageDateDebut = (DateTime)read["messageDateDebut"];
                            a.messageDateFin = (DateTime)read["messageDateFin"];
                            //a.clientPwd = (string)read["biereImage"];
                            //a.brasserieId = (int)read["brasserieId"];
                            a.nomBrasserie = (string)read["nomBrasserie"];
                            la.Add(a);
                        }
                    }
                }
            }
            return la;
        }

        public MessageDal GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
