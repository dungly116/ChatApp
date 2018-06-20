using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_lab.Models;
using YoutubeSearch;
using final_lab.Views;

namespace final_lab
{

    public class SearchResults
    {

        public List<YoutubeItem> GetResults(string inKeyword)
        {
            List<YoutubeItem> list = new List<YoutubeItem>();
            VideoSearch items = new VideoSearch();
            foreach (var item in items.SearchQuery(inKeyword, 1))
            {
                if (item.Title.Length >= 80)
                {
                    item.Title = item.Title.Substring(0, 80);
                }

                list.Add(new YoutubeItem { Title = item.Title, Url = item.Url });
            }
            return list;
        }
    }
}


//byte[] imageBytes = new WebClient().DownloadData(item.Thumbnail);

//using (MemoryStream ms = new MemoryStream(imageBytes)) {
//youtubeItem.Thumbnail = Image.FromStream(ms);
//}
//list.Add(youtubeItem);
