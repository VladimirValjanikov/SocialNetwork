using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddingView
    {
        FriendService friendService;
        public FriendAddingView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var friendAddingData = new FriendAddingData();

            Console.WriteLine("Введите email пользователя:");
            friendAddingData.FriendEmail = Console.ReadLine();

            friendAddingData.User_Id = user.Id;

            try
            {
                friendService.AddFriend(friendAddingData);

                SuccessMessage.Show("Вы добавили нового друга!");                
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (Exception) 
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга!");
            }
        }
    }
}
