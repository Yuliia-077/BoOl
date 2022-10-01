using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Domain;
using Microsoft.AspNetCore.Authorization;
using BoOl.Repository;
using BoOl.Persistence.DatabaseContext;

namespace BoOl.Pages.Storages
{
    //повна інформація по постачанню
    [Authorize(Roles = "Owner, Administrator, Technician,  Storekeeper")]
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

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
