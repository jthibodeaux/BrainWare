using CoreWebAppMVC.EFCore;
using CoreWebAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAppMVC.Services
{
    public interface IOrderRepository
    {
        Task<Company> GetCompanyOrders(int companyId);
        public IEnumerable<Company> GetCompanies();

        public Company GetCompanyById(int Id);

        public IEnumerable<Product> GetProducts();

        public Product GetProductById(int Id);

        public IEnumerable<Order> GetOrders();

        public Order GetOrderById(int Id);

        public IEnumerable<Orderproduct> GetOrderproducts();

        public Orderproduct GetOrderproductById(int Id);
    }
}
