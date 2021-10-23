using CoreWebAppMVC.EFCore;
using CoreWebAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAppMVC.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BrainwareContext _dbcontext;

        public OrderRepository(BrainwareContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Company> GetCompanyOrders(int companyId)
        {
            Company company = await _dbcontext.Companies.Include(i => i.Orders)
                                        .ThenInclude(i => i.Orderproducts)
                                        .ThenInclude(i => i.Product)
                                        .Where(i => i.CompanyId.Equals(companyId)).FirstOrDefaultAsync();

            return company;
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _dbcontext.Companies.ToList();
        }

        public Company GetCompanyById(int Id)
        {
            return _dbcontext.Companies.Find(Id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbcontext.Products.ToList();
        }

        public Product GetProductById(int Id)
        {
            return _dbcontext.Products.Find(Id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbcontext.Orders.ToList();
        }

        public Order GetOrderById(int Id)
        {
            return _dbcontext.Orders.Find(Id);
        }


        public IEnumerable<Orderproduct> GetOrderproducts()
        {
            return _dbcontext.Orderproducts.ToList();
        }

        public Orderproduct GetOrderproductById(int Id)
        {
            return _dbcontext.Orderproducts.Find(Id);
        }


        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbcontext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
