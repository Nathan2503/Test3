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
    public class OffreEmploiDalService : ServiceBase<OffreEmploiDalService>, IRepositories<int, OffreEmploiDal>
    {
        private static string connectionString = @"";

        public List<OffreEmploiDal> GetAll()
        {
            List<OffreEmploiDal> la = new List<OffreEmploiDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueOffreEmploi";
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            OffreEmploiDal a = new OffreEmploiDal();
                            a.offreEmploiId = (int)read["offreEmploiId"];
                            a.fonction = (string)read["fonction"];
                            a.jobDescription = (string)read["jobDescription"];
                            a.diplomeMin = (string)read["diplomeMin"];
                            //a.clientPwd = (string)read["biereImage"];
                            //a.brasserieId = (int)read["brasserieId"];
                            a.nomBrasserie = (string)read["nomBrasserie"];
                            a.experienceMin = (int)read["experienceMin"];
                            a.mailRecrutement = (string)read["mailRecrutement"];
                            la.Add(a);
                        }
                    }
                }
            }
            return la;
        }

        public OffreEmploiDal GetOne(int id)
        {
            OffreEmploiDal a = new OffreEmploiDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueOffreEmploi where offreEmploiId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            
                            a.offreEmploiId = (int)read["offreEmploiId"];
                            a.fonction = (string)read["fonction"];
                            a.jobDescription = (string)read["jobDescription"];
                            a.diplomeMin = (string)read["diplomeMin"];
                            //a.clientPwd = (string)read["biereImage"];
                            //a.brasserieId = (int)read["brasserieId"];
                            a.nomBrasserie = (string)read["nomBrasserie"];
                            a.experienceMin = (int)read["experienceMin"];
                            a.mailRecrutement = (string)read["mailRecrutement"];
                            
                        }
                    }
                }
            }
            return a;
        }
    }
}
