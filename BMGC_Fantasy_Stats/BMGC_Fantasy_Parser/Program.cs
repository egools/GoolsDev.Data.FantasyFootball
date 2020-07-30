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

            var path = Environment.CurrentDirectory;
            var files = Directory.GetFiles(Path.Combine(path, "app_data/2015/matchups"));
            //foreach (var file in files)
            //{
            //    //var doc = GetDocument(file).Result;

            //}

            //var document = GetDocument("https://sports.yahoo.com/nfl/players/25812/").Result;
            //var a = document.QuerySelector(".ys-name").Text();


        }

        public static async Task<IDocument> GetDocument(string url)
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            return await context.OpenAsync(url);
        }










    }
}
