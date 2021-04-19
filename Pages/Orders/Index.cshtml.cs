using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using Microsoft.AspNetCore.Authorization;
using BoOl.Repository;

namespace BoOl.Pages.Orders
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IRepository<Order> _repository;
        public int CountOfOrders { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(BoOlContext context)
        {
            _repository = new OrdersRepository(context);
        }

        public async Task OnGetAsync()
        {
            CountOfOrders = await _repository.CountAsync(null);
            var orders = await _repository.GetAllAsync(null);
            if (!string.IsNullOrEmpty(SearchString))
            {
                orders = orders.Where(s => s.Status.Contains(SearchString));
            }

            Orders = orders.ToList();
        }
    }
}
