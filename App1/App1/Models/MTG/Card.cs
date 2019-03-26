using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models.MTG
{
    [Table("Card")]
    public class Card
    {
        public string name { get; set; }
        public string type { get; set; }
        public string set { get; set; }
        public string text { get; set; }
        public string lore { get; set; }
        public string artist { get; set; }
        public string number { get; set; }
        public Uri imageUrl { get; set; }
        [PrimaryKey, MaxLength(64)]
        public string id { get; set; }
        public string power { get; set; }
        public string toughness { get; set; }
        public string manacost { get; set; }
        public string loyalty { get; set; }

        public Card() { }

        public Card(string _name, string _type, string _set, string _text, string _lore, string _artist, string _number, Uri _imageUrl, string _manacost, string _toughness, string _power, string _loyalty, string _id)
        {
            name = _name;
            type = _type;
            set = _set;
            text = _text;
            lore = _lore;
            artist = _artist;
            number = _number;
            imageUrl = _imageUrl;
            manacost = _manacost;
            power = _power;
            toughness = _toughness;
            loyalty = _loyalty;
            id = _id;
        }
    }
}
