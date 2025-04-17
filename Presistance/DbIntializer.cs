using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance
{
    public class DbIntializer
    {
        public static async Task SeedData(AppDbContext context)
        {
            if (context.Activities.Any()) return;

            var activities = new List<Activity>
            {
                    new Activity
                    {
                        Title = "Tech Conference 2025",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "A conference focusing on the latest trends in technology.",
                        Category = "Conference",
                        IsCancelled = false,
                        City = "Bengaluru",
                        Venue = "Bangalore International Exhibition Centre",
                        Latitude = 12.9716,
                        Longitude = 77.5946
                    },
                    new Activity
                    {
                        Title = "Music Fest 2025",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "An annual music festival featuring top artists.",
                        Category = "Festival",
                        IsCancelled = false,
                        City = "Mumbai",
                        Venue = "Jio Garden",
                        Latitude = 19.0760,
                        Longitude = 72.8777
                    },
                    new Activity
                    {
                        Title = "Startup Meetup",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Networking event for entrepreneurs and startups.",
                        Category = "Networking",
                        IsCancelled = false,
                        City = "Delhi",
                        Venue = "The Lalit Hotel",
                        Latitude = 28.6139,
                        Longitude = 77.2090
                    }
            };

            context.Activities.AddRange(activities);

            await context.SaveChangesAsync();
        }
    }
}
