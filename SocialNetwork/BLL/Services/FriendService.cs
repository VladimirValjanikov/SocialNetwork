using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public IEnumerable<Friend> GetListOfFriends(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var friendEntity = userRepository.FindById(f.friend_id);
                var userEntity = userRepository.FindById(f.user_id);

                friends.Add(new Friend(f.id, userEntity.id, friendEntity.id));
            });
               
            return friends;
        }

        public void AddFriend(FriendAddingData friendAddingData)
        {
            if (string.IsNullOrEmpty(friendAddingData.FriendEmail))
                throw new ArgumentNullException();
            
            var findFriendEntity = userRepository.FindByEmail(friendAddingData.FriendEmail);
            if (findFriendEntity is null) throw new UserNotFoundException();

            var findUserEntity = userRepository.FindById(friendAddingData.User_Id);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = findUserEntity.id,
                friend_id = findFriendEntity.id
            };

            if(friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
