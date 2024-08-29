using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using HtmlAgilityPack;

namespace MZM.Controllers
{
    public class eMegaController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<ActionResult> Index()
        {
            string url = "https://app.megazone.fm/e-megazoner-new/c/0"; // Replace with the live page URL
            string pageContent = await FetchPageContentAsync(url);

            if (pageContent != null)
            {
                var processedContent = ProcessHyperlinks(pageContent, url);
                ViewBag.PageContent = processedContent;
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

        private string ProcessHyperlinks(string htmlContent, string baseUrl)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            var linkNodes = htmlDoc.DocumentNode.SelectNodes("//a[@href]");
            if (linkNodes != null)
            {
                foreach (var node in linkNodes)
                {
                    string hrefValue = node.GetAttributeValue("href", string.Empty);

                    // Convert relative URLs to absolute URLs if necessary
                    if (!hrefValue.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        Uri baseUri = new Uri(baseUrl);
                        Uri absoluteUri = new Uri(baseUri, hrefValue);
                        hrefValue = absoluteUri.ToString();
                    }

                    // Optionally, you can modify hrefValue here (e.g., add tracking parameters)

                    node.SetAttributeValue("href", hrefValue);
                }
            }

            // Return the modified HTML as a string
            return htmlDoc.DocumentNode.OuterHtml;
        }

        private bool IsOldContent(string url)
        {
            // Implement logic to determine if content is old
            // For example, check the URL pattern, query parameters, or date embedded in the link
            return url.Contains("old-content");
        }
    }
}
