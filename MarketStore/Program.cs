using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketStore
{
    enum CardType
    {
        Bronze,
        Silver,
        Gold
    }
    class Program
    {
        public static void displayFinalPrice(int cardType, double turnover, double purchaseValue)
        {

            switch (cardType)
            {
                case 1:
                    discountRateBronze(turnover, purchaseValue);
                    break;
                case 2:
                    discountRateSilver(turnover, purchaseValue);
                    break;
                case 3:
                    discountRateGold(turnover, purchaseValue);
                    break;
                default:
                    Console.WriteLine("Wrong card entered!");
                    break;
            }
        }

        private static void ShowResults(double purchaseValue, double discount)
        {
            Console.WriteLine("Your discount is: " + discount + " %");
            double finalPrice = purchaseValue - (discount * purchaseValue / 100);
            Console.WriteLine("Your discount rate is: " + (discount * purchaseValue / 100) + "$");
            Console.WriteLine("Your final price is: " + finalPrice + "$");
        }
        private static void discountRateGold(double turnover, double purchaseValue)
        {
            double discount = 2;
            Console.WriteLine("You have a " + CardType.Gold + " card!\n" +
                     "Your last months turnover was " + turnover +
                     "$\nand the purshase value is: " + purchaseValue + "$");

            if (purchaseValue / 100 > 10)
            {
                discount = 10;
            }
            else
            {
                discount = (int)(purchaseValue / 100);
            }

            ShowResults(purchaseValue, discount);
        }


        private static void discountRateSilver(double turnover, double purchaseValue)
        {
            double discount;
            Console.WriteLine("You have a " + CardType.Silver + " card!\n" +
                     "Your last months turnover was " + turnover +
                     "$\nand the purshase value is: " + purchaseValue + "$");
            if (turnover < 300)
            {
                discount = 2;
            }
            else
            {
                discount = 3.5;
            }

            ShowResults(purchaseValue, discount);
        }

        private static void discountRateBronze(double turnover, double purchaseValue)
        {
            double discount;
            Console.WriteLine("You have a "+CardType.Bronze+" card!\n" +
                     "Your last months turnover was " + turnover +
                     "$\nand the purshase value is: " + purchaseValue + "$");
            if (turnover < 100)
            {
                discount = 0;
            }
            else if (turnover >= 100 && turnover < 300)
            {
                discount = 1;
            }
            else
            {
                discount = 2.5;
            }
            ShowResults(purchaseValue, discount);
        }
        private static void PrintFinalResult()
        {
            while (true)
            {
                try
                {
                    int cardType;
                    Console.WriteLine("Chosse you card?\n" +
                        "Type 1 for Bronze, 2 for Silver, 3 for Gold\nPress 0 to exit aplication");
                    cardType = Convert.ToInt32(Console.ReadLine());
                    if (cardType == 1 || cardType == 2 || cardType == 3)
                    {
                        double turnover, purchaseValue;
                        EnterValues(out turnover, out purchaseValue);

                        displayFinalPrice(cardType, turnover, purchaseValue);
                    }
                    else if (cardType == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter 1, 2 or 3");
                    }
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Not valid, try again\n");
                }
            }
        }

        private static void EnterValues(out double turnover, out double purchaseValue)
        {
            Console.WriteLine("Enter last month's turnover:");
            turnover = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter purchase value:");
            purchaseValue = Convert.ToDouble(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            PrintFinalResult();
        }

    }
}
