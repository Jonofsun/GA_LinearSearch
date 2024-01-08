using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_LinearSearch
{
    public class Anime
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int EpisodeCount { get; set; }

        // Constructor
        public Anime(string title, string genre, int episodeCount)
        {
            Title = title;
            Genre = genre;
            EpisodeCount = episodeCount;
        }
    }
}
