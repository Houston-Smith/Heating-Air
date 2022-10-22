using Claud.Models;
using System.Collections.Generic;

namespace Claud.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        void UpdateUserProfile(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        List<UserProfile> GetAllUsers();
        UserProfile GetByUserId(int userId);
    }
}
