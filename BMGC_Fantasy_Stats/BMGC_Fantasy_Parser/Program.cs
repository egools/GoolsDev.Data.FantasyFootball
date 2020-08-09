using AngleSharp;
using AngleSharp.Dom;
using FantasyComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FantasyParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var directories = Directory.GetDirectories("../../../app_data/");
            foreach (var dir in directories)
            {
                
            }

            //var document = GetDocument("https://sports.yahoo.com/nfl/players/{ysPlayerId}/").Result;
            //var a = document.QuerySelector(".ys-name").Text();


        }

        public static async Task<IDocument> GetDocument(string url)
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            return await context.OpenAsync(url);
        }










    }
}
