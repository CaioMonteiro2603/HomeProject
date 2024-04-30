using HomeProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace HomeProject.Filters
{
    public class PageUserLogin : ActionFilterAttribute // filtro do importado do mvc
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userSession = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if(string.IsNullOrEmpty(userSession) )
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { 
                    { "controller", "login" }, {"action", "index" }  // se for nulo, direcionará paa essas 4 rotas (usando o metodo dictionary
                });
            } else
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "controller", "login" }, {"action", "index" }  // se for nulo, direcionará paa essas 4 rotas (usando o metodo dictionary
                });
                }
            }

            base.OnActionExecuting(context); // pega todo o código base do filter e executa 
        }
    }
}
