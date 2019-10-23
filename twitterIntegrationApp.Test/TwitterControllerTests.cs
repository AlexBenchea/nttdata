using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using NUnit.Framework;
using TweetSharp;

namespace twitterIntegrationApp
{
    [TestFixture, System.Runtime.InteropServices.GuidAttribute("DD654DE5-566A-4DAB-A675-7AD6C998F4B9")]
    public  class TwitterControllerTests
    {
        private readonly string _hero= "SenatorTester";
        private readonly string _consumerKey = "2zorrEE5y7W9KkHLdfspFkt1O";
        private readonly string _consumerSecret = "zrqqcBiLRPpKB9O4861JCNwgmxS49pDm5kKT9yklutBV9Hgp5n";
        private readonly string _accessToken = "1162295008646574080-dSZyUR02ECm2D7vMHmo03J5Do9dZv4";
        private readonly string _accessTokenSecret = "izCQkSIUX5RNWcP9Vzis7VHPpPtPdOtcz19qoJAk1xkLR";
        

       
        [Test]
      public void Can_block_user()
		{
            TwitterService service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            var status = "AlexTst" + DateTime.UtcNow.Ticks + " Tweet from TweetSharp unit tests";
            //var tweet = service.SendTweet(new SendTweetOptions { Status = status });
            BlockUserOptions options = new BlockUserOptions ();
            options.ScreenName = _hero;
            var blockUser = service.BlockUser(options);

            Assert.IsNotNull(blockUser);
            Assert.IsNotEmpty(blockUser.ScreenName);
        }

        [Test]
        public void Can_tweet()
        {
            TwitterService service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            var status = _hero + DateTime.UtcNow.Ticks + " Tweet from TweetSharp unit tests";
            var tweet = service.SendTweet(new SendTweetOptions { Status = status });
           
            Assert.IsNotNull(tweet);
            Assert.AreNotEqual(0, tweet.Id);
        }
        [Test]
        public void Can_get_user_profile_for()
        {
            TwitterService service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            var profile = GetHeroProfile(service);

            Trace.WriteLine(service.Response.Response);

            Assert.IsNotNull(profile);
            Assert.IsNotEmpty(profile.ScreenName);
        }

        private TwitterUser GetHeroProfile(TwitterService service)
        {
            return service.GetUserProfileFor(new GetUserProfileForOptions { ScreenName = _hero });
        }
    }
}