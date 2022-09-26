namespace ATM
{
    public class AccountManager
    {

        readonly Dictionary<string, Account> accounts;

        public Account? LoadAccount(string? iban)
        {
            if (iban == null) return null;
            return accounts.GetValueOrDefault(iban);
        }

        public void SaveAccount(Account account)
        {
            accounts[account.IBAN] = account;
        }

        public AccountManager()
        {
            accounts = new Dictionary<string, Account>();
        }

    }
}
