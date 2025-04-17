using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistance;
using System.Diagnostics;
using Domain;

namespace API.Controllers
{

    public class ActivitiesController : BaseApiController
    {
        private readonly AppDbContext dbContext;

        public ActivitiesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
       
        public async Task<ActionResult<List<Domain.Activity>>> GetActivities()
        {
            return await dbContext.Activities.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Activity>> GetActivity(string id)
        {
            var activity = await dbContext.Activities.FindAsync(id);

            if (activity == null) return NotFound();
           
            //comment
            return activity;
        }
    }

}
