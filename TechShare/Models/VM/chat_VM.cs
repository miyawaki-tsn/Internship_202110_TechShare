using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechShare.Models.VM
{
    public class chat_VM
    {
        public chat_VM()
        {
            Groups = new Group();
        }

        public Group Groups { get; set; }

        public ICollection<chat> Chats { get; set; }

        public Group_User Group_Users { get; set; }

        public User Users { get; set; }
    }
}