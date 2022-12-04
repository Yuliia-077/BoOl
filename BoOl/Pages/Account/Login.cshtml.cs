using BoOl.Application.Services.Users;
using BoOl.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BoOl.Pages.Account
{
    //��������������
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        [BindProperty]
        public LoginViewModel LoginView { get; set; }

        public LoginModel(IUserService userService)
        {
            _userService = userService;
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
                if (await _userService.LogIn(LoginView.AsDto()))
                {
                    // ���������o, �� �������� URL �������
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
                    ModelState.AddModelError("", "������������ ���� � (���) ������!");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnGetLogOut()
        {
            await _userService.LogOut();
            return RedirectToPage("Login");
        }
    }
}
