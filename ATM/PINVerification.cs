using System.Security.Cryptography;
using System.Text;

namespace ATM
{
    public class PINVerification
    {

        public static bool CheckPIN(Account account)
        {
            // check PIN
            ATM.UI.DisplayMessage("Please enter your PIN!");

            int pinTries = 3; // max 3 tries

            while (true)
            {
                string? input = ATM.UI.ReadUserInput();

                if (VerifyPIN(input, account))
                {
                    ATM.UI.DisplayMessage("PIN verified.");
                    return true;
                }

                pinTries--;

                ATM.UI.DisplayMessage("Wrong PIN! " + pinTries + " tries left.");

                if (pinTries == 0)
                {
                    ATM.UI.DisplayMessage("3 wrong PINs entered.");
                    return false;
                }
            }
        }

        public static string GeneratePINHash(string pin)
        {
            using SHA256 hash = SHA256.Create();
            return Encoding.UTF8.GetString(hash.ComputeHash(Encoding.UTF8.GetBytes(pin)));
        }

        static bool VerifyPIN(string? pin, Account account)
        {
            if (pin == null) return false;
            return account.PinHash == GeneratePINHash(pin);
        }

    }
}
