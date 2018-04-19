using System.Net;

namespace ScrapeLibrary
{
    public class Scrape
    {
        public string ScrapeWebpage(string url)
        {
            return GetWebpage(url);

        }
        public string ScrapeWebpage(string url, string filepath)
        {
            string reply = GetWebpage(url);

            System.IO.File.WriteAllText(filepath, reply);
            return reply;
        }

        private string GetWebpage(string url)
        {
            WebClient client = new WebClient();
            string content = client.DownloadString(url);
            content += "\nTHATS ALL FOLKS!";
            return content;
        }
    }
}
