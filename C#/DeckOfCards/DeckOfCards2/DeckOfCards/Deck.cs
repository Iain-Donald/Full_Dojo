using System;
using System.Collections.Generic;
class Deck
{
    public List<Card> cards;
    public Deck()
    {
        this.initialize();
    }

    public void initialize() { 
        cards = new List<Card>{};
        string[] suits = new string[4] {"Clubs", "Spades", "Hearts", "Diamonds"};
        string[] values = new string[] {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};

        int counter = 1;
        foreach(var s in suits) {
            foreach(var v in values) { 
                cards.Add(new Card(v, s, counter));
                counter++;
            }
            counter = 1;
        }
    }

    public Card deal() { 
        Card card = cards[cards.Count-1];
        cards.Remove(cards[cards.Count-1]);
        return card;
    }
}
