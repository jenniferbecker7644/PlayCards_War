using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayCards;

namespace ConsoleCardsWar
{
    class Program
    {
        static void Main(string[] args)
        {
            //playing flag
            bool amPlaying = true;

            //player list accessors
            const int USER_PLAYER = 0;
            const int COMP_PLAYER = 1;

            //player cards
            Card userCard = new Card();
            Card compCard = new Card();

            //String for information output
            String outputInfo = "";

            while (amPlaying)
            {
                Console.WriteLine("WAR Declared...Your opponent will be the computer...");

                //Initialize Deck
                Deck deck = new Deck();

                //Create Hands
                List<Hand> hands = new List<Hand>
                {
                    new Hand(),
                    new Hand()
                };

                //Deal Hands
                deck.Deal(hands);

                Console.WriteLine("Hands dealt...");

                while (hands[USER_PLAYER].HandCount() > 0 && hands[COMP_PLAYER].HandCount() > 0)
                {
                    //Await user input to flip
                    Console.WriteLine("Hit any key to flip your card...");
                    //Await user flips their card
                    Console.ReadKey();
                    userCard = hands[USER_PLAYER].FlipCard();

                    //generate output
                    outputInfo = MapValueString(userCard);
                    if (outputInfo.CompareTo("Joker") != 0)
                        outputInfo += " of " + MapSuitString(userCard);

                    Console.WriteLine("");
                    Console.WriteLine("You have flipped a " + outputInfo);

                    //Computer flips
                    Console.WriteLine("Computer flipping...");
                    compCard = hands[COMP_PLAYER].FlipCard();

                    //generate output
                    outputInfo = MapValueString(compCard);
                    if (outputInfo.CompareTo("Joker") != 0)
                        outputInfo += " of " + MapSuitString(compCard);

                    Console.WriteLine("Computer has flipped a " + outputInfo);

                    //for storing war cards
                    Hand userWarCards = new Hand();
                    Hand compWarCards = new Hand();

                    userWarCards.AddCard(hands[USER_PLAYER].TakeCard());
                    compWarCards.AddCard(hands[COMP_PLAYER].TakeCard());
                    //Compare cards
                    int comp = userCard.CompareCards(compCard);
                    //if cards are equal
                    while (comp == 0)
                    {
                        Console.WriteLine("Uh oh - WAR");
                        int cardsToTransfer = 0;
                        //three cards from each
                        //////////////////////////////DO THIS
                        Console.WriteLine("Hit any key to go to war");
                        Console.ReadKey();

                        while(cardsToTransfer < 3 && hands[USER_PLAYER].HandCount() > cardsToTransfer + 1 && hands[COMP_PLAYER].HandCount() > cardsToTransfer + 1)
                        {
                            userWarCards.AddCard(hands[USER_PLAYER].TakeCard());
                            compWarCards.AddCard(hands[COMP_PLAYER].TakeCard());
                            cardsToTransfer++;
                        }

                        //flip fourth
                        userCard = hands[USER_PLAYER].FlipCard();

                        Console.WriteLine("");
                        //generate output
                        outputInfo = MapValueString(userCard);
                        if (outputInfo.CompareTo("Joker") != 0)
                            outputInfo += " of " + MapSuitString(userCard);

                        Console.WriteLine("");
                        Console.WriteLine("You have flipped a " + outputInfo);

                        //Computer flips
                        Console.WriteLine("Computer flipping...");
                        compCard = hands[COMP_PLAYER].FlipCard();

                        userWarCards.AddCard(hands[USER_PLAYER].TakeCard());
                        compWarCards.AddCard(hands[COMP_PLAYER].TakeCard());

                        //generate output
                        outputInfo = MapValueString(compCard);
                        if (outputInfo.CompareTo("Joker") != 0)
                            outputInfo += " of " + MapSuitString(compCard);

                        Console.WriteLine("Computer has flipped a " + outputInfo);
                        //back to compare cards
                        comp = userCard.CompareCards(compCard);
                    }

                    //if cards aren't equal
                    int handToCharge = 0;
                    int handToGive = 0;
                    if (comp > 0)
                    {
                        handToCharge = COMP_PLAYER;
                        handToGive = USER_PLAYER;
                        Console.WriteLine("You have won this hand");
                    }
                    else
                    {
                        handToCharge = USER_PLAYER;
                        handToGive = COMP_PLAYER;
                        Console.WriteLine("Computer has won this hand");
                    }

                    //Remove played cards from both hands
                    //Add cards to winning hand (bottom)
                    hands[handToGive].AddCards(userWarCards);
                    hands[handToGive].AddCards(compWarCards);

                    //DEBUG
                    Console.WriteLine("Your cards: " + hands[USER_PLAYER].HandCount());
                    Console.WriteLine("Computer's cards: " + hands[COMP_PLAYER].HandCount());
                }

                if (hands[USER_PLAYER].HandCount() > hands[COMP_PLAYER].HandCount())
                    Console.WriteLine("CONGRATULATIONS! You won the war; the spoils are yours");
                else
                    Console.WriteLine("You did not win the war; the spoils are not yours");

                Console.WriteLine("Continue playing (Hit Y or y for YES)?");
                //Take input
                String s = Console.ReadLine();
                //Check input and update amPlaying
                if (s != "y" || s != "Y")
                    amPlaying = false;
            }
        }

        //flip card and provide output
        private static Card FlipCard(int hand)
        {
            Card retCard = new Card();

            return retCard;
        }

        private static String MapSuitString(Card card)
        {
            String outputInfo = "";

            switch (card.CardSuit)
            {
                case Card.Suit.HEARTS:
                    outputInfo = "Hearts";
                    break;
                case Card.Suit.DIAMONDS:
                    outputInfo = "Diamonds";
                    break;
                case Card.Suit.SPADES:
                    outputInfo = "Spades";
                    break;
                case Card.Suit.CLUBS:
                    outputInfo = "Clubs";
                    break;
                case Card.Suit.JOKER:
                    outputInfo = "Joker";
                    break;
            }

            return outputInfo;
        }

        private static String MapValueString(Card card)
        {
            String outputInfo = "";

            switch(card.Value)
            {
                case 1:
                    outputInfo = "One";
                    break;
                case 2:
                    outputInfo = "Two";
                    break;
                case 3:
                    outputInfo = "Three";
                    break;
                case 4:
                    outputInfo = "Four";
                    break;
                case 5:
                    outputInfo = "Five";
                    break;
                case 6:
                    outputInfo = "Six";
                    break;
                case 7:
                    outputInfo = "Seven";
                    break;
                case 8:
                    outputInfo = "Eight";
                    break;
                case 9:
                    outputInfo = "Nine";
                    break;
                case 10:
                    outputInfo = "Ten";
                    break;
                case 11:
                    outputInfo = "Jack";
                    break;
                case 12:
                    outputInfo = "Queen";
                    break;
                case 13:
                    outputInfo = "King";
                    break;
                case 14:
                    outputInfo = "Ace";
                    break;
                case 15:
                    outputInfo = "Joker";
                    break;
            }

            return outputInfo;
        }
    }
}
