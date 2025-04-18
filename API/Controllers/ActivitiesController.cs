using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistance;
using System.Diagnostics;
using Domain;
using MediatR;
using Application.Activities.Queries;

namespace API.Controllers
{

    public class ActivitiesController(AppDbContext dbContext, IMediator mediator) : BaseApiController
    {
        //private readonly AppDbContext dbContext;

        //public ActivitiesController(AppDbContext dbContext,IMediator mediator)
        //{
        //    this.dbContext = dbContext;
        //}

        [HttpGet]
       
        public async Task<ActionResult<List<Domain.Activity>>> GetActivities()
        {
            return await mediator.Send(new GetActivityList.Query());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Activity>> GetActivity(string id)
        {
            var activity = await dbContext.Activities.FindAsync(id);

            if (activity == null) return NotFound();
           
            //comment
            //aa
            return activity;
        }
    }

}
