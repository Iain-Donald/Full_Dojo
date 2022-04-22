using System.Collections.Generic;
using System;

namespace DeckOfCards
{
    partial class Program
    {
        class Player { 
            public string Name { get;set; }
            public List<Card> Hand { get;set; }

            public Card Draw(Deck deck) {
                Card cardDrawn = deck.deal();
                //this.Hand.Add(cardDrawn);
                return cardDrawn;
            }

            public object Discard(int index) { 
                if(Hand[index] != null) { 
                    Card cardDiscarded = Hand[index];
                    return cardDiscarded;
                }
                return null;
            }
        }

        static void Main(string[] args)
        {
            Player one = new Player();
            Deck cards = new Deck();
            Console.WriteLine(one.Draw(cards));
        }
    }
}
