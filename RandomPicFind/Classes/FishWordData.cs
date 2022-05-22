using AngleSharp;
using System;
using System.Threading.Tasks;

namespace RandomPicFind.Classes
{

    public class WordObject
    {
        public async Task<string> FindRandomWordAsync()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://randomword.com/";
            var document = await BrowsingContext.New(config).OpenAsync(address);
            var cellSelector = @"div#random_word";
            var cell = document.QuerySelector(cellSelector);
            return cell.TextContent;
        }
    }

}
