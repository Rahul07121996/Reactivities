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

        //[HttpPost]

        //public async Task<ActionResult<string>> CreateActivity(Domain.Activity activity)
        //{
        //   return  await mediator.Send(new CreateActivity.Command { Activity = activity });


        //}

        //[HttpPut]

        //public async Task<ActionResult> EditActivity(Domain.Activity activity)
        //{
        //     await mediator.Send(new EditActivity.Command { Activity = activity });

        //    return NoContent();

        //}
        //[HttpDelete]
        //public async Task<ActionResult> DeleteActivity(string id)
        //{
        //    await mediator.Send(new DeleteActivity.Command { Id = id });

        //    return Ok();
        //}

    }

}
