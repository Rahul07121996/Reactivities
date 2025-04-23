using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositry
{
     public interface IActivityRepositry
    {
        Task<List<Activity>> GetActivitiesAsync();
        Task<Activity> GetActivityByIdAsync(string id);
        Task AddActivityAsync(Activity activity);
        //Task UpdateActivityAsync(Activity activity);
        //Task DeleteActivityAsync(int id);
    }
}
