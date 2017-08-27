using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayCards
{
    public class Deck
    {
        private List<Card> Cards = new List<Card>();

        public Deck()
        {
            //Initialize deck
            for (Card.Suit suit = Card.Suit.HEARTS; suit <= Card.Suit.CLUBS; suit++)
            {
                for(int i = 2; i < 15; i++)
                {
                    Cards.Add(new Card(suit, i));
                }
            }

            //Add Jokers to deck
            Cards.Add(new Card(Card.Suit.JOKER, 15));
            Cards.Add(new Card(Card.Suit.JOKER, 15));

            ShuffleDeck();
        }

        public void ShuffleDeck()
        {
            Random r = new Random();
            for (int n = Cards.Count(); n > 1;)
            {
                int k = r.Next(n);
                --n;
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }
        }
 
        public void Deal(List<Hand> hands)
        {
            int c = 0;
            while (c < Cards.Count())
            {
                foreach (Hand hand in hands)
                {
                    hand.AddCard(Cards[c++]);
                }
            }
        }
    }
}
