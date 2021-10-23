using CoreWebAppMVC.EFCore;
using CoreWebAppMVC.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Company companyOrders = GetTestCompanyOrders();

            OrderService orderService = new OrderService(null);
            var OrderViews = orderService.ConvertToOrderView(companyOrders);

            Assert.IsNotNull(OrderViews);
            Assert.Greater(OrderViews.Count, 0);
            Assert.Greater(OrderViews[0].OrderTotal, 0);
        }

        private Company GetTestCompanyOrders()
        {
            Company company = new Company();
            company.CompanyId = 1;
            company.Name = "Test Company";
            company.Orders = new List<Order>();

            Order orderOne = CreateOrder(1, "First Order", 1);

            Orderproduct op1 = CreateOrderproduct(1, 1.50M, 3);
            op1.Product = CreateProduct(1, 1.50M);
            orderOne.Orderproducts.Add(op1);

            Orderproduct op2 = CreateOrderproduct(2, 2.50M, 4);
            op2.Product = CreateProduct(2, 2.50M); ;
            orderOne.Orderproducts.Add(op2);

            company.Orders.Add(orderOne);

            return company;
        }

        private Order CreateOrder(int CompanyId, string Description, int OrderId)
        {
            Order order = new Order();
            order.CompanyId = CompanyId;
            order.Description = Description;
            order.OrderId = OrderId;
            order.Orderproducts = new List<Orderproduct>();
            return order;
        }

        private Product CreateProduct(int ProductId, decimal Price)
        {
            Product product = new Product();
            product.ProductId = ProductId;
            product.Price = Price;
            return product;
        }

        private Orderproduct CreateOrderproduct(int ProductId, decimal Price, int Quantity)
        {
            Orderproduct orderproduct = new Orderproduct();
            orderproduct.ProductId = ProductId;
            orderproduct.Price = Price;
            orderproduct.Quantity = Quantity;
            return orderproduct;
        }
    }
}