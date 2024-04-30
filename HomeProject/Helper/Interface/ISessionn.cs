using HomeProject.Models;

namespace HomeProject.Helper.Interface
{
    public interface ISessionn
    {
        public void CreateUserSession(UserModel user);
        public void RemoveUserSession();
        public UserModel FindUserSession();
    }
}
