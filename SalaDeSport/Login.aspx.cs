using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalaDeSport
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginClick(object sender, EventArgs e)
        {
            string username = Username.Value.ToString();
            string password = Password.Value.ToString();
            if (!ConnectionClass.FindUsername(username))
            {
                VUsername.Visible = true;
            }
            else
            {
                UserClass User = new UserClass();
                User = ConnectionClass.GetUserById(ConnectionClass.GetUserId(username));
                
                if (User.IsCorrectPassword(password))
                {
                    Session["User"] = User;
                    Response.Redirect("Program.aspx");

                }
                else
                {
                    VPassword.Visible = true;
                }
            }
        }
    }
}