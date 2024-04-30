using HomeProject.Helper.Interface;
using HomeProject.Models;
using Newtonsoft.Json;

namespace HomeProject.Helper
{
    public class Sessionn : Interface.ISessionn
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Sessionn(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void CreateUserSession(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user); //transforma um objeto em uma strig para colocar no SetString
            _httpContextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", value); 
        }

        public UserModel FindUserSession()
        {
            string userSession = _httpContextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<UserModel>(userSession); //transforma uma string em objeto 
        }

        public void RemoveUserSession()
        {
            _httpContextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado"); 
        }
    }
}
