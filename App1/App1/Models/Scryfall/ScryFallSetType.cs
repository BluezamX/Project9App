using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models.Scryfall
{
    class ScryFallSetType
    {
        public string @object { get; set; }
        public bool has_more { get; set; }
        public List<ScryFallSet> data { get; set; }
    }
}
