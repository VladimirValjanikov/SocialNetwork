using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    class Program
    {
        static UserService userService;
        static MessageService messageService;
        static FriendService friendService;
        public static AuthenticationView authenticationView;
        public static RegistrationView registrationView;
        public static UserMenuView userMenuView;
        public static MainView mainView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static MessageSendingView messageSendingView;
        public static FriendAddingView friendAddingView;
        public static ListOfFriendsView listOfFriendsView;

        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();
            friendService = new FriendService();

            authenticationView = new AuthenticationView(userService);
            registrationView = new RegistrationView(userService);
            userMenuView = new UserMenuView(userService);
            mainView = new MainView();
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            userOutcomingMessageView = new UserOutcomingMessageView();
            userIncomingMessageView = new UserIncomingMessageView();
            messageSendingView = new MessageSendingView(messageService);
            friendAddingView = new FriendAddingView(friendService);
            listOfFriendsView = new ListOfFriendsView();

            while (true)
            {
                mainView.Show();
            }                                 
        }
    }
}