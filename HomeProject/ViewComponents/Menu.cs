using HomeProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HomeProject.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(userSession)) return null;

            UserModel userModel = JsonConvert.DeserializeObject<UserModel>(userSession);

            return View(userModel); // se nao informa nome para view, ele pega a default do componente menu
        }
    }
}
