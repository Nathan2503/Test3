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
   public  class AccueilService : ServiceBase<AccueilService>, IRepositories<int, Accueil>
    {
        private static string connectionString = @"";
        public List<Accueil> GetAll()
        {
            List<Accueil> la = new List<Accueil>();
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueAccueil";
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            Accueil a = new Accueil();
                            a.brasserieId = (int)read["brasserieId"];
                            a.nomBrasserie = (string)read["nomBrasserie"];
                            a.brasseriePresentation = (string)read["brasseriePresentation"];
                            a.heureFermeture = (string)read["heureFermeture"].ToString();
                            a.heureOuverture = (string)read["heureOuverture"].ToString();
                            a.horraireDateDebut = (DateTime)read["horraireDateDebut"];
                            a.horraireDateFin = (DateTime)read["horraireDateFin"];
                            la.Add(a);
                        }
                    }
                }
            }
            return la;
        }

        public Accueil GetOne(int id)
        {
            Accueil a = new Accueil();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueAccueil where brasserieId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            
                            a.brasserieId = (int)read["brasserieId"];
                            a.nomBrasserie = (string)read["nomBrasserie"];
                            a.brasseriePresentation = (string)read["brasseriePresentation"];
                            a.heureFermeture = (string)read["heureFermeture"].ToString();
                            a.heureOuverture = (string)read["heureOuverture"].ToString();
                            a.horraireDateDebut = (DateTime)read["horraireDateDebut"];
                            a.horraireDateFin = (DateTime)read["horraireDateFin"];
                        }
                    }
                }
            }
            return a;  
        }
    }
}
