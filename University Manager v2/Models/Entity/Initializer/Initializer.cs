using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using University_Manager_v2.Models.Entity.Models;

namespace University_Manager_v2.Models.Entity.Initializer
{
    public class Initializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Groups.Add(new Group { Name = "22-O" });
            context.Groups.Add(new Group { Name = "11-O" });
            context.Groups.Add(new Group { Name = "23-IP" });
            context.Groups.Add(new Group { Name = "41-Z" });
            context.Groups.Add(new Group { Name = "5-O" });
            base.Seed(context);
        }
    }
}