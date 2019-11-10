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
    public partial class WineUpdateWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WineDropDownFill();
                WineDDL();
            }
        }

        protected void DropDownListWine_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Wine> wines = BussinessWine.GetWineDetails(DropDownListWine.SelectedValue);
            if (wines != null && wines.Count > 0)
            {
                for (int i = 0; i < wines.Count; i++)
                {
                    txtName.Text = wines[i].Name;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Wine wine = new Wine
            {
                ID = Convert.ToInt32(DropDownListWine.SelectedValue),
                Name = txtName.Text,
            };
            BussinessWine.UpdateWine(wine);
            WineDropDownFill();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            BussinessWine.DeleteWine(DropDownListWine.SelectedValue);
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
        private void WineDDL()
        {
            BussinessWine wn = new BussinessWine();
            List<Wine> wines = wn.GetWines();

            if (wines != null && wines.Count > 0)
            {
                for (int i = 0; i < wines.Count; i++)
                {
                    DropDownListWine.Items.Add(wines[i].ID.ToString());
                }
                DropDownListWine.Items.Insert(0, new ListItem("Select Wine", " "));
            }
            else
            {
                DropDownListWine.Items.Clear();
            }
        }
    }
}