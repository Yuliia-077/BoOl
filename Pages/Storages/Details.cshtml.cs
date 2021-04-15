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

namespace BoOl.Pages.Storages
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Storage> _repository;
        public Storage Storage { get; set; }

        public DetailsModel(BoOlContext context)
        {
            _repository = new StorageRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Storage = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if (Storage == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
