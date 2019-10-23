using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TweetSharp;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace twitterIntegrationApp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : Controller
    {
        
        // GET: api/<controller>
        [HttpGet]
        public String[] Get()
        {
            return  new string[] { "Ready to search for some tweets?"};
        }

        // GET api/<controller>/5
        [HttpGet("{userName}")]
        public string[] Get(string userName)
        {          
           // var token = config.ConsumerKey;
            var twitterClientInfo = new TwitterClientInfo
            {
                ConsumerKey = Startup.twitterConfig["ConsumerKey"],
                ConsumerSecret = Startup.twitterConfig["ConsumerSecret"]
            };
            TwitterService service = new TwitterService(twitterClientInfo);
            service.AuthenticateWith(Startup.twitterConfig["Token"], Startup.twitterConfig["TokenSecret"]);
            ListTweetsOnUserTimelineOptions options = new ListTweetsOnUserTimelineOptions();
            options.ScreenName = userName;
            options.Count = 50;
            options.IncludeRts = false;
            options.ExcludeReplies = true;
            var response = service.ListTweetsOnUserTimeline(options).ToList();
            string[] tweets = new string[response.Count];
            for (int i = 0; i < response.Count; i++)
            {
                tweets[i] = response[i].TextAsHtml;
            }
            return tweets;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
