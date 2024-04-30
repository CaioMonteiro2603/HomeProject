using HomeProject.Filters;
using HomeProject.Models;
using HomeProject.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeProject.Controllers
{
    [PageOnlyAdmin]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userController = _userRepository.FindAll();

            return View(userController);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel userModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _userRepository.Insert(userModel);
                    TempData["SucessMessage"] = "User's insert is done!";
                    return RedirectToAction(nameof(Index));
                }

                return View(userModel); 
            } catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong, details about error: {ex.Message}";
                return RedirectToAction(nameof(Index)); 
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userController = _userRepository.FindById(id);

            if(userController == null)
            {
                return NotFound();
            }

            return View(userController);
        }

        [HttpPost]
        public IActionResult Edit(UserModelWithoutPassword userModelWithoutPassword)
        {
            try
            {
                UserModel user = null;

                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        UserId = userModelWithoutPassword.Id,
                        UserName = userModelWithoutPassword.Name,
                        UserLastName = userModelWithoutPassword.LastName,
                        UserEmail = userModelWithoutPassword.Email, 
                        Login = userModelWithoutPassword.Login
                    };

                    user = _userRepository.Update(user);
                    return RedirectToAction(nameof(Index));
                }
                return View(user); 
            } catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index)); 
            }
             
        }

        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            var userController = _userRepository.FindById(id);

            return View(userController); 
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                bool delete = _userRepository.Delete(id);

                if(delete)
                {
                    TempData["SucessMessage"] = "User was deleted!";
                    
                }
                else
                {
                    TempData["ErrorMessage"] = "The user doesn't exist";
                     
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong about user's delete. The explanation: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
