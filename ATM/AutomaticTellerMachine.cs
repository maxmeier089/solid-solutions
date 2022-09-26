namespace ATM
{
    public class AutomaticTellerMachine
    {

        private readonly AccountManager accountManager = new();


        public void InsertCard(Card card)
        {
            // get account
            Account? account = accountManager.LoadAccount(card.IBAN);

            if (account == null)
            {
                Console.WriteLine("Unknown account.");
                return;
            }

            // check pin
            bool pinVerified = PINVerification.CheckPIN(account);

            if (!pinVerified)
            {
                Console.WriteLine("Bye.");
                return;
            }

            // PIN ok!
            Console.WriteLine("Welcome " + account.Name + "!");

            // Perform tasks
            CheckWhatUserWantsToDo(account);
        }

        void CheckWhatUserWantsToDo(Account account)
        {
            Console.WriteLine("\nWhat do you want to do?");

            static void askIfUserWantsSomethingElse()
            {
                Console.WriteLine("\nDo you want to do something else? (y/n)");
            }

            while (true)
            {
                Console.WriteLine(
                    "0: Exit\n" +
                    "1: Show Balance\n" +
                    "2: Withdraw\n" +
                    "3: Deposit\n" +
                    "4: Transfer"
                    );

                string? input = Console.ReadLine();

                if (input == "0") break;
                else if (input == "1")
                {
                    account.ShowBalance();
                    askIfUserWantsSomethingElse();
                }
                else if (input == "2")
                {
                    account.Widthdraw();
                    askIfUserWantsSomethingElse();
                }
                else if (input == "3")
                {
                    account.Deposit();
                    askIfUserWantsSomethingElse();
                }
                else if (input == "4")
                {
                    TransferController transferController = new(account, accountManager);
                    transferController.Transfer();
                    askIfUserWantsSomethingElse();
                }
                else
                {
                    Console.WriteLine("Unknown input! (enter 0, 1, 2, 3)");
                }
            }

            Console.WriteLine("Bye!");
        }

        public Account CreateAccount(string iban, string name, string pin)
        {
            Account account = new(iban, name, PINVerification.GeneratePINHash(pin));
            accountManager.SaveAccount(account);
            return account;
        }

        public AutomaticTellerMachine()
        {
            accountManager = new AccountManager();
        }

    }
}
