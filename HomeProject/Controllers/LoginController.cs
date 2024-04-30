using HomeProject.Helper.Interface;
using HomeProject.Models;
using HomeProject.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionn _sessionn; 
        public LoginController(IUserRepository userRepository, ISessionn sessionn)
        {
            _userRepository = userRepository;
            _sessionn = sessionn;
        }
        public IActionResult Index()
        {
            // se o usuario estiver logado, redirecione para a home
            // nao permite voltar para a tela de login sem fazer logout

            if(_sessionn.FindUserSession() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult LogOut()
        {
            _sessionn.RemoveUserSession();
            return RedirectToAction("Index", "Home"); 
        }
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UserModel userModel = _userRepository.FindByLogin(loginModel.Login);
                    if (userModel != null)
                    {
                        if (userModel.SenhaValida(loginModel.Password))
                        {
                            _sessionn.CreateUserSession(userModel); 
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["ErrorMessage"] = "Invalid password, try again!";
                    }

                    TempData["ErrorMessage"] = "Invalid user and/or password. Try again!";
                }
                return View("Index");

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error has been detected. More about the error: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }

            
        }
    }
}
