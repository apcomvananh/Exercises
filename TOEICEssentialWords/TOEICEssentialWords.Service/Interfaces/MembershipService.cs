using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Service.Interfaces
{
    public interface MembershipService
    {
        bool ValidateUser(string username, string password);

        string[] GetRolesForUser(string username);

        User GetUser(int id);

        User GetUser(string username);

        void CreateUser(User user);

        void AddWordToWordList(string username, Word word);
    }
}