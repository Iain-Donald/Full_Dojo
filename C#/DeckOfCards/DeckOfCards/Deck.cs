using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    partial class Program
    {
        class Deck { 
            
            public List<Card> cards { get;set; }

            public Deck() {
                this.reset();
            }

            public Card deal() { 
                Card card = cards[cards.Count-1];
                cards.Remove(cards[cards.Count-1]);
                return card;
            }

            public void shuffle() { 
                Random rand = new Random();
                int len = cards.Count;  
                while (len > 1) {  
                    len--;  
                    int randIndex = rand.Next(len + 1);  
                    Card value = cards[randIndex];  
                    cards[randIndex] = cards[len];  
                    cards[len] = value;  
                }
            }
            public void reset() { 
                cards = new List<Card>{};
                string[] suits = new string[4] {"Club", "Spade", "Heart", "Diamond"};
                string[] values = new string[] {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};

                int valCounter = 1;
                foreach(var s in suits) {
                    foreach(var v in values) { 
                        cards.Add(new Card(v, s, valCounter));
                        valCounter++;
                    }
                    valCounter = 1;
                }
            }
        }
    }
}
