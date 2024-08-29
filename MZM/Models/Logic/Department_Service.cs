using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MZM.Models
{
    public class Department_Service
    {
        private ApplicationDbContext dataContext;
        public Department_Service()
        {
            this.dataContext = new ApplicationDbContext();
        }

        public List<Department> GetDepartments()
        {
            return dataContext.Departments.ToList();
        }
        public bool AddDepartment(Department department)
        {
            try
            {
                dataContext.Departments.Add(department);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool UpdateDepartment(Department department)
        {
            try
            {
                dataContext.Entry(department).State = EntityState.Modified;
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool RemoveDepartment(Department department)
        {
            try
            {
                dataContext.Departments.Remove(department);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public Department GetDepartment(int? department_id)
        {
            return dataContext.Departments.Find(department_id);
        }
  
    }
}