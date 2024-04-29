using DigitalCurrencyConverter;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
 * ********************************************************************************************************
 * Create a Console App that will allow you to purchase, sell, transfer, and view your digital currencies.
 * ********************************************************************************************************
 * */
            // Start with a balance of 50,000
            // Hold balances for
            //  - Cash
            //  - Bitcoin
            //  - Ethereum
            //  - Litecoin
            // Have the option to perform any of the following actions
            //  - Purchase digital currency with cash
            //  - Sell digital currency for cash
            //  - View account balances
            //  - Transfer between digital currencies
            // Assume the following values
            //  - Each Bitcoin is worth $62,843
            //  - Each Ethereum is worth $3174.19
            //  - Each Litecoin is worth $83.05


            // First - creating a class called Customer with props for each currency type (see Customer.cs)
            // Second - instantiate Customer with a balance of $50000 cash

            Customer c = new Customer()
            {
                CashBalance = 50000,
                BitcoinShares = 0,
                EthereumShares = 0,
                LitecoinShares = 0
            };

            // Third - kick off the menu selection
            Console.WriteLine($"**** Welcome to the fake money ATM! ****\n\n");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine($"Please make a selection.");

                Console.WriteLine("P) Purchase digitial currency");
                Console.WriteLine("S) Sell digital currency");
                Console.WriteLine("T) Transfer digital currency");
                Console.WriteLine("V) View account balances");
                Console.WriteLine("X) Exit");
                string selection = Console.ReadLine();
                switch (selection.ToLower())
                {
                    case "p":
                        //open menu to select the currency type to purchase
                        c.PurchaseCurrency();
                        break;

                    case "s":
                        //open menu to select currency to sell
                        c.SellCurrency();
                        break;

                    case "t":
                        //open menu to select which currency to transfer
                        c.TransferCurrency();
                        break;

                    case "v":
                        //show balances for all currency types
                        Console.Clear();
                        c.DisplayBalances();
                        break;

                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine($"\nPlease make a valid selection from the menu options...\n");
                        break;
                }


            }
        }
    }
}
