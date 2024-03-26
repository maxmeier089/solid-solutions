namespace ATM
{
    public class TransferController
    {
        readonly Account sourceAccount;
        readonly AccountManager accountManager;

        public void Transfer()
        {
            Account? targetAccount = null;

            ATM.UI.DisplayMessage("Please enter the target account IBAN:");

            while (targetAccount == null)
            {
                string? input = ATM.UI.ReadUserInput();

                targetAccount = accountManager.LoadAccount(input);

                if (targetAccount == null) ATM.UI.DisplayMessage("Unknown IBAN!");
            }

            ATM.UI.DisplayMessage("How much money do you want to transfer?");

            decimal amount = Account.ReadAmount();

            sourceAccount.Balance -= amount;
            targetAccount.Balance += amount;

            ATM.UI.DisplayMessage("Transfer complete.");

            sourceAccount.ShowBalance();
        }

        public TransferController(Account sourceAccount, AccountManager accountManager)
        {
            this.sourceAccount = sourceAccount;
            this.accountManager = accountManager;
       
        }

    }
}
