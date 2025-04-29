using Application.Repositry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistance;

namespace API.Controllers
{

    public class ActivitiesController(IActivityRepositry activityRepositry) : BaseApiController
    {

        [HttpGet]
       
        public async Task<ActionResult<List<Domain.Activity>>> GetActivities()
        {
            return await activityRepositry.GetActivitiesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Activity>> GetActivity(string id)
        {
            var activity = await activityRepositry.GetActivityByIdAsync(id);

            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        [HttpPost]

        public async Task<ActionResult> CreateActivity([FromBody] Domain.Activity activity)
        {
            await activityRepositry.AddActivityAsync(activity);
            return Ok(activity);


        }

        [HttpPut("{Id}")]

        public async Task<ActionResult> EditActivity(string Id, [FromBody]Domain.Activity activity)
        {
            var exitising = await activityRepositry.GetActivityByIdAsync(Id);
            if(exitising == null) return NotFound();

            await activityRepositry.UpdateActivityAsync(exitising);
            return Ok(activity);

        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteActivity(string Id)
        {
            var existing = await activityRepositry.GetActivityByIdAsync(Id);
            if (existing == null) return NotFound();

            await activityRepositry.DeleteActivityAsync(existing);

            return Ok();
        }

    }

}
