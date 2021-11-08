using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TechShare.Models
{
    public class User
    {
        //UserIDの定義
        public int Id { get; set; }

        //氏名の定義
        [DisplayName("氏名")]
        public string Name { get; set; }

        //パスワードの定義
        [DisplayName("パスワード")]
        [DataType(DataType.Password)]
        public string password { get; set; }

    //役職IDの定義
    //[DisplayName("役職ID")]
    //public int roleId { get; set; }

    //iconの定義
    [DisplayName("アイコン")]
        public byte icon { get; set; }

        //user削除のフラグの定義
        public int deleteflg { get; set; }

        //役職Idクラスとの関係
        public virtual role Role { get; set; }

        //chatクラスとの関係
        public virtual ICollection<chat> Chats { get; set; }

        //taskクラスとの関係
        public virtual ICollection<task> Tasks { get; set; }

        //Group_Userクラスとの関係
        public virtual ICollection<Group_User> Group_Users { get; set; }

    }
}