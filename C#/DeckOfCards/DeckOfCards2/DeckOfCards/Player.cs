using System;
using System.Collections.Generic;
class Player
{
    public string Name;
    public List<Card> Hand;
    public Player(string name)
    {
        Name = name;
    }

    public Card Draw(Deck deck) { 
        Card drawCard = deck.deal();
        this.Hand.Add(drawCard);
        return drawCard;
    }
}
