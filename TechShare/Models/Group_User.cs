using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechShare.Models
{
    //グループユーザー
    public class Group_User
    {
        //グループユーザーID
        public int Id { get; set; }

        //グループユーザー内のグループID
        public int Group_Id { get; set; }
        
        //グループユーザー内のユーザーID
        public int User_Id { get; set; }

        //グループを参照
        public virtual Group Groups { get; set; }

        //ユーザーを参照
        public virtual User Users { get; set; }

    }
}