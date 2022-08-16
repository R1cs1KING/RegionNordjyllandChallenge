using System.Text.RegularExpressions;

namespace PalindromeChallenge
{
    public class Palindrome
    {
        public static Boolean isPalindrome(string inputstring)
        {
            // some consider empty string as a palindrome as well: https://stackoverflow.com/questions/28654209/can-an-empty-string-be-considered-a-palindrome
            try
            {
                Console.WriteLine(inputstring);
                inputstring = formatInput(inputstring, "[^a-zA-Z0-9%]");

                Console.WriteLine(inputstring);

                return inputstring == reversestring(inputstring);
            } catch (Exception ex)
            {
                throw;
            }
        }
        public static Boolean isPalindrome(int inputInt)
        {
            string inputstring = inputInt.ToString();
            if (inputstring != null)
            {
                Console.WriteLine(inputstring);
                inputstring = formatInput(inputstring, "[^0-9%]");

                Console.WriteLine(inputstring);

                return inputstring == reversestring(inputstring);
            }

            return false;
        }

        // formatting to ignore spacing, casing and special characters
        private static string formatInput(string inputstring, string regexstring)
        {
            try
            {
                return Regex.Replace(inputstring, regexstring, string.Empty).ToLower();
            } catch (ArgumentNullException)
            {
                throw;
            }
        }

        private static string reversestring(string inputStrring)
        {
            char[] charArray = inputStrring.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
