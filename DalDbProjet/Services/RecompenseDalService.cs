using DalDbProjet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDbProjet.Services
{
    public class RecompenseDalService : ServiceBase<RecompenseDalService>
    {
        private static string connectionString = @"";
        public List<RecompenseDal> GetAll(int id)
        {
            List<RecompenseDal> la = new List<RecompenseDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from Recompense where biereId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            RecompenseDal a = new RecompenseDal();
                            a.recompenseId = (int)read["recompenseId"];
                            a.recompenseNom= (string)read["recompenseNom"];
                            a.biereId = (int)read["biereId"];
                            la.Add(a);
                        }
                    }
                }
            }
            return la;
        }
    }
}
