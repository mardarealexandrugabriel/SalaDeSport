using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalaDeSport
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                 navunregistered.Visible = true;
            }
            else {
                UserClass User;
                User = (UserClass)Session["User"];
                if (User.IsCoach())
                {
                    navtrainer.Visible = true ;
                }
                else navgymnast.Visible = true;
            }
          
            
        }
       
    }
}