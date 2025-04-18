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
            },
            new Activity
            {
                Title = "AI Workshop",
                Date = DateTime.Now.AddMonths(1),
                Description = "Hands-on workshop on Artificial Intelligence and Machine Learning.",
                Category = "Workshop",
                IsCancelled = false,
                City = "Hyderabad",
                Venue = "IIIT Hyderabad",
                Latitude = 17.3850,
                Longitude = 78.4867
            },
            new Activity
            {
                Title = "Blockchain Seminar",
                Date = DateTime.Now.AddMonths(3),
                Description = "Seminar discussing the future of blockchain technology.",
                Category = "Seminar",
                IsCancelled = false,
                City = "Chennai",
                Venue = "IIT Madras",
                Latitude = 13.0827,
                Longitude = 80.2707
            },
            new Activity
            {
                Title = "Digital Marketing Summit",
                Date = DateTime.Now.AddMonths(5),
                Description = "Summit on the latest trends in digital marketing.",
                Category = "Summit",
                IsCancelled = false,
                City = "Kolkata",
                Venue = "Science City",
                Latitude = 22.5726,
                Longitude = 88.3639
            },
            new Activity
            {
                Title = "Robotics Expo",
                Date = DateTime.Now.AddMonths(6),
                Description = "Exhibition showcasing the latest advancements in robotics.",
                Category = "Exhibition",
                IsCancelled = false,
                City = "Pune",
                Venue = "Bharati Vidyapeeth",
                Latitude = 18.5204,
                Longitude = 73.8567
            },
            new Activity
            {
                Title = "Cybersecurity Bootcamp",
                Date = DateTime.Now.AddMonths(7),
                Description = "Bootcamp focusing on cybersecurity skills and certifications.",
                Category = "Bootcamp",
                IsCancelled = false,
                City = "Noida",
                Venue = "Jaypee Institute of Information Technology",
                Latitude = 28.5355,
                Longitude = 77.3910
            },
            new Activity
            {
                Title = "IoT Expo",
                Date = DateTime.Now.AddMonths(9),
                Description = "Expo highlighting innovations in the Internet of Things.",
                Category = "Expo",
                IsCancelled = false,
                City = "Gurugram",
                Venue = "DLF CyberHub",
                Latitude = 28.4595,
                Longitude = 77.0266
            },
            new Activity
            {
                Title = "Cloud Computing Conference",
                Date = DateTime.Now.AddMonths(10),
                Description = "Conference discussing the future of cloud computing.",
                Category = "Conference",
                IsCancelled = false,
                City = "Bengaluru",
                Venue = "NIMHANS Convention Centre",
                Latitude = 12.9716,
                Longitude = 77.5946
            }
            };

            context.Activities.AddRange(activities);

            await context.SaveChangesAsync();
        }
    }
}
