using Domain;
using Microsoft.EntityFrameworkCore;
using Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositry
{
    public class ActivityRepository(AppDbContext dbContext) : IActivityRepositry
    {
        

        public async Task<List<Activity>> GetActivitiesAsync()
        {
             return await dbContext.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(string id)
        {
            return await dbContext.Activities.FindAsync(id);
           
        }

        public async Task AddActivityAsync(Activity activity)
        {
            await dbContext.Activities.AddAsync(activity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
            dbContext.Activities.Update(activity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteActivityAsync(Activity activity)
        {
            dbContext.Activities.Remove(activity);
            await dbContext.SaveChangesAsync();
           
        }
    }
}
