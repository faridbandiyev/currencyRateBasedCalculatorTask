using System.Transactions;

namespace currencyRateBasedCalculatorTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Array list

            string[] currency = new string[] { "US Dollar", "Russian Ruble", "Turkish Lira" };
            string[] currencyCode = new string[] { "USD", "RUB", "TRY" };
            decimal[] exchangeRate = new decimal[] { 1.7000M, 0.0187M, 0.0527M };
            string[] commands = { "/show-recent-currency-rates", "/find-currency-rate-by-code", "/calculate-amount-by-currency", "/exit" };
            string[] spaceDesign = { "        ||  ", "    ||  ", "     ||  " };

            #endregion

            while (true)
            {
                Console.WriteLine("Commands list:");
                int idxCommands = 0;

                while (idxCommands < commands.Length)
                {
                    Console.WriteLine(commands[idxCommands]);
                    idxCommands++;
                }

                Console.WriteLine();
                Console.WriteLine("============================================================");
                Console.WriteLine();
                Console.WriteLine("Enter command:");
                string command = Console.ReadLine();

                if (command == commands[3])
                {
                    Console.WriteLine("Exiting the program, goodbye!");
                    break;
                }

                else if (command == commands[0])
                {
                    Console.WriteLine();
                    Console.WriteLine("Recent currency rates:");
                    int idxCurrency = 0;

                    while (idxCurrency < currency.Length)
                    {
                        Console.WriteLine();
                        Console.WriteLine(currency[idxCurrency] + spaceDesign[idxCurrency] + currencyCode[idxCurrency] + "  ||  " + exchangeRate[idxCurrency] + "  ||");
                        idxCurrency++;
                    }
                }

                if (command == commands[1])
                {
                    Console.WriteLine("Enter currency code:");
                    string code = Console.ReadLine();
                    int idxCurrencyCode = 0;
                    bool found = true;

                    while (true)
                    {
                        if (code == currencyCode[idxCurrencyCode])
                        {
                            Console.WriteLine(currency[idxCurrencyCode] + spaceDesign[idxCurrencyCode] + currencyCode[idxCurrencyCode] + "  ||  " + exchangeRate[idxCurrencyCode] + "  ||");
                            found = true;
                            break;
                        }
                        idxCurrencyCode++;
                    }
                    if (!found)
                    {
                        Console.WriteLine("According currency rate could not be found.");
                    }

                }

                else if (command == commands[2])
                {
                    while (true)
                    {
                        Console.WriteLine("Enter amount in AZN:");
                        string userInput = Console.ReadLine();
                        decimal moneyAmountInAzn;

                        if (decimal.TryParse(userInput, out moneyAmountInAzn))
                        {
                            Console.WriteLine("Enter currency code:");
                            string code = Console.ReadLine();
                            int idxCurrencyCode = 0;
                            bool found = true;

                            while (true)
                            {
                                if (code == currencyCode[idxCurrencyCode])
                                {
                                    decimal convertedAmount = moneyAmountInAzn / exchangeRate[idxCurrencyCode];
                                    Console.WriteLine(moneyAmountInAzn + " AZN" + " = " + convertedAmount + currencyCode[idxCurrencyCode]);
                                    found = true;
                                    break;
                                }
                                idxCurrencyCode++;
                            }

                            if (!found)
                            {
                                Console.WriteLine("According currency rate could not be found.");
                            }
                        }
                        else
                            Console.WriteLine("Please enter valid amount.");
                    }
                }
            }
        }
    }
}
