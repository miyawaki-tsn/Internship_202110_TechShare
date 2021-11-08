using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TechShare.Models
{
    public class chat
    {
        public int Id { get; set; }

        [DisplayName("投稿時間")]
        [DataType(DataType.DateTime)]
        public DateTime Time{ get; set; }

        [DisplayName("テキスト")]
        [DataType(DataType.Text)]
        public string Text { get; set; }

        [DisplayName("ファイル")]
        [DataType(DataType.Upload)]
        public int File { get; set; }

        //chatからUser参照
        [DisplayName("ユーザー")]
        public virtual User User { get; set; }

        //chatからGroup参照
        [DisplayName("グループ")]
        public virtual Group Group { get; set; }
    }
}