using BoOl.Application.Services.Positions;
using BoOl.Application.Validations.Positions;
using BoOl.Models.Positions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Pages.Workers
{
    //перелік працівників поділених по посадах
    [Authorize(Roles = "Owner, Administrator")]
    public class IndexModel : PageModel
    {
        private readonly IPositionService _positionService;
        private readonly IPositionValidation _positionValidation;

        public IList<PositionListItem> Positions { get; set; }

        [BindProperty(SupportsGet = true)]
        public PositionListItemQuery Query { get; set; }

        public IndexModel(IPositionService positionService,
            IPositionValidation positionValidation)
        {
            _positionService = positionService ?? throw new ArgumentNullException(nameof(positionService));
            _positionValidation = positionValidation ?? throw new ArgumentNullException(nameof(positionValidation));
        }

        public async Task OnGetAsync()
        {
            if(Query?.IsActive == null)
            {
                Query.IsActive = true;
            }

            var items = await _positionService.GetListAsync(Query.Filter, Query.IsActive.Value);
            Positions = items.Select(x => x.AsViewModel()).ToList();
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var error = await _positionValidation.ValidationForDelete(id);
            if (error != null)
            {
                ModelState.AddModelError("Positions", error);
            }

            if (!ModelState.IsValid)
            {
                if (Query?.IsActive == null)
                {
                    Query.IsActive = true;
                }

                var items = await _positionService.GetListAsync(Query.Filter, Query.IsActive.Value);
                Positions = items.Select(x => x.AsViewModel()).ToList();
                return Page();
            }

            await _positionService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
