using HomeProject.Models;

namespace HomeProject.Repository.Interface
{
    public interface IUserRepository
    {
        public IList<UserModel> FindAll();

        public UserModel FindById(int id);

        public UserModel FindByLogin(string login); 

        public UserModel Update(UserModel userModel);

        public int Insert(UserModel userModel);

        public bool Delete(int id);
    }
}
