using BoOl.Application.Services.Models;
using BoOl.Application.Validations.Models;
using BoOl.Models;
using BoOl.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Pages.Types
{
    //перелік всіх моделей
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IModelService _modelService;
        private readonly IModelValidation _modelValidation;
        private readonly int _pageSize = 7;

        public IndexModel(IModelService modelService,
            IModelValidation modelValidation)
        {
            _modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
            _modelValidation = modelValidation ?? throw new ArgumentNullException(nameof(modelValidation));
        }

        public int CountOfModels { get; set; }
        public int TotalPages { get; private set; }
        public IList<ModelListItem> Models { get; set; }

        [BindProperty(SupportsGet = true)]
        public ListQuery Query { get; set; }

        public async Task OnGetAsync()
        {
            if(Query.CurrentPage == default(int))
            {
                Query.CurrentPage = 1;
            }

            CountOfModels = await _modelService.Count(Query.Filter);
            var models = await _modelService.GetListItems(Query.CurrentPage, _pageSize, Query.Filter);

            TotalPages = (int)Math.Ceiling(decimal.Divide(CountOfModels, _pageSize));
            Models = models.Select(x => x.AsViewModel()).ToList();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var error = await _modelValidation.ValidationForDelete(id);
            if (error != null)
            {
                ModelState.AddModelError("All", error);
            }

            if (!ModelState.IsValid)
            {
                CountOfModels = await _modelService.Count(null);
                var models = await _modelService.GetListItems(1, _pageSize, null);

                TotalPages = (int)Math.Ceiling(decimal.Divide(CountOfModels, _pageSize));
                Models = models.Select(x => x.AsViewModel()).ToList();
                return Page();
            }

            await _modelService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
