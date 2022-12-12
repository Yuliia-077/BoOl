using BoOl.Application.Services.Users;
using BoOl.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Pages.Account
{
    // реєстрація нового користувача
    [Authorize (Roles = "Owner, Administrator")]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public RegisterViewModel RegisterUser { get; set; }
        public IList<string> AllRoles { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if(id.HasValue)
            {
                RegisterUser = new RegisterViewModel();
                RegisterUser.WorkerId = id.Value;
                AllRoles = await _userService.GetAllRoleName();
                return Page();
            }
            return NotFound();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {   
            if(RegisterUser.UserRoles != null)
            {
                var result = await _userService.CreateUser(RegisterUser.AsDto());
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Оберіть роль!");
            }


            if (!ModelState.IsValid)
            {

                AllRoles = await _userService.GetAllRoleName();
                return Page();
            }

            return RedirectToPage("./Details", new { id = RegisterUser.WorkerId });
        }
    }
}
