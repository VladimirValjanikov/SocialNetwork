using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int User_Id { get; }
        public int Friend_Id { get; }

        public Friend(int id, int user_id, int friend_id) 
        {
            Id = id;
            User_Id = user_id;
            Friend_Id = friend_id;
        }
    }
}
