using System.Globalization;

namespace ATM
{
    public class Account
    {

        public string IBAN { get; private set; }

        public string Name { get; private set; }

        public decimal Balance { get; internal set; }

        public string PinHash { get; private set; }

        public void ShowBalance()
        {
            Console.WriteLine("Your balance is: " + string.Format(CultureInfo.CurrentCulture, "{0:c}", Balance));
        }

        public void Widthdraw()
        {
            Console.WriteLine("How much money do you want do withdraw?");

            decimal amount = ReadAmount();

            Balance -= amount;

            Console.WriteLine("Please take your money.");

            ShowBalance();
        }

        public void Deposit()
        {
            Console.WriteLine("How much money do you want do deposit?");

            decimal amount = ReadAmount();

            Balance += amount;

            ShowBalance();
        }

        public Card CreateCard()
        {
            return new Card(IBAN);
        }

        internal static decimal ReadAmount()
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal amount))
                {
                    return amount;
                }
                else
                {
                    Console.WriteLine("Please enter a number!");
                }
            }
        }

        public Account(string iban, string name, string pinHash)
        {
            IBAN = iban;
            Name = name;
            Balance = 0.0m;
            PinHash = pinHash;
        }
    }
}
