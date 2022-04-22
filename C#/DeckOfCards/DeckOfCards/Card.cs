namespace DeckOfCards
{
    partial class Program
    {
        class Card
        {
            public string StringVal { get;set; }
            public string Suit { get;set; }
            public int Val { get;set; }

            public Card(string stringVal, string suit, int val){
                this.StringVal = stringVal;
                this.Suit = suit;
                this.Val = val;
            }

        }
    }
}
