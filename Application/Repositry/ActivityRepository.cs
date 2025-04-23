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
        public Task AddActivityAsync(Activity activity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Activity>> GetActivitiesAsync()
        {
             return await dbContext.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(string id)
        {
            return await dbContext.Activities.FindAsync(id);
           
        }
    }
}
