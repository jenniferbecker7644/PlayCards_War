using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayCards
{
    public class Card
    {
        public enum Suit { HEARTS, DIAMONDS, SPADES, CLUBS, JOKER};
        public enum FACECARDS { JACK = 11, QUEEN, KING, ACE, JOKER}
        public Suit CardSuit { get; private set; }
        public int Value { get; private set; }

        public Card()
        {
            //assign random card value
            Random r = new Random();
            Value = r.Next(1, 16);

            //check for Joker which requires special handling
            if (Value < 15)
                CardSuit = (Suit)r.Next(0, 4);
            else CardSuit = Suit.JOKER;
        }

        // if value is not a valid card value (1 - 15)
        // then assign default value of 1 to card
        public Card(Suit suit, int value)
        {
            CardSuit = suit;

            if (value > 0 && value <= 15)
                Value = value;
            else
                Value = 1;
        }

        // this card > that card  :  1
        // that card > this card  : -1
        // this card == that card :  0
        public int CompareCards(Card card)
        {
            //assume cards are equal
            int ret = 0;

            if (Value > card.Value)
                ret = 1;
            else if (Value < card.Value)
                ret = -1;

            return ret;
        }
    }
}
