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
    public partial class CustomerUpdateWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CustomerDropDownFill();
                WineDDL();
                RaeListDDL();
                CustomerDDL();
            }
        }

        protected void DropDownListCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Customer> customers = BussinessCustomer.CustomerDetails(DropDownListCustomer.SelectedValue);
            if (customers != null && customers.Count > 0)
            {
                for (int i = 0; i < customers.Count; i++)
                {
                    txtName.Text = customers[i].Name;
                    txtAge.Text = customers[i].Age;
                    txtEmail.Text = customers[i].Email;
                    DropDownListWine.SelectedValue = Convert.ToString(customers[i].WineID);
                    ddl_RateList.SelectedValue = Convert.ToString(customers[i].RateListID);
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                ID = Convert.ToInt32(DropDownListCustomer.SelectedValue),
                Name = txtName.Text,
                Age = txtAge.Text,
                Email = txtEmail.Text,
                WineID = Convert.ToInt32(DropDownListWine.SelectedValue),
                RateListID = Convert.ToInt32(ddl_RateList.SelectedValue)
            };
            BussinessCustomer.UpdateCustomer(customer);
            CustomerDropDownFill();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BussinessWine.DeleteWine(DropDownListWine.SelectedValue);
            CustomerDropDownFill();
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
        private void CustomerDDL()
        {
            BussinessCustomer cs = new BussinessCustomer();
            List<Customer> customers = cs.GetCustomers();

            if (customers != null && customers.Count > 0)
            {
                for (int i = 0; i < customers.Count; i++)
                {
                    DropDownListCustomer.Items.Add(customers[i].ID.ToString());
                }
                DropDownListCustomer.Items.Insert(0, new ListItem("Select Customers", " "));
            }
            else
            {
                DropDownListCustomer.Items.Clear();
            }
        }
    }
}