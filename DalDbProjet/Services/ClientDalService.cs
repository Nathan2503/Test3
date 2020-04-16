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
    public class ClientDalService : ServiceBase<ClientDalService>, IClientDal<int, ClientDal>
    {
        private static string connectionString = @"";

        public void Create(ClientDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddClient";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                   // DateTime test = parametre.clienDateNaissance;
                    command.Parameters.AddWithValue("clientDateNaissance", parametre.clienDateNaissance);
                    command.Parameters.AddWithValue(nameof(parametre.clientLogin), parametre.clientLogin);
                    command.Parameters.AddWithValue(nameof(parametre.clientNom), parametre.clientNom);
                    command.Parameters.AddWithValue(nameof(parametre.clientPrenom), parametre.clientPrenom);
                    command.Parameters.AddWithValue(nameof(parametre.clientPwd).ToLower(), parametre.clientPwd);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "DeleteClient";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("clientId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ClientDal> GetAll()
        {
            List<ClientDal> la = new List<ClientDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select clientId,clientNom,clientPrenom,clientLogin,clientDateNaissance from Client";
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            ClientDal a = new ClientDal();
                            a.clientId = (int)read["clientId"];
                            a.clientNom = (string)read["clientNom"];
                            a.clientPrenom = (string)read["clientPrenom"];
                            a.clientLogin = (string)read["clientLogin"];
                            //a.clientPwd = (string)read["biereImage"];
                            a.clienDateNaissance = (DateTime)read["clientDateNaissance"];
                            la.Add(a);
                        }
                    }
                }
            }
            return la;
        }

        public ClientDal GetOne(int id)
        {
            ClientDal a = new ClientDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "select clientId,clientNom,clientPrenom,clientLogin,clientDateNaissance from Client where clientId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            
                            a.clientId = (int)read["clientId"];
                            a.clientNom = (string)read["clientNom"];
                            a.clientPrenom = (string)read["clientPrenom"];
                            a.clientLogin = (string)read["clientLogin"];
                            //a.clientPwd = (string)read["biereImage"];
                            a.clienDateNaissance = (DateTime)read["clientDateNaissance"];
                        }
                    }
                }
            }
            return a;
        }

        public void Update(ClientDal parametre)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditClient";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.clientLogin), parametre.clientLogin);
                    command.Parameters.AddWithValue(nameof(parametre.clientId), parametre.clientId);
                    command.Parameters.AddWithValue(nameof(parametre.clientPwd), parametre.clientPwd);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public int? Connection(string login,string pwd)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "SeConnecter";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("login", login);
                    command.Parameters.AddWithValue("pwd", pwd);
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "ID";
                    parameter.Value = 0;
                    parameter.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(parameter);
                    con.Open();
                    command.ExecuteNonQuery();
                    int? ID;
                    if(command.Parameters["ID"].Value is DBNull)
                    {
                        ID = null;
                    }
                    else
                    {
                        ID= (int?)command.Parameters["ID"].Value;
                    }
                    return ID;
                }
            }
        }
    }
}
