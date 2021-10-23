using CoreWebAppMVC.EFCore;
using CoreWebAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAppMVC.Services
{
    public interface IOrderService
    {
        public List<OrderView> ConvertToOrderView(Company company);
        public Task<Company> GetCompanyOrders(int companyId);

        public Company GetCompanyById(int companyId);

        public Order GetOrderById(int orderId);

        public Orderproduct GetOrderproductById(int orderproductId);

        public Product GetProductById(int productId);
    }
}
