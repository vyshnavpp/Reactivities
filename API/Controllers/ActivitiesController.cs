using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _dataContext;
        public ActivitiesController(DataContext dataContext)
        {
            _dataContext = dataContext;
   
        }

        [HttpGet] // api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _dataContext.Activities.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")] // api/activities/{id}
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _dataContext.Activities.FindAsync(id);
        }
    }
}