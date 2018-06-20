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

    public class AddHotTopic
    {

        public List<HotTopic> GetHotTopic()
        {
            List<HotTopic> list = new List<HotTopic>();
            VideoSearch items = new VideoSearch();       
                list.Add(new HotTopic { Title = "Apple" });
                list.Add(new HotTopic { Title = "Walkthrough" });
                list.Add(new HotTopic { Title = "Gameplay" });
                list.Add(new HotTopic { Title = "Call Of Duty" });
                list.Add(new HotTopic { Title = "Test Drive" });
                list.Add(new HotTopic { Title = "Toyota" });
                list.Add(new HotTopic { Title = "Funny Video" });
                 list.Add(new HotTopic { Title = "Tutorial" });
                list.Add(new HotTopic { Title = "Audio Book" });
            return list;
        }
    }
}