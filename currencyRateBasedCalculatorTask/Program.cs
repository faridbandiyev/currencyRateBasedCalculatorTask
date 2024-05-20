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
            string[] commands = new string[] { "/show-commands (Input 1)", "/show-recent-currency-rates (Input 2)", "/find-currency-rate-by-code (Input 3)", "/calculate-amount-by-currency (Input 4)", "/exit (Input 5)" };
            string[] spaceDesign = { "        ||  ", "    ||  ", "     ||  " };

            #endregion

            Console.WriteLine("Commands list:");
            Console.WriteLine();
            int idxCommands = 0;

            while (idxCommands < commands.Length)
            {
                Console.WriteLine(commands[idxCommands]);
                idxCommands++;
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Enter command:");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Commands list:");
                        idxCommands = 0;

                        while (idxCommands < commands.Length)
                        {
                            Console.WriteLine(commands[idxCommands]);
                            idxCommands++;
                        }
                        break;

                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Recent currency rates:");
                        Console.WriteLine();
                        int idxCurrency = 0;
                        Console.WriteLine("============================================");
                        Console.WriteLine();

                        while (idxCurrency < currency.Length)
                        {

                            Console.WriteLine("    " + currency[idxCurrency] + spaceDesign[idxCurrency] + currencyCode[idxCurrency] + "  ||  " + exchangeRate[idxCurrency]);
                            Console.WriteLine();

                            idxCurrency++;
                        }

                        Console.WriteLine("============================================");
                        break;

                    case "3":
                        Console.WriteLine();
                        Console.Write("Enter currency code: ");
                        string code = Console.ReadLine();
                        int idxCurrencyCode = 0;
                        bool found = false;

                        while (idxCurrencyCode < currencyCode.Length)
                        {
                            if (code == currencyCode[idxCurrencyCode])
                            {
                                Console.WriteLine();
                                Console.WriteLine(" " + currency[idxCurrencyCode] + spaceDesign[idxCurrencyCode] + currencyCode[idxCurrencyCode] + "  ||  " + exchangeRate[idxCurrencyCode]);
                                found = true;
                                break;
                            }
                            idxCurrencyCode++;
                        }

                        if (!found)
                        {
                            Console.WriteLine();
                            Console.WriteLine("According currency rate could not be found.");
                        }
                        break;

                    case "4":
                        while (true)
                        {
                            Console.WriteLine();
                            Console.Write("Enter amount in AZN: ");
                            string userInput = Console.ReadLine();
                            decimal moneyAmountInAzn;



                            if (decimal.TryParse(userInput, out moneyAmountInAzn))
                            {
                            currencyCodeRepeat:
                                Console.WriteLine();
                                Console.Write("Enter currency code: ");
                                code = Console.ReadLine();
                                idxCurrencyCode = 0;
                                found = false;

                                while (idxCurrencyCode < currencyCode.Length)
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
                                    goto currencyCodeRepeat;

                                }

                            repeat:
                                Console.WriteLine();
                                Console.WriteLine("----------------------------------------------------");
                                Console.WriteLine("Do you want to request new exchange? (Yes, No) ");
                                Console.WriteLine("----------------------------------------------------");
                                string answer = Console.ReadLine();

                                if (answer == "Yes")
                                    continue;
                                else if (answer == "No")
                                    break;
                                else
                                {
                                    Console.WriteLine("Invalid answer.");
                                    goto repeat;
                                }

                            }

                            else
                                Console.WriteLine("Please enter valid amount.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Exiting the program, goodbye!");
                        return;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid command was entered.");
                        Console.WriteLine();
                        Console.WriteLine("Commands list:");
                        Console.WriteLine();
                        idxCommands = 0;

                        while (idxCommands < commands.Length)
                        {
                            Console.WriteLine(commands[idxCommands]);
                            idxCommands++;
                        }
                        break;
                }
            }
        }
    }
}