using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace App1.Managers
{
    static class CardManager
    {
        /*
        public static bool CheckConnection()
        {
            return App.connection.CheckConnection();
        }

        public static List<App1.Models.MTG.Card> GetCardSet(App1.Models.MTG.MTGSet set)
        {
            //List<App1.Models.MTG.Card> cards = new List<App1.Models.MTG.Card>();

            if (CheckConnection())
            {
                CardService service = new CardService();
                List<Card> result = new List<Card>();

                //sleepingThread = new Thread(() => TimeManager.ToAbort(5000, sleepingThread));
                //sleepingThread.Start();

                for (int i = 1; i < 4; i++)
                {
                    result.AddRange(
                        service.Where(x => x.Set, set.code)
                            .Where(x => x.PageSize, 100)
                            .Where(x => x.Page, i)
                            .All().Value);
                    if (result.Count % 100 != 0)
                        break;
                }
                
                return convert(result, set);
            }
            return new List<App1.Models.MTG.Card>();
        }

        public static List<App1.Models.MTG.MTGSet> GetSets()
        {
            //List<App1.Models.MTG.Set> sets = new List<App1.Models.MTG.Set>();

            if (CheckConnection())
            {
                SetService service = new SetService();
                List<Set> result = service.All().Value;

                List<Set> orderedSets = new List<Set>();
                orderedSets = (from e in result
                               orderby e.ReleaseDate descending
                               select e).ToList();

                return convert(orderedSets);
            }
            return new List<App1.Models.MTG.MTGSet>();
        }

        private static List<App1.Models.MTG.Card> convert(List<Card> cards, App1.Models.MTG.MTGSet set)
        {
            List<App1.Models.MTG.Card> convertedList = new List<App1.Models.MTG.Card>();
            int i = 0;
            foreach (Card card in cards)
            {
                //convertedList.Add(new App1.Models.MTG.Card(card.Name, card.OriginalType, card.Set, card.OriginalText, flavor, card.Artist, card.Number, card.ImageUrl, card.ManaCost, card.Toughness, card.Power, int.Parse(card.Loyalty)));
                Models.MTG.Card newcard = new Models.MTG.Card();
                if (card.OriginalType.Contains("Land"))
                {
                    newcard = new App1.Models.MTG.Card(card.Name, card.OriginalType, card.Set, card.OriginalText, "-", card.Artist, card.Number, card.ImageUrl, "0", "0", "0", 0);
                }
                else if (card.OriginalType.Contains("Creature"))
                {
                    newcard = new App1.Models.MTG.Card(card.Name, card.OriginalType, card.Set, card.OriginalText, "-", card.Artist, card.Number, card.ImageUrl, card.ManaCost, card.Toughness, card.Power, 0);
                }
                else if (card.OriginalType.Contains("Planeswalker"))
                {
                    newcard = new App1.Models.MTG.Card(card.Name, card.OriginalType, card.Set, card.OriginalText, "-", card.Artist, card.Number, card.ImageUrl, card.ManaCost, "0", "0", int.Parse(card.Loyalty));
                }
                else
                {
                    newcard = new App1.Models.MTG.Card(card.Name, card.OriginalType, card.Set, card.OriginalText, "-", card.Artist, card.Number, card.ImageUrl, card.ManaCost, "0", "0", 0);
                }

                i++;
                System.Diagnostics.Debug.WriteLine(i + card.Name);
                convertedList.Add(newcard);
                /*
                try
                {
                    App1.Models.MTG.Card newcard = new App1.Models.MTG.Card(card.Name, card.OriginalType, card.Set, card.OriginalText, "-", card.Artist, card.Number, card.ImageUrl, card.ManaCost, card.Toughness, card.Power, loyalty);
                    convertedList.Add(newcard);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                * /
            }
            return convertedList;
        }

        private static List<App1.Models.MTG.MTGSet> convert(List<Set> sets)
        {
            List<App1.Models.MTG.MTGSet> convertedList = new List<App1.Models.MTG.MTGSet>();
            foreach (Set set in sets)
            {
                if (null != set.Block)
                {
                    convertedList.Add(new App1.Models.MTG.MTGSet(set.Name, set.Code, 1, 256, set.Block, set.Block));
                }
            }
            return convertedList;
        }
        */
    }
}
