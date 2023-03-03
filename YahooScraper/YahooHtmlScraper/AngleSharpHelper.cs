using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace FantasyDAO.YahooHtmlScraper
{
    public static class AngleSharpHelper
    {

        private static DateTime LastCallMade = new DateTime(0);
        public static async Task<IDocument> GetDocumentFromUrl(string url)
        {
            if ((DateTime.Now - LastCallMade).TotalSeconds < 5)
                System.Threading.Thread.Sleep(3000);

            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            return await context.OpenAsync(url);
        }

        public static string GetText(this IElement elm, string selector) => elm.QuerySelector(selector).Text();
    }
}
