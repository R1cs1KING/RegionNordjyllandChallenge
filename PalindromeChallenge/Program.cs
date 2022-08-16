using static System.Console;

namespace PalindromeChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Word to check if it is a palindrome: ");

            string input = ReadLine();

            if (Palindrome.isPalindrome(input))
            {
                WriteLine("It is a palindrome");
            } else
            {
                WriteLine("It is not a palindrome");
            }
        }
    }
}