namespace ATM
{
    public class ATM
    {

        public static IUserInterface UI { get; set; } = new ConsoleUserInterface();


        private readonly AccountManager accountManager = new();


        public void InsertCard(Card card)
        {
            // get account
            Account? account = accountManager.LoadAccount(card.IBAN);

            if (account == null)
            {
                ATM.UI.DisplayMessage("Unknown account.");
                return;
            }

            // check pin
            bool pinVerified = PINVerification.CheckPIN(account);

            if (!pinVerified)
            {
                ATM.UI.DisplayMessage("Bye.");
                return;
            }

            // PIN ok!
            ATM.UI.DisplayMessage("Welcome " + account.Name + "!");

            // Perform tasks
            CheckWhatUserWantsToDo(account);
        }

        void CheckWhatUserWantsToDo(Account account)
        {
            ATM.UI.DisplayMessage("\nWhat do you want to do?");

            static void askIfUserWantsSomethingElse()
            {
                ATM.UI.DisplayMessage("\nDo you want to do something else?");
            }

            while (true)
            {
                ATM.UI.DisplayMessage(
                    "0: Exit\n" +
                    "1: Show Balance\n" +
                    "2: Withdraw\n" +
                    "3: Deposit\n" +
                    "4: Transfer"
                    );

                string? input = ATM.UI.ReadUserInput();

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
                    ATM.UI.DisplayMessage("Unknown input! (enter 0, 1, 2, 3)");
                }
            }

            ATM.UI.DisplayMessage("Bye!");
        }

        public Account CreateAccount(string iban, string name, string pin)
        {
            Account account = new(iban, name, PINVerification.GeneratePINHash(pin));
            accountManager.SaveAccount(account);
            return account;
        }

        public ATM()
        {
            accountManager = new AccountManager();
        }

    }
}
