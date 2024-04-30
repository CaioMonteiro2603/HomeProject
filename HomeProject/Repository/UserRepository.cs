using HomeProject.Data;
using HomeProject.Models;
using HomeProject.Repository.Interface;

namespace HomeProject.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public IList<UserModel> FindAll()
        {
            var user = _context.User.ToList();

            return user; 
        }

        public UserModel FindById(int id)
        {
            var user = _context.User.FirstOrDefault(user => user.UserId == id);

            return user;
        }

        public UserModel FindByLogin(string login)
        {
            var user = _context.User.FirstOrDefault(l => l.Login.ToUpper() == login.ToUpper());

            return user; 
        }

        public int Insert(UserModel userModel)
        {
            _context.User.Add(userModel);
            _context.SaveChanges(); 

            return userModel.UserId; 
        }

        public UserModel Update(UserModel userModel)
        {
            UserModel userDB = FindById(userModel.UserId);

            if (userDB == null) throw new Exception("Error, the user is null"); 

            userDB.UserName = userModel.UserName;
            userDB.UserLastName = userModel.UserLastName;
            userDB.UserEmail = userModel.UserEmail;
            userDB.Login = userModel.Login; 

            _context.User.Update(userDB);
            _context.SaveChanges();

            return userDB;  
        }

        public bool Delete(int id)
        {
            var user = FindById(id);

            if (user == null) throw new Exception("Error, the user is null"); 

            _context.User.Remove(user);
            _context.SaveChanges();

            return true; 
        }
    }
}
