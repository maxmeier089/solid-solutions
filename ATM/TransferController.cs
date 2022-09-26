namespace ATM
{
    public class TransferController
    {
        readonly Account sourceAccount;
        readonly AccountManager accountManager;

        public void Transfer()
        {
            Account? targetAccount = null;

            Console.WriteLine("Please enter the target account IBAN:");

            while (targetAccount == null)
            {
                string? input = Console.ReadLine();

                targetAccount = accountManager.LoadAccount(input);

                if (targetAccount == null) Console.WriteLine("Unknown IBAN!");
            }

            Console.WriteLine("How much money do you want to transfer?");

            decimal amount = Account.ReadAmount();

            sourceAccount.Balance -= amount;
            targetAccount.Balance += amount;

            Console.WriteLine("Transfer complete.");

            sourceAccount.ShowBalance();
        }

        public TransferController(Account sourceAccount, AccountManager accountManager)
        {
            this.sourceAccount = sourceAccount;
            this.accountManager = accountManager;
       
        }

    }
}
