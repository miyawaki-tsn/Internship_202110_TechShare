using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TechShare.Models
{
    public class task
    {

        public int Id { get; set; }

        [DisplayName("タスク完了フラグ")]
        public int IsCompleted { get; set; }

        //TaskからUser参照
        [DisplayName("ユーザー")]
        public virtual User User { get; set; }

        //Taskからchat参照
        [DisplayName("チャット")]
        public virtual chat Chat { get; set; }

    }
}