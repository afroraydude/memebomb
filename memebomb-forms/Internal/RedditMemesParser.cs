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
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36");
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
