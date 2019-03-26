using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models.Scryfall
{
    class ScryFallCardType
    {
        public string @object { get; set; }
        public int total_cards { get; set; }
        public bool has_more { get; set; }
        public string next_page { get; set; }
        public List<ScryFallCard> data { get; set; }
    }
}
