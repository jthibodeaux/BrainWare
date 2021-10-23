using CoreWebAppMVC.EFCore;
using CoreWebAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAppMVC.Services
{

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Company> GetCompanyOrders(int companyId)
        {
            Company company = await _orderRepository.GetCompanyOrders(companyId);
            return company;
        }

        public List<OrderView> ConvertToOrderView(Company company)
        {
            try
            {
                var orderViews = new List<OrderView>();

                foreach (var order in company.Orders)
                {
                    OrderView orderView = new OrderView();
                    orderView.CompanyName = company.Name;
                    orderView.OrderId = order.OrderId;
                    orderView.OrderDescription = order.Description;
                    orderView.OrderProducts = order.Orderproducts;
                    orderView.OrderTotal = Convert.ToDecimal(order.Orderproducts.Sum(i => i.Quantity * i.Price));

                    orderViews.Add(orderView);
                }

                return orderViews;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Company GetCompanyById(int companyId)
        {
            Company company = _orderRepository.GetCompanyById(companyId);
            return company;
        }

        public Order GetOrderById(int orderId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            return order;
        }

        public Orderproduct GetOrderproductById(int orderproductId)
        {
            Orderproduct op = _orderRepository.GetOrderproductById(orderproductId);
            return op;
        }

        public Product GetProductById(int productId)
        {
            Product product = _orderRepository.GetProductById(productId);
            return product;
        }
    }
}
