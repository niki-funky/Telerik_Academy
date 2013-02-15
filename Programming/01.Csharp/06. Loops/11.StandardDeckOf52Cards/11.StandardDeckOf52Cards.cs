using System;

namespace Loops
{
    class StandardDeckOf52Cards
    {
        //Write a program that prints all possible cards 
        //from a standard deck of 52 cards (without jokers). 
        //The cards should be printed with their English names. 
        //Use nested for loops and switch-case.

        static void Main()
        {
            //variables
            string cardNumber = null;
            string cardColor = null;
            char cardSymbol = '0';
            char cardletter = '0';

            //expressions
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        cardColor = "Spades";
                        cardSymbol = '♠';
                        break;
                    case 2:
                        cardColor = "Hearts";
                        cardSymbol = '♥';
                        break;
                    case 3:
                        cardColor = "Diamonds";
                        cardSymbol = '♦';
                        break;
                    case 4:
                        cardColor = "Clubs";
                        cardSymbol = '♣';
                        break;
                }
                for (int k = 1; k <= 13; k++)
                {
                    switch (k)
                    {
                        case 1:
                            cardNumber = "Ace";
                            cardletter = 'A';
                            break;
                        case 2:
                            cardNumber = "Two";
                            cardletter = '2';
                            break;
                        case 3:
                            cardNumber = "Three";
                            cardletter = '3';
                            break;
                        case 4:
                            cardNumber = "Four";
                            cardletter = '4';
                            break;
                        case 5:
                            cardNumber = "Five";
                            cardletter = '5';
                            break;
                        case 6:
                            cardNumber = "Six";
                            cardletter = '6';
                            break;
                        case 7:
                            cardNumber = "Seven";
                            cardletter = '7';
                            break;
                        case 8:
                            cardNumber = "Eight";
                            cardletter = '8';
                            break;
                        case 9:
                            cardNumber = "Nine";
                            cardletter = '9';
                            break;
                        case 10:
                            cardNumber = "Ten";
                            cardletter = 'T';
                            break;
                        case 11:
                            cardNumber = "Jack";
                            cardletter = 'J';
                            break;
                        case 12:
                            cardNumber = "Queen";
                            cardletter = 'Q';
                            break;
                        case 13:
                            cardNumber = "King";
                            cardletter = 'K';
                            break;
                    }
                    Console.WriteLine(String.Format("{0,-18}{1,5}", cardNumber + " of " + cardColor, cardletter.ToString() + cardSymbol));
                }
            }
        }
    }
}
