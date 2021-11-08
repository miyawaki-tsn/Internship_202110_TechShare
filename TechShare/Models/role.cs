using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechShare.Models
{
    public class role
    {
        //役職Idの定義
        public int Id { get; set; }

        //役職名の定義
        [DisplayName("役職")]
        public string Name { get; set; }
    }
}