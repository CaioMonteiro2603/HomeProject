using HomeProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace HomeProject.Filters
{
    public class PageOnlyAdmin : ActionFilterAttribute // filtro do importado do mvc
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userSession = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if(string.IsNullOrEmpty(userSession) )
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { 
                    { "controller", "Login" }, {"action", "Index" }  // se for nulo, direcionará para o controler login, açao index 
                });
            } else
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "controller", "Login" }, {"action", "Index" }  
                });
                }

                if(user.Login != "caio123")
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "controller", "Restrict" }, {"action", "Index" } 
                });
                }
            }

            base.OnActionExecuting(context); // pega todo o código base do filter e executa 
        }
    }
}
