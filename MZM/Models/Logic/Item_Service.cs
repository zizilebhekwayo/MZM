using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MZM.Models
{
    public class Item_Service
    {
        private ApplicationDbContext dataContext;

        public Item_Service()
        {
            this.dataContext = new ApplicationDbContext();
        }

        public List<Item> GetItems()
        {

            return dataContext.Items.Include(i => i.Department).ToList();
        }
        public bool AddItem(Item item)
        {
            try
            {
                dataContext.Items.Add(item);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        //public void UpdateQuantity(int id, int qty)
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    var qytUpdate = db.Items.Find(id);
        //    qytUpdate.QuantityInStock = qytUpdate.QuantityInStock - qty;
        //}
        public bool UpdateItem(Item item)
        {
            try
            {
                dataContext.Entry(item).State = EntityState.Modified;
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool RemoveItem(Item item)
        {
            try
            {
                dataContext.Items.Remove(item);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public Item GetItem(int? item_id)
        {
            return dataContext.Items.Find(item_id);
        }
    }
}