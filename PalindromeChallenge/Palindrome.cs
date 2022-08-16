using System.Text.RegularExpressions;

namespace PalindromeChallenge
{
    public class Palindrome
    {
        public static Boolean isPalindrome(String inputString)
        {
            // some consider empty string as a palindrome as well: https://stackoverflow.com/questions/28654209/can-an-empty-string-be-considered-a-palindrome
            try
            {
                Console.WriteLine(inputString);
                inputString = formatInput(inputString, "[^a-zA-Z0-9%]");

                Console.WriteLine(inputString);

                return inputString == reverseString(inputString);
            } catch (Exception ex)
            {
                throw;
            }
        }
        public static Boolean isPalindrome(int inputInt)
        {
            String inputString = inputInt.ToString();
            if (inputString != null)
            {
                Console.WriteLine(inputString);
                inputString = formatInput(inputString, "[^0-9%]");

                Console.WriteLine(inputString);

                return inputString == reverseString(inputString);
            }

            return false;
        }

        // formatting to ignore spacing, casing and special characters
        private static String formatInput(String inputString, String regexString)
        {
            try
            {
                return Regex.Replace(inputString, regexString, string.Empty).ToLower();
            } catch (ArgumentNullException)
            {
                throw;
            }
        }

        private static String reverseString(string inputStrring)
        {
            char[] charArray = inputStrring.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
