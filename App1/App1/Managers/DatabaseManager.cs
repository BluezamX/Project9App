using App1.Models.MTG;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace App1.Managers
{
  public static class DatabaseManager
  {
    public static string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "database.db3");

    public static void Create()
    {
      using (SQLiteConnection db = new SQLiteConnection(dbPath))
      {
        //db.DropTable<MTGSet>();
        //db.DropTable<Card>();
        try
        {
          SetTableFilled();
        }
        catch
        {
          db.CreateTable<MTGSet>();
          db.CreateTable<Card>();
        }
      }
    }

    public static bool SetAdded(MTGSet set)
    {
      using (SQLiteConnection db = new SQLiteConnection(dbPath))
      {
        return db.Table<Card>().Where(x => x.set == set.code).ToList().Count > 0;
      }
    }

    public static bool SetTableFilled()
    {
      using (SQLiteConnection db = new SQLiteConnection(dbPath))
      {
        return db.Table<MTGSet>().ToList().Count > 0;
      }
    }

    public static bool CardTableFilled(MTGSet set)
    {
      using (SQLiteConnection db = new SQLiteConnection(dbPath))
      {
        //List<Card> cards = db.Table<Card>().ToList();
        return db.Table<Card>().Where(x => x.set == set.code).ToList().Count > 0;
      }
    }

    public static void AddSets(List<MTGSet> sets)
    {
      using (SQLiteConnection db = new SQLiteConnection(dbPath))
      {
        foreach (MTGSet set in sets)
        {
          db.InsertOrReplace(set);
        }
      }
    }

    public static void AddCards(List<Card> cards)
    {
      using (SQLiteConnection db = new SQLiteConnection(dbPath))
      {
        foreach(Card card in cards)
        {
          db.InsertOrReplace(card);
        }
      }
    }

    public static List<MTGSet> GetSets()
    {
      using (SQLiteConnection db = new SQLiteConnection(dbPath))
      {
        return db.Table<MTGSet>().ToList();
      }
    }

    public static List<MTGSet> GetSets(List<string> type)
    {
      using (SQLiteConnection db = new SQLiteConnection(dbPath))
      {
        return db.Table<MTGSet>().Where(x => type.Contains(x.type)).ToList();
      }
    }

    public static List<Card> GetCards(MTGSet set)
    {
      using (SQLiteConnection db = new SQLiteConnection(dbPath))
      {
        return db.Table<Card>().Where(x => x.set == set.code).ToList();
      }
    }
  }
}
