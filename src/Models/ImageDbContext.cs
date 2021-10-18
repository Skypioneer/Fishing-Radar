using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public class ImageDbContext:DbContext
    {
        public ImageDbContext(DbContextOptions<ImageDbContext> options):base(options)
        {
            /*options will hold what type of DB we are using*/
            /*And what kind of DB connection string we are using*/

        }


        /*Handle migration of DB*/
        public DbSet<ImageModel> Images { get; set; }
    }
}
