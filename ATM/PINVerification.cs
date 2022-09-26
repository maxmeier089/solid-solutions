using System.Security.Cryptography;
using System.Text;

namespace ATM
{
    public class PINVerification
    {

        public static bool CheckPIN(Account account)
        {
            // check PIN
            Console.WriteLine("Please enter your PIN!");

            int pinTries = 3; // max 3 tries

            while (true)
            {
                string? input = Console.ReadLine();

                if (VerifyPIN(input, account))
                {
                    Console.WriteLine("PIN verified.");
                    return true;
                }

                pinTries--;

                Console.WriteLine("Wrong PIN! " + pinTries + " tries left.");

                if (pinTries == 0)
                {
                    Console.WriteLine("3 wrong PINs entered.");
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
