using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineShopDataLayer;

namespace WineShopBussinessLayer
{
    public class BusinessUser
    {
        WineShopEntities _db = new WineShopEntities();

        public bool UserAuthentication(UserVM vmModel)//Authentication
        {
            bool isAuthenticate = false;
            try
            {
                var record = (from a in _db.Users
                              where a.Email == vmModel.Email && a.Password == vmModel.Password
                              select a).Count() > 0 ? true : false;
                if (record)
                {
                    isAuthenticate = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isAuthenticate;
        }
    }
}