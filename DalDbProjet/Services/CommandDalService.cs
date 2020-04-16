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
    public class CommandDalService : ServiceBase<CommandDalService>, IRepositories<int, CommandeDal>
    {
        private static string connectionString = @"";
        public List<CommandeDal> GetAll()
        {
            List<CommandeDal> la = new List<CommandeDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText="select * from VueCommande";
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            CommandeDal a = new CommandeDal();
                            a.commandeId = (int)read["commandeId"];
                            a.biereNom = (string)read["biereNom"];
                            a.commandeDate = (DateTime)read["commandeDate"];
                            a.clientLogin = (string)read["clientLogin"];
                            //a.clientPwd = (string)read["biereImage"];
                            a.commandeQuantite = (int)read["commandeQuantite"];
                            a.bierePrix = (decimal)read["bierePrix"];
                            la.Add(a);
                        }
                    }
                }
            }
            return la;
        }

        public CommandeDal GetOne(int id)
        {
            CommandeDal a = new CommandeDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueCommande where commandeId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            a.commandeId = (int)read["commandeId"];
                            a.biereNom = (string)read["biereNom"];
                            a.commandeDate = (DateTime)read["commandeDate"];
                            a.clientLogin = (string)read["clientLogin"];
                            //a.clientPwd = (string)read["biereImage"];
                            a.commandeQuantite = (int)read["commandeQuantite"];
                            a.bierePrix = (decimal)read["bierePrix"];
                        }
                    }
                }
            }
            return a;
        }
        public void Create(CommandeDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddCommand";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.commandeDate), parametre.commandeDate);
                    command.Parameters.AddWithValue(nameof(parametre.commandeQuantite), parametre.commandeQuantite);
                    command.Parameters.AddWithValue(nameof(parametre.biereNom), parametre.biereNom);
                    command.Parameters.AddWithValue(nameof(parametre.clientLogin), parametre.clientLogin);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<CommandeDal> GetByLogin(string login)
        {
            List<CommandeDal> la = new List<CommandeDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select * from VueCommande where clientLogin=@login";
                    command.Parameters.AddWithValue("login", login);
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            CommandeDal a = new CommandeDal();
                            a.commandeId = (int)read["commandeId"];
                            a.biereNom = (string)read["biereNom"];
                            a.commandeDate = (DateTime)read["commandeDate"];
                            a.clientLogin = (string)read["clientLogin"];
                            //a.clientPwd = (string)read["biereImage"];
                            a.commandeQuantite = (int)read["commandeQuantite"];
                            a.bierePrix = (decimal)read["bierePrix"];
                            la.Add(a);
                        }
                    }
                }
            }
            return la;
        }
    }
}
