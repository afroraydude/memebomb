using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace memebomb_forms.Internal
{
    static class RedditMemesParser
    {
        public static JObject Json(string url)
        {
            string getUrl = (!string.IsNullOrEmpty(url)) ? url : "https://api.reddit.com/r/memes";
            string webData; 
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "MockClient/0.1 by Me");
                webData =  client.GetStringAsync(getUrl).GetAwaiter().GetResult();
            }
                 
            return JObject.Parse(webData);
        }

        public static List<string> Urls(JToken[] subreddit)
        {
            List<string> output = new List<string>();

            foreach (JToken post in subreddit)
            {
                string url = post["data"]["url"].Value<string>();
                if (url.EndsWith("jpg") || url.EndsWith("png"))
                    output.Add(url);
            }

            return output;
        }
    }
}
