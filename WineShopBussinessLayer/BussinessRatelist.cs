using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineShopDataLayer;

namespace WineShopBussinessLayer
{
    public class BussinessRatelist
    {
        WineShopEntities _db = new WineShopEntities();
        public List<RateList> GetRateLists()//RateList list
        {
            try
            {
                List<RateList> rateList = null;
                rateList = (from o in _db.RateLists select o).ToList();
                return rateList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddRateLists(RateList rateList)//Add method.
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    db.RateLists.Add(rateList);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<RateList> GetRateListDetails(string rateListID)
        {
            try
            {
                List<RateList> rateList = null;
                using (WineShopEntities db = new WineShopEntities())
                {
                    rateList = (from c in db.RateLists where c.ID.ToString() == rateListID select c).ToList();
                }
                return rateList
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateRateList(RateList rateList)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression
                    RateList r = db.RateLists.SingleOrDefault(x => x.ID == rateList.ID);
                    r.Price = rateList.Price;
                    db.SaveChanges();
                    return rateList.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteRateList(string rateListID)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression
                    RateList r = db.RateLists.SingleOrDefault(x => x.ID.ToString().Trim() == rateListID.Trim());
                    if (r != null)
                    {
                        db.RateLists.Remove(r);
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