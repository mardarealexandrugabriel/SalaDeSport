using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Security.Cryptography;
using System.Text;


namespace SalaDeSport
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void RegisterClick(object sender, EventArgs e)
        {
            string username = Username.Value.ToString();
            string password = Password.Value.ToString();
            string firstname = FirstName.Value.ToString();
            string lastname = LastName.Value.ToString();
            string type = sel1.SelectedIndex.ToString();
            
            if (ConnectionClass.FindUsername(username))
            {
                VforUn.Visible = true;
            }
            else 
            {
                
                UserClass NewUser = new UserClass(username, password, firstname, lastname,Convert.ToInt32(type));
                NewUser.EncryptPassword();
                ConnectionClass.InsertNewUser(NewUser);
                Response.Redirect("Login.aspx");
            }




        }
        

    }
}