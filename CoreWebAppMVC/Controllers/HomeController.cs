using CoreWebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CoreWebAppMVC.Services;

namespace CoreWebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var companyOrders = await _orderService.GetCompanyOrders(1);
                if (companyOrders == null || companyOrders.Orders.Count == 0)
                {
                    string errmsg = "No Company Orders";
                    _logger.LogError(errmsg);
                    return NotFound(errmsg);
                }

                var orderViews = _orderService.ConvertToOrderView(companyOrders);
                if (orderViews == null || orderViews.Count == 0)
                {
                    string errmsg = "Company Orders Conversion error";
                    _logger.LogError(errmsg);
                    throw new Exception(errmsg);
                }

                return View(orderViews);
            }
            catch(Exception ex)
            {
                _logger.LogError("Orders error",ex);
                throw ex;
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
