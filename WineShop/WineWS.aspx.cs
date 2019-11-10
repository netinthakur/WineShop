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
    public partial class WineWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WineDropDownFill();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Wine wine = new Wine
            {
                Name = txtName.Text,
            };
            BussinessWine.AddWines(wine);
            WineDropDownFill();
        }
        private void WineDropDownFill()
        {
            BussinessWine wineMdl = new BussinessWine();
            List<Wine> wines = wineMdl.GetWines();
            if (wines != null && wines.Count > 0)
            {
                grd.DataSource = wines;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("WineWS.aspx");
        }
    }
}