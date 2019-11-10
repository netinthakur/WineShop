using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineShopDataLayer;

namespace WineShopBussinessLayer
{
    public class BussinessWine
    {
        WineShopEntities _db = new WineShopEntities();
        public List<Wine> GetWines()// Wine list 
        {
            try
            {
                List<Wine> wine = null;
                wine = (from w in _db.Wines select w).ToList();
                return wine;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddWines(Wine wine)//This is Add method.
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    db.Wines.Add(wine);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Wine> GetWineDetails(string wineID)
        {
            try
            {
                List<Wine> wine = null;
                using (WineShopEntities db = new WineShopEntities())
                {
                    wine = (from w in db.Wines where w.ID.ToString() == wineID select w).ToList();
                }
                return wine;
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateWine(Wine wine)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression

                    Wine c = db.Wines.SingleOrDefault(x => x.ID == wine.ID);
                    c.Name = wine.Name;
                    
                    db.SaveChanges();
                    return wine.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteWine(string wineID)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression
                    Wine w = db.Wines.SingleOrDefault(x => x.ID.ToString().Trim() == wineID.Trim());
                    if (w != null)
                    {
                        db.Wines.Remove(w);
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
