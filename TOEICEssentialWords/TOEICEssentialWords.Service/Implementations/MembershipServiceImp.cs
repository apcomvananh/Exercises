using System.Collections.Generic;
using System.Linq;
using TOEICEssentialWords.Data.Infrastructure;
using TOEICEssentialWords.Data.Repositories;
using TOEICEssentialWords.Model;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Service.Utils;

namespace TOEICEssentialWords.Service.Implementations
{
    public class MembershipServiceImp : MembershipService
    {
        private UnitOfWork _unitOfWork;
        private BaseRepository<User> _userRepository;
        private BaseRepository<Role> _roleRepository;

        public MembershipServiceImp(UnitOfWork unitOfWork,
            BaseRepository<User> userRepository,
            BaseRepository<Role> roleRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public void CreateUser(User user)
        {
            var salt = StringUtils.CreateSalt(AppConstants.SaltSize);
            var hash = StringUtils.GenerateSaltedHash(user.Password, salt);
            user.Password = hash;
            user.Salt = salt;
            _userRepository.Add(user);
            _unitOfWork.Commit();
        }

        public string[] GetRolesForUser(string username)
        {
            var roles = new List<string>();
            var user = GetUser(username);

            if (user != null)
            {
                roles.AddRange(user.Roles.Select(r => r.Name));
            }

            return roles.ToArray();
        }

        public User GetUser(string username)
        {
            var user = _userRepository.AllIncluding(u => u.Roles)
                .FirstOrDefault(u => u.UserName.Equals(username));
            return user;
        }

        public User GetUser(int id)
        {
            var user = _userRepository.AllIncluding(u => u.Roles)
                .FirstOrDefault(u => u.Id == id);
            return user;
        }

        public bool ValidateUser(string username, string password)
        {
            var user = GetUser(username);

            if (user != null)
            {
                var salt = user.Salt;
                var hash = StringUtils.GenerateSaltedHash(password, salt);

                if (user.Password == hash)
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}