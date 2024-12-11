using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain
{
    public class UserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly List<User> _users;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _users = _userRepository.GetUsers();
        }

        public List<User> GetUsers() { 
            return _users; 
        }

        public bool ValidateUser(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            Console.WriteLine(user.Username);
            Console.WriteLine(user.Id);
            Console.WriteLine(user.Password);
            return (user.Password == password);
        }

        public void RegisterUser(string username, string password)
        {
            _userRepository.CreateUserInDb(username, password);
        }

        public bool CreateUser(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null) {

                _userRepository.CreateUserInDb(username, password);

                return true;
            }

            return false;
        }
    }
}
