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
    public partial class CustomerWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CustomerDropDownFill();
                WineDDL();
                RaeListDDL();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                Name = txtName.Text,
                Age = txtAge.Text,
                Email = txtEmail.Text,
                WineID = Convert.ToInt32(DropDownListWine.SelectedValue),
                RateListID = Convert.ToInt32(ddl_RateList.SelectedValue)
            };
            BussinessCustomer.AddCustomers(customer);
            CustomerDropDownFill();
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerWS.aspx");
        }
        private void CustomerDropDownFill()
        {
            BussinessCustomer customerMdl = new BussinessCustomer();
            List<Customer> customers = customerMdl.GetCustomers();
            if (customers != null && customers.Count > 0)
            {
                grd.DataSource = customers;
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
        private void RaeListDDL()
        {
            BussinessRatelist rt = new BussinessRatelist();
            List<RateList> rateLists = rt.GetRateLists();

            if (rateLists != null && rateLists.Count > 0)
            {
                for (int i = 0; i < rateLists.Count; i++)
                {
                    ddl_RateList.Items.Add(rateLists[i].ID.ToString());
                }
                ddl_RateList.Items.Insert(0, new ListItem("Select Price", " "));
            }
            else
            {
                DropDownListWine.Items.Clear();
            }
        }
    }
}