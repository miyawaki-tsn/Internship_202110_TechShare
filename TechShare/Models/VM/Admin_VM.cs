using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TechShare.Models.VM
{
    public class Admin_VM
    {
        [DisplayName("アイコン")]
        public string UserIcon { get; set; }

        [DisplayName("名前")]
        public string UserName { get; set; }

        [DisplayName("グループに追加")]
        public string UserIDLabel { get; set; }

        [DisplayName("ユーザーグループID")]
        public string UserGroupID { get; set; }

        [DisplayName("ユーザーID")]
        public string UserID { get; set; }

        public ICollection<User> user{get; set;}

        public Group group { get; set; }

        public ICollection<Group_User> group_user { get; set; }
  }
}