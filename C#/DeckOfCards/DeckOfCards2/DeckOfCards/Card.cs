using System;
class Card
{
    public string Name;
    public string Suit;
    public int Val;
    public Card(string name, string suit, int val)
    {
        Name = name;
        Suit = suit;
        Val = val;
    }

    public string print(){
        string outString = (Name + ", " + Suit + ", " + Val);
        return outString;
    }
}
