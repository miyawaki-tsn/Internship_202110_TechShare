using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TechShare.Data
{
    public class TechShareContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TechShareContext() : base("name=TechShareContext")
        {
        }

        public System.Data.Entity.DbSet<TechShare.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<TechShare.Models.role> roles { get; set; }

        public System.Data.Entity.DbSet<TechShare.Models.chat> chats { get; set; }

        public System.Data.Entity.DbSet<TechShare.Models.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<TechShare.Models.Group_User> Group_User { get; set; }

        public System.Data.Entity.DbSet<TechShare.Models.task> tasks { get; set; }

        //public System.Data.Entity.DbSet<TechShare.Models.VM.chat_VM> chat_VM { get; set; }
    }
}
