using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presistance
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public required DbSet<Activity> Activities { get; set; }  
    }
}
