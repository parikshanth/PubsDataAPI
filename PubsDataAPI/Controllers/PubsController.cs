using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubsDataAPI.DbContexts;
using PubsDataAPI.Models;

namespace PubsDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PubsController : ControllerBase
    {

        private readonly PubsDbContext pubsDbContext;
        private readonly ILogger<PubsController> logger;

        public PubsController(PubsDbContext pubsDbContext, ILogger<PubsController> logger)
        {
            this.pubsDbContext = pubsDbContext;
            this.logger = logger;
        }


        //I know this is not correct Rest, just testing out the db contexts

        [HttpGet]
        [Route("GetAuthors")]
        public IQueryable<Author> GetAuthors()
        {
            return pubsDbContext.Authors;
        }

        [HttpGet]
        [Route("GetPublishers")]
        public IQueryable<Publisher> GetPublishers()
        {
            return pubsDbContext.Publishers;
        }

        [HttpGet]
        [Route("GetTitles")]
        public IQueryable<Title> GetTitles()
        {
            return pubsDbContext.Titles;
        }
    }
}
