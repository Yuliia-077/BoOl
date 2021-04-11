using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoOl.Models;
using BoOl.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoOl.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        [BindProperty]
        public LoginViewModel LoginView { get; set; }

        public LoginModel(UserManager<User> userManager, SignInManager<User> signInManager, BoOlContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult OnGet(string returnUrl = null)
        {
            LoginView = new LoginViewModel();
            LoginView.ReturnUrl = returnUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(LoginView.Email, LoginView.Password, LoginView.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(LoginView.ReturnUrl) && Url.IsLocalUrl(LoginView.ReturnUrl))
                    {
                        return Redirect(LoginView.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToPage("/Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильний логін і (або) пароль!");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnGetLogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("Login");
        }
    }
}
