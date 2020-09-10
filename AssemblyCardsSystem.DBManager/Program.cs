using System;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCardsSystem.DBManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void insertProduct(AssemblyCard card)
        {
            using (var db = new CardsContext())
            {
                db.Add(card);

                db.SaveChanges();
            }
        }

        static void readProduct()
        {

            using (var db = new CardsContext())
            {
                List<AssemblyCard> cards = db.Cards.ToList();
                foreach (AssemblyCard card in cards)
                {
                    Console.WriteLine("Card");
                }
            }
            return;
        }
    }
}
