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
    public class BiereDalService : ServiceBase<BiereDalService>, IBiereDal<int, BiereDal>
    {
        private static string connectionString = @"";

        public List<BiereDal> GetAll()
        {
            List<BiereDal> la = new List<BiereDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueBiere";
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            BiereDal a = new BiereDal();
                            a.biereId = (int)read["biereId"];
                            a.nomBrasserie = (string)read["nomBrasserie"];
                            a.biereDescription = (string)read["biereDescription"];
                            a.biereNom = (string)read["biereNom"];
                            a.biereImage = (string)read["biereImage"];
                            //Decimal test = (Decimal)read["bierePrix"];
                            a.bierePrix = (Decimal)read["bierePrix"];
                            a.biereRobe = (string)read["biereRobe"];
                            a.pourcentageAlcool = (Decimal)read["pourcentageAlcool"];
                            a.typeBiereNom = (string)read["typeBiereNom"];
                            la.Add(a);
                        }
                    }
                }
            }
            return la;
        }

        public BiereDal getByName(string name)
        {
            BiereDal a = new BiereDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueBiere where biereNom=@name";
                    command.Parameters.AddWithValue("name", name);
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            a.biereId = (int)read["biereId"];
                            a.nomBrasserie = (string)read["nomBrasserie"];
                            a.biereDescription = (string)read["biereDescription"];
                            a.biereNom = (string)read["biereNom"];
                            a.biereImage = (string)read["biereImage"];
                            a.bierePrix = (decimal)read["bierePrix"];
                            a.biereRobe = (string)read["biereRobe"];
                            a.pourcentageAlcool = (decimal)read["pourcentageAlcool"];
                            a.typeBiereNom = (string)read["typeBiereNom"];
                        }
                    }
                }
            }
            return a;
        }

        public BiereDal GetOne(int id)
        {
            BiereDal a = new BiereDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueBiere where biereId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            a.biereId = (int)read["biereId"];
                            a.nomBrasserie = (string)read["nomBrasserie"];
                            a.biereDescription = (string)read["biereDescription"];
                            a.biereNom = (string)read["biereNom"];
                            a.biereImage = (string)read["biereImage"];
                            a.bierePrix = (decimal)read["bierePrix"];
                            a.biereRobe = (string)read["biereRobe"];
                            a.pourcentageAlcool = (decimal)read["pourcentageAlcool"];
                            a.typeBiereNom = (string)read["typeBiereNom"];
                        }
                    }
                }
            }
            return a;
        }
    }
}
