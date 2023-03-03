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
    public class MessageSendingView
    {
        MessageService messageService;
        public MessageSendingView(MessageService messageService) 
        {            
            this.messageService = messageService;
        }

        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();

            Console.WriteLine("Введите почтовый адрес получателя:");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.WriteLine("Введите сообщение (не более 5000 символов):");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;

            try
            {
                messageService.SendMessage(messageSendingData);

                SuccessMessage.Show("Сообщение отправлено!");                                    
            }
            catch (UserNotFoundException) 
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }
            catch (Exception) 
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
            }
        }
    }
}
