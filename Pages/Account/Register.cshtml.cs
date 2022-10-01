using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using BoOl.Repository;
using BoOl.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BoOl.Pages.Account
{
    // реєстрація нового користувача
    [Authorize (Roles = "Owner, Administrator")]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly WorkerRepository _repository;
        [BindProperty]
        public RegisterViewModel RegisterUser { get; set; }

        public RegisterModel(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, BoOlContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _repository = new WorkerRepository(context);
        }
        public IActionResult OnGet(int? id)
        {
            if(id!=null)
            {
                RegisterUser = new RegisterViewModel();
                RegisterUser.WorkerId = Convert.ToInt32(id);
                RegisterUser.AllRoles = _roleManager.Roles.ToList();
                return Page();
            }
            return NotFound();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = RegisterUser.Email, UserName = RegisterUser.Email, WorkerId = RegisterUser.WorkerId };
                var result = await _userManager.CreateAsync(user, RegisterUser.Password);
                if (result.Succeeded)
                {

                    await _userManager.AddToRolesAsync(user, RegisterUser.UserRoles);
                    return RedirectToPage("/Workers/Details", new { id = RegisterUser.WorkerId});
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Page();
        }
    }
}
