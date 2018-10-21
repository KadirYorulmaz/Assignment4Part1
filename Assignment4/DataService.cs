using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Assignment4New.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4New
{
    public class DataService
    {

        private NorthwindContext db = new NorthwindContext();

        public IEnumerable<Category> GetCategories()
        {

            var getAll = db.Categories;
            
            return getAll;

        }

        public Category GetCategory(int id)
        {
            Category category = db.Categories.Where(x => x.Id == id).FirstOrDefault();
            return category;
        }

        public Category CreateCategory(string name, string description)
        {
            var maxId = db.Categories.Max(x => x.Id + 1);
            Category newCategory = new Category
            {
                Id = maxId,
                Name = name,
                Description = description
            };

            var create = db.Categories.Add(newCategory);

            db.SaveChanges();

            return newCategory;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var getCategory = GetCategory(id);
                var delete = db.Categories.Remove(getCategory);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCategory(int id, string name, string description)
        {
            try
            {
                var getCategory = GetCategory(id);

                getCategory.Name = name;
                getCategory.Description = description;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Product GetProduct(int id)
        {
            var product = db.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            return product;
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            var products = db.Products.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            return products;
        }

        public IEnumerable<Product> GetProductByCategory(int id)
        {
            var products = db.Products.Include(x => x.Category).Where(x => x.CategoryId == id).ToList();
            return products;
        }

        public Order GetOrder(int id)
        {
            var order = db.Orders.Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            List<Order> orders = db.Orders.ToList();
            return orders;
        }


        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            var orderDetails = db.OrderDetails
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Where(x => x.OrderId == id).ToList();
            return orderDetails;
        }

        public IEnumerable<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            var orderDetails = db.OrderDetails
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Where(x => x.ProductId == id).OrderBy(x => x.Order.Date);
            //var orderDetails = db.OrderDetails.Where(x => x.ProductId == id).ToList();
            return orderDetails;
        }



    }
}
