using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineShopDataLayer;

namespace WineShopBussinessLayer
{
    public class BussinessCustomer
    {
        WineShopEntities _db = new WineShopEntities();
        public List<Customer> GetCustomers()//Customers list
        {
            try
            {
                List<Customer> customer = null;
                customer = (from c in _db.Customers select c).ToList();
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddCustomers(Customer customer)//Add method.
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Customer> CustomerDetails(string customerID)
        {
            try
            {
                List<Customer> customer = null;
                using (WineShopEntities db = new WineShopEntities())
                {
                    customer = (from c in db.Customers where c.ID.ToString() == customerID select c).ToList();
                }
                return customer
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateCustomer(Customer customer)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression
                    Customer c = db.Customers.SingleOrDefault(x => x.ID == customer.ID);
                    c.Name = customer.Name;
                    c.Age = customer.Age;
                    c.Email = customer.Email;
                    c.RateListID = customer.RateListID;
                    c.WineID = customer.WineID;
                    db.SaveChanges();
                    return customer.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteCustomer(string customerID)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression
                    Customer c = db.Customers.SingleOrDefault(x => x.ID.ToString().Trim() == customerID.Trim());
                    if (c != null)
                    {
                        db.Customers.Remove(c);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}