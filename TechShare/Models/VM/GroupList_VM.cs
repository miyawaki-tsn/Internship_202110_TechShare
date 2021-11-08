using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechShare.Models
{
    public class GroupList_VM
    {
        //グループId
        public int Id { get; set; }

        //グループ名
        public string name { get; set; }

        //グループアイコン
        public string icon { get; set; }

        //グループユーザーの参照
        public virtual ICollection<Group_User> Group_Users { get; set; }

    }

}