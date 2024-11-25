using UserLinkService.Models;

namespace UserLinkService.Repositories.Interfaces
{
    public interface IUserLinkRepository
    {
        bool Create(UserLink userlink);
        UserLink GetUserLink(int id);
        List<UserLink> GetAll();
        bool Update(int id, UserLink userlink);
        bool Delete(int id);
        bool GenerateNewLink(UserLink userlink);
        UserLink GetUserLinkFromNewLink(string newuserlink);
    }
}