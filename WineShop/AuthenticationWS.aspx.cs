using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WineShopBussinessLayer;
using WineShopDataLayer;

namespace WineShop
{
    public partial class AuthenticationWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            UserVM vmModel = new UserVM();
            Response.Cookies["Email"].Value = Username.Text.Trim();
            Response.Cookies["Password"].Value = password.Text.Trim();
            vmModel.Email = Username.Text.Trim();
            vmModel.Password = password.Text.Trim();
            BusinessUser autn = new BusinessUser();
            bool msg = autn.UserAuthentication(vmModel);
            if (msg)
            {
                Response.Redirect("WineWS.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Login ID and Password is invalid.";
            }
        }
    }
}