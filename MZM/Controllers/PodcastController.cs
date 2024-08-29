using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MZM.Controllers
{
    public class PodcastController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<ActionResult> Index()
        {
            string url = "https://app.megazone.fm/podcasts/c/0"; // Replace with the live page URL
            string pageContent = await FetchPageContentAsync(url);

            if (pageContent != null)
            {
                ViewBag.PageContent = pageContent;
                return View();
            }

            return View("Error"); // Handle error appropriately
        }

        private async Task<string> FetchPageContentAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as necessary
                System.Diagnostics.Debug.WriteLine($"Error fetching page: {ex.Message}");
            }

            return null;
        }
        public ActionResult News()
        {
            return View();
        }
    }
}