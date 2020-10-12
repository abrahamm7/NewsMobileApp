using System;
using System.Collections.Generic;
using System.Text;

namespace NewsAppMobile.NavigationLinks
{
    public class Links
    {
        public static string FeedPageLink = "FeedNewsPage";
        public static string PopMenuPage = "PopMenu";
        public static string NewsDetailsPage = "NewsDetailsPage";
        public static string ApiUrl = "https://newsapi.org";
        public static string NewsUrl = "https://newsapi.org/v2/everything?apiKey=2b6d74babe00414b91370d5e0bd85b35&q=tecnology";
        public string SpecifiedNews { get; set; }

        public Links(string topic)
        {
            SpecifiedNews = $"https://newsapi.org/v2/everything?apiKey=2b6d74babe00414b91370d5e0bd85b35&q={topic}";
        }
        
    }
}
