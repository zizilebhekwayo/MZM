using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MZM.Models
{
    public class Category_Service
    {
        private ApplicationDbContext dataContext;

        public Category_Service()
        {
            this.dataContext = new ApplicationDbContext();
        }

        public List<Category> GetCategories()
        {
            return dataContext.Categories.ToList();
        }
        public bool AddCategory(Category category)
        {
            try
            {
                dataContext.Categories.Add(category);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool UpdateCategory(Category category)
        {
            try
            {
                dataContext.Entry(category).State = EntityState.Modified;
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool RemoveCategory(Category category)
        {
            try
            {
                dataContext.Categories.Remove(category);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public Category GetCategory(int? category_id)
        {
            return dataContext.Categories.Find(category_id);
        }
    }
}