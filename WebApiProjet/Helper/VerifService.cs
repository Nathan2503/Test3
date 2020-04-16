using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApiProjet.Helper
{
    public class VerifService
    {
        private string Login
        {
            get
            {
                return HashTest("julie");
            }
        }
        private string Pwd
        {
            get
            {
                return HashTest("test1234=");
            }
        }
        private string Host
        {
            get
            {
                return HashTest("localhost:52013");
            }
        }
        public bool CheckHost(string host)
        {
            bool test;
            if (HashTest(host) == Host)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }
        public bool Check(string login, string pwd)
        {
            bool test;
            if (login == Login & pwd == Pwd)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }
        private string HashTest(string mot)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(mot));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}