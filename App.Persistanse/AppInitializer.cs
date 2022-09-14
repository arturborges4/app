using App.Persistanse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistense
{
    internal class AppInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var initializer = new AppInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(AppDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
