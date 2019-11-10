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
    public partial class RateListUpdateWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RateListDropDownFill();
                RaeListDDL();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            RateList rate = new RateList
            {
                ID = Convert.ToInt32(DropDownListRateList.SelectedValue),
                Price = Convert.ToDecimal(txtPrice.Text)
            };
            BussinessRatelist.UpdateRateList(rate);
            RateListDropDownFill();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            BussinessRatelist.DeleteRateList(DropDownListRateList.SelectedValue);
            RateListDropDownFill();
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

        protected void DropDownListRateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<RateList> rates = BussinessRatelist.GetRateListDetails(DropDownListRateList.SelectedValue);
            if (rates != null && rates.Count > 0)
            {
                for (int i = 0; i < rates.Count; i++)
                {
                    txtPrice.Text = Convert.ToString(rates[i].Price);
                }
            }
        }

        private void RaeListDDL()
        {
            BussinessRatelist rt = new BussinessRatelist();
            List<RateList> rateLists = rt.GetRateLists();

            if (rateLists != null && rateLists.Count > 0)
            {
                for (int i = 0; i < rateLists.Count; i++)
                {
                    DropDownListRateList.Items.Add(rateLists[i].ID.ToString());
                }
                DropDownListRateList.Items.Insert(0, new ListItem("Select Ratelist", " "));
            }
            else
            {
                DropDownListRateList.Items.Clear();
            }
        }
    }
}