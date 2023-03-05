using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class ListOfFriendsView
    {        
        IUserRepository userRepository;

        public ListOfFriendsView()
        {            
            userRepository = new UserRepository();
        }
        public void Show(IEnumerable<Friend> myFriends)
        {
            Console.WriteLine("Мои друзья:");

            myFriends.ToList().ForEach(f =>
            {
                var friendEntity = userRepository.FindById(f.Friend_Id);
                Console.WriteLine(friendEntity.email);
            });
        }
    }
}
