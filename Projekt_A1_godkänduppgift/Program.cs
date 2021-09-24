using System;

namespace Projekt_A1_godkänduppgift
{
    class Program
    {
        public struct Article                                       // Declaring Struct
        {
            public string Name;
            public decimal Price;

        }
        const int maxNrOfArticles = 10;                                     // Limiting array
        static Article[] articles = new Article[maxNrOfArticles];           // creating array
        static int nrOfArticles;                                            // declaring variable for number of "slots" in use in the array

        static void Main(string[] args)                                     // running program
        {
            ReadArticles();
            Printout();
        }
        private static void ReadArticles()                                      // creating method for taking in articles
        {
            string articleInput;
            while (true)
            {
                Console.WriteLine($"How many articles do u want between 1-10");
                articleInput = Console.ReadLine();
                if (int.TryParse(articleInput, out nrOfArticles)==false)
                {
                    Console.WriteLine($"Wrong input, try again with a number between 1-10");
                    continue;
                }
                if (nrOfArticles > maxNrOfArticles || nrOfArticles < 1)
                {
                    Console.WriteLine($"Wrong input, try again with a nubmer between 1-10");
                    continue;
                }
                break;
            }
            for (int i = 0; i < nrOfArticles; i++)
            {
                Console.WriteLine($"Please typ in name and price of the {i + 1} article!");
                
                string[] articleDefintion = Console.ReadLine().Split(';', ' ');
                decimal priceInput = Convert.ToDecimal(articleDefintion[1]);
                articles[i] = new Article { Name = articleDefintion[0], Price = priceInput };
            }
        }
        public static void Printout()                                                       // creating method for printing out reciept
        {
            decimal totalPurchase = 0;
            decimal vat = 0.25M;
            decimal totalVat;
            DateTime dateTime = DateTime.Now;

            Console.Clear();
            Console.WriteLine($"Puchased reciept");
            Console.WriteLine();
            Console.WriteLine($"{dateTime}");
            Console.WriteLine();

            Console.WriteLine($"Number of articles purchased  #{nrOfArticles}");
            for (int i = 0; i < nrOfArticles; i++)
            {
                totalPurchase += articles[i].Price;
                Console.WriteLine();
                Console.WriteLine($" {"# Name",-30}{"Price",-30}");
                Console.WriteLine($" {i +1} {articles[i].Name,-25} {articles[i].Price,-25:C}");
            }
            totalVat = vat * totalPurchase;
            Console.WriteLine();
            Console.WriteLine($"Your total cost is: {totalPurchase,-40:C2}");
            Console.WriteLine($"Includes VAT (25%): {totalVat,-40:C2}");
        }
    }
}
