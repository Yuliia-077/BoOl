using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using BoOl.ViewModel;
using BoOl.Repository;

namespace BoOl.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private IRepository<Customer> _repository;
        public int CountOfCustomers { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(BoOlContext context)
        {
            _repository = new CustomerRepository(context);
        }

        public async Task OnGetAsync()
        {
            CountOfCustomers = await _repository.CountAsync(null);
            var customers = await _repository.GetAllAsync(null);
            if (!string.IsNullOrEmpty(SearchString))
            {
                customers = customers.Where(s => s.LastName.Contains(SearchString));
            }

            Customers = customers.ToList();
        }
    }
}
