using Businness.Model;
using Businness.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace QuizCreateApp.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            var userToLogin = _accountService.Login(loginModel);
            if (!userToLogin.isSuccess)
            {
                loginModel.ErrorMessage = userToLogin.message;
                return View("Index", loginModel);
            }
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, loginModel.Email));
            claims.Add(new Claim("userid", userToLogin.Data.Id.ToString()));

            var userIdentity = new ClaimsIdentity(claims, "login");

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("QuizList", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserRegisterModel userRegisterModel)
        {
            var userExists = _accountService.UserExists(userRegisterModel.Email);
            if (!userExists.isSuccess)
            {
                userRegisterModel.ErrorMessage = userExists.message;
                return View("Register", userRegisterModel);
            }

            var registerResult = _accountService.Register(userRegisterModel, userRegisterModel.Password);

            if (registerResult.isSuccess)
            {
                userRegisterModel.IsSuccess = true;
                return View("Register", userRegisterModel); 
            }
            else
            {
                userRegisterModel.ErrorMessage = registerResult.message;
                return View("Register", userRegisterModel);
            }

        }
    }
}
