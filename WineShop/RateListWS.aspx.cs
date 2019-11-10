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
    public partial class RateListWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RateListDropDownFill();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            RateList Ratelist = new RateList
            {
                Price = Convert.ToDecimal(txtPrice.Text),
            };
            BussinessRatelist.AddRateLists(Ratelist);
            RateListDropDownFill();
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("RateListWS.aspx");
        }
        private void RateListDropDownFill()
        {
            BussinessRatelist rateMdl = new BussinessRatelist();
            List<RateList> rateLists = rateMdl.GetRateLists();
            if (rateLists != null && rateLists.Count > 0)
            {
                grd.DataSource = rateLists;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
    }
}