using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoOl.Models;
using BoOl.Repository;
using BoOl.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BoOl.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly WorkerRepository _repository;
        [BindProperty]
        public RegisterViewModel RegisterUser { get; set; }

        public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager, BoOlContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = new WorkerRepository(context);
        }
        public async Task<IActionResult> OnGet()
        {
            ViewData["WorkerId"] = new SelectList(await _repository.SelectAsync(), "Value", "Text");
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = RegisterUser.Email, UserName = RegisterUser.Email, WorkerId = RegisterUser.WorkerId };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, RegisterUser.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("/Index");
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
