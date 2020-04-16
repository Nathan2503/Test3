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
    public class EvenementDalService : ServiceBase<EvenementDalService>, IRepositories<int, EvenementDal>
    {
        private static string connectionString = @"";
        public List<EvenementDal> GetAll()
        {
            List<EvenementDal> la = new List<EvenementDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueEvenment";
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            EvenementDal a = new EvenementDal();
                            a.eventId = (int)read["eventId"];
                            a.eventDescription = (string)read["eventDescription"];
                            a.eventDateDebut = (DateTime)read["eventDateDebut"];
                            a.eventDateFin = (DateTime)read["eventDateFin"];
                            //a.clientPwd = (string)read["biereImage"];
                            a.brasserieId = (int)read["brasserieId"];
                            la.Add(a);
                        }
                    }
                }
            }
            return la;
        }

        public EvenementDal GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
