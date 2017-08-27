using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayCards
{
    public class Hand
    {
        private List<Card> Cards = new List<Card>();
      
        //keep track of position in hand
        private const int HANDPOS = 0;

        public Hand(){}

        public Hand(List<Card> cards)
        {
            Cards.AddRange(cards);
        }

        public int HandCount()
        {
            return Cards.Count();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void AddCards(Hand cards)
        {
            Cards.AddRange(cards.Cards);
        }

        //card remains on hand
        public Card FlipCard()
        {
            Card retCard = null;

            if(HANDPOS >= 0 && HANDPOS < Cards.Count() - 1)
            {
                retCard = Cards[HANDPOS];
            }

            return retCard;          
        }

        //card removed from hand
        public Card TakeCard()
        {
            Card retCard = null;

            if(HANDPOS < Cards.Count())
            {
                retCard = Cards[HANDPOS];
                Cards.Remove(retCard);
            }

            return retCard;
        }

        //for Debugging
        public int GetHandCount()
        {
            return Cards.Count();
        }
    }
}
