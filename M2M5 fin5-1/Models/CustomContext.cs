using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace M2M5_fin5_1.Models
{
    public class CustomContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CustomContext() : base("name=CustomContext")
        {
            Database.SetInitializer<CustomContext>(new DropCreateDatabaseIfModelChanges<CustomContext>());

        }

        public System.Data.Entity.DbSet<M2M5_fin5_1.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<M2M5_fin5_1.Models.Assignment> Assignments { get; set; }

        public System.Data.Entity.DbSet<M2M5_fin5_1.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<M2M5_fin5_1.Models.Grade> Grades { get; set; }
    }
}
