using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCurrencyConverter
{
    internal class Customer
    {
        public decimal CashBalance { get; set; }
        public decimal BitcoinShares { get; set; }
        public decimal EthereumShares { get; set; }
        public decimal LitecoinShares { get; set; }

        //methods
        #region Sell Currency
        internal void SellCurrency()
        {
            Console.Clear();
            Console.WriteLine("\nWhich type of currency would you like to sell?\n");
            bool exit = false;
            while (!exit)
            {
                DisplayBalances();
                Console.WriteLine("B) Bitcoin ($62843/share)");
                Console.WriteLine("E) Ethereum ($3174.19/share)");
                Console.WriteLine("L) Litecoin ($83.05/share)");
                Console.WriteLine("C) Cancel");
                string selection = Console.ReadLine();

                decimal amountToSell = 0;
                decimal cashReturn = 0;

                switch (selection.ToLower())
                {
                    case "b":
                        //ask the user how much to sell
                        amountToSell = GetSaleAmount("Bitcoin");
                        //validate shares
                        if (amountToSell <= BitcoinShares)
                        {
                            //calculate changes
                            CashBalance += amountToSell * 62843;
                            BitcoinShares -= amountToSell;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine($"You only have {BitcoinShares} available.  Please try again.");
                        }
                        break;

                    case "e":
                        amountToSell = GetSaleAmount("Ethereum");
                        if (amountToSell <= EthereumShares)
                        {
                            //calculate changes
                            CashBalance += amountToSell * 3174.19m;
                            EthereumShares -= amountToSell;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine($"You only have {EthereumShares} available.  Please try again.");
                        }
                        break;

                    case "l":
                        amountToSell = GetSaleAmount("Litecoin");
                        if (amountToSell <= LitecoinShares)
                        {
                            //calculate changes
                            CashBalance += amountToSell * 83.05m;
                            LitecoinShares -= amountToSell;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine($"You only have {LitecoinShares} available.  Please try again.");
                        }

                        break;

                    case "c":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }

            }
        }

        internal decimal GetSaleAmount(string coinType)
        {
            bool exit = false;
            decimal sharesToSell = 0;
            while (!exit)
            {
                Console.Clear();
                DisplayBalances();
                Console.WriteLine($"How many shares of {coinType} would you like to sell?\n");
                bool validAmt = decimal.TryParse(Console.ReadLine(), out decimal amount);

                if (validAmt)
                {
                    sharesToSell = amount;
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Something went wrong.  Please try again.");
                }
            }

            return sharesToSell;
        }
        #endregion

        #region Purchase Currency
        internal void PurchaseCurrency()
        {
            Console.Clear();
            //ask the user which type of coin to purchase
            Console.WriteLine("\nWhich type of currency would you like to purchase?\n");

            bool exit = false;
            while (!exit)
            {
                decimal amountToPurchase = 0;
                decimal costToPurchase = 0;
                DisplayBalances();
                Console.WriteLine("B) Bitcoin ($62843/share)");
                Console.WriteLine("E) Ethereum ($3174.19/share)");
                Console.WriteLine("L) Litecoin ($83.05/share)");
                Console.WriteLine("C) Cancel");
                string selection = Console.ReadLine();


                switch (selection.ToLower())
                {
                    case "b":
                        //ask the user how much to purchase
                        amountToPurchase = GetPurchaseAmount("Bitcoin");

                        //validate available funds
                        costToPurchase = amountToPurchase * 62843;
                        if (costToPurchase > CashBalance)
                        {
                            Console.WriteLine($"\nThe transaction will cost {costToPurchase:c}, you only have {CashBalance:c} available.\n");
                        }
                        else
                        {
                            //calculate changes
                            CashBalance = CashBalance - costToPurchase;
                            BitcoinShares += amountToPurchase;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }

                        break;

                    case "e":
                        amountToPurchase = GetPurchaseAmount("Ethereum");

                        costToPurchase = amountToPurchase * 3174.19m;
                        if (costToPurchase > CashBalance)
                        {
                            Console.WriteLine($"\nThe transaction will cost {costToPurchase:c}, you only have {CashBalance:c} available.\n");
                        }
                        else
                        {
                            //calculate changes
                            CashBalance = CashBalance - costToPurchase;
                            EthereumShares += amountToPurchase;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }

                        break;

                    case "l":
                        amountToPurchase = GetPurchaseAmount("Litecoin");

                        costToPurchase = amountToPurchase * 83.05m;
                        if (costToPurchase > CashBalance)
                        {
                            Console.WriteLine($"\nThe transaction will cost {costToPurchase:c}, you only have {CashBalance:c} available.\n");
                        }
                        else
                        {
                            //calculate changes
                            CashBalance = CashBalance - costToPurchase;
                            LitecoinShares += amountToPurchase;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }

                        break;

                    case "c":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
            }



        }

        internal decimal GetPurchaseAmount(string coinType)
        {
            bool exit = false;
            decimal sharesToPurchase = 0;
            while (!exit)
            {
                Console.Clear();
                DisplayBalances();
                Console.WriteLine($"\nHow many shares of {coinType} would you like to purchase?");

                bool validAmt = decimal.TryParse(Console.ReadLine(), out decimal amount);

                if (validAmt)
                {
                    sharesToPurchase = amount;
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Something went wrong.  Please try again.");
                }
            }

            return sharesToPurchase;
        }
        #endregion

        #region Transfer Currency
        internal decimal GetTransferAmount(string coinTypeForSale, string coinTypeForReturn)
        {
            bool exit = false;
            decimal sharesToTransfer = 0;
            while (!exit)
            {
                Console.Clear();
                DisplayBalances();
                Console.WriteLine($"How many shares of {coinTypeForSale} would you like to transfer to {coinTypeForReturn}?\n");
                bool validAmt = decimal.TryParse(Console.ReadLine(), out decimal amount);

                if (validAmt)
                {
                    sharesToTransfer = amount;
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Something went wrong.  Please try again.");
                }
            }

            return sharesToTransfer;
        }
        internal void TransferCurrency()
        {
            Console.Clear();
            Console.WriteLine("\nWhich type of transfer would you like to initiate?\n");
            DisplayBalances();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("A) Bitcoin to Ethereum");
                Console.WriteLine("B) Bitcoin to Litecoin");
                Console.WriteLine("C) Ethereum to Bitcoin");
                Console.WriteLine("D) Ethereum to Litecoin");
                Console.WriteLine("E) Litecoin to Bitcoin");
                Console.WriteLine("F) Litecoin to Ethereum");
                Console.WriteLine("X) Cancel");
                string selection = Console.ReadLine();

                decimal amountToTransfer = 0;

                switch (selection.ToLower())
                {
                    case "a":
                        //get # of shares to transfer
                        amountToTransfer = GetTransferAmount("Bitcoin", "Ethereum");
                        //check if valid amt from balance
                        if (amountToTransfer <= BitcoinShares)
                        {
                            //update balances
                            BitcoinShares -= amountToTransfer;
                            //convert Bitcoin shares to Ethereum
                            decimal bitcoinCashBalance = amountToTransfer * 62843;
                            decimal newEthereumAddition = bitcoinCashBalance / 3174.19m;
                            EthereumShares += newEthereumAddition;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you do not have enough shares.\n");
                        }
                        break;

                    case "b":
                        amountToTransfer = GetTransferAmount("Bitcoin", "Litecoin");
                        if (amountToTransfer <= BitcoinShares)
                        {
                            //update balances
                            BitcoinShares -= amountToTransfer;
                            //convert Bitcoin shares to Litecoin
                            decimal bitcoinCashBalance = amountToTransfer * 62843;
                            decimal newLitecoinAddition = bitcoinCashBalance / 83.05m;

                            LitecoinShares += newLitecoinAddition;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you do not have enough shares.\n");
                        }
                        break;

                    case "c":
                        amountToTransfer = GetTransferAmount("Ethereum", "Bitcoin");
                        if (amountToTransfer <= EthereumShares)
                        {
                            //update balances
                            EthereumShares -= amountToTransfer;

                            //convert Ethereum shares to Bitcoin
                            decimal EthereumCashBalance = amountToTransfer * 3174.19m;
                            decimal newBitcoinAddition = EthereumCashBalance / 62843;
                            BitcoinShares += newBitcoinAddition;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you do not have enough shares.\n");
                        }
                        break;

                    case "d":
                        amountToTransfer = GetTransferAmount("Ethereum", "Litecoin");
                        if (amountToTransfer <= EthereumShares)
                        {
                            //update balances
                            EthereumShares -= amountToTransfer;

                            //convert Ethereum shares to Litecoin
                            decimal EthereumCashBalance = amountToTransfer * 3174.19m;
                            decimal newLitecoinAddition = EthereumCashBalance / 83.05m;
                            LitecoinShares += newLitecoinAddition;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you do not have enough shares.\n");
                        }
                        break;

                    case "e":
                        amountToTransfer = GetTransferAmount("Litecoin", "Bitcoin");
                        if (amountToTransfer <= LitecoinShares)
                        {
                            //update balances
                            LitecoinShares -= amountToTransfer;

                            //convert Litecoin shares to Bitcoin
                            decimal litecoinCashBalance = amountToTransfer * 83.05m;
                            decimal newBitcoinAddition = litecoinCashBalance / 62843;
                            BitcoinShares += newBitcoinAddition;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you do not have enough shares.\n");
                        }
                        break;

                    case "f":
                        amountToTransfer = GetTransferAmount("Litecoin", "Ethereum");
                        if (amountToTransfer <= LitecoinShares)
                        {
                            //update balances
                            LitecoinShares -= amountToTransfer;

                            //convert Litecoin shares to Bitcoin
                            decimal litecoinCashBalance = amountToTransfer * 83.05m;
                            decimal newEthereumAddition = litecoinCashBalance / 3174.19m;
                            EthereumShares += newEthereumAddition;
                            Console.Clear();
                            DisplayBalances();
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you do not have enough shares.\n");
                        }
                        break;

                    case "x":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Please make a valid selection.\n");
                        break;
                }


            }
        }
        #endregion

        #region View Balances
        internal void DisplayBalances()
        {
            Console.WriteLine($"\nYou have the following balances:\nCash: {CashBalance:c}\nBitcoin: {BitcoinShares} ({BitcoinShares * 62843:c})\nEthereum: {EthereumShares} ({EthereumShares * 3174.19m:c})\nLitecoin: {LitecoinShares} ({LitecoinShares * 83.05m:c})\n\n");
        }
        #endregion

    }
}
