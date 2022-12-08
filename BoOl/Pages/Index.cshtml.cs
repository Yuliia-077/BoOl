using BoOl.Application.Services.Customers;
using BoOl.Application.Services.Orders;
using BoOl.Application.Services.Services;
using BoOl.Models.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IServiceService _serviceService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly int _pageSize = 6;

        public IndexModel(IServiceService serviceService,
            ICustomerService customerService,
            IOrderService orderService)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        public IList<ServiceListItem> Services { get; set; }
        public int CountOfServices { get; set; }
        public int CountOfCustomers { get; set; }
        public int CountOfOrders { get; set; }

        public async Task OnGetAsync()
        {
            var services = await _serviceService.MostPopularServices(_pageSize);
            Services = services.Select(x => x.AsViewModel()).ToList();
            CountOfServices = await _serviceService.Count(null);
            CountOfCustomers = await _customerService.Count(null);
            CountOfOrders = await _orderService.CountAll();
        }
    }
}
