using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace SalaDeSport
{
    public class UserClass
    {
        int Id { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        int TypeOfUser { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }

        public UserClass()
        { }
        public UserClass(string username, string password, string firstname, string lastname,int typeofuser)
        {
            UserName = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            TypeOfUser = typeofuser;
        }
        public UserClass(int id, string username, string password, string firstname, string lastname,int typeofuser)
        {
            Id = id;
            UserName = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            TypeOfUser = typeofuser;
        }
        public int GetTypeOfUser()
        {
            return TypeOfUser;
        }
        public string GetUserName()
        {
            return UserName;
        }
        public string GetPassword()
        {
            return Password;
        }
         public string GetLastname()
        {
            return Lastname;
        }
        public int GetId()
        {
            return Id;
        }
         public void SetLastName(string lastname)
        {
            Lastname = lastname;
        }
        public void SetTypeOfUser(int typeofuser)
        {
             TypeOfUser = typeofuser;
        }
        public void SetFirstName(string firstname)
        {
            Firstname = firstname;
        }
        public void SetUserName(string username)
        {
            UserName = username;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
        public string GetFirstname()
        {
            return Firstname;
        }
        public void EncryptPassword()
        {
            Password = EncryptPassword2(Password);
        }
        public string EncryptPassword2(string pw)
        {
            string password2;
            MD5 Hash = MD5.Create();
            byte[] by = Hash.ComputeHash(Encoding.UTF8.GetBytes(pw));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < by.Length; i++)
            {
                builder.Append(by[i].ToString("x2"));
            }
            password2 = builder.ToString();
            return password2;
        }
        public bool IsCorrectPassword(string pw)
        {
            
            if (Password.Equals(EncryptPassword2(pw))) return true;
                return false;

        }
        public bool IsCoach()
        {
            return (TypeOfUser == 0);
        }

      
       

    }
}