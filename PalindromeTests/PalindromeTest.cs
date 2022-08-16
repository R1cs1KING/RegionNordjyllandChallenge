namespace PalindromeTests
{
    public class PalindromeTest
    {
        [Fact]
        public void TestOneWordPalindromeTrue()
        {
            // Arrange
            String input = "racecar";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestOneWordPalindromeFalse()
        {
            // Arrange
            String input = "stormtrooper";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.False(isPalindrome);
        }

        [Fact]
        public void TestOneWordPalindromeWithSpoecialCharactersTrue()
        {
            // Arrange
            String input = "rac#ecar";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestOneWordPalindromeWithSpecialCharactersFalse()
        {
            // Arrange
            String input = "stormtro#oper";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.False(isPalindrome);
        }

        [Fact]
        public void TestTwoWordPalindromeTrue()
        {
            // Arrange
            String input = "stack cats";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestTwoWordPalindromeFalse()
        {
            // Arrange
            String input = "stack stacks";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.False(isPalindrome);
        }

        [Fact]
        public void TestIntegerPalindromeTrue()
        {
            // Arrange
            int input = 10101;

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestIntegerPalindromeFalse()
        {
            // Arrange
            int input = 2022;

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.False(isPalindrome);
        }

        [Fact]
        public void TestNullInput()
        {
            // Arrange
            string input = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => PalindromeChallenge.Palindrome.isPalindrome(input));
        }

        [Fact]
        public void TestNumberAsStringPalindromeTrue()
        {
            // Arrange
            String input = "10101";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestNumberAsStringPalindromeFalse()
        {
            // Arrange
            String input = "2022";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.False(isPalindrome);
        }

        [Fact]
        public void TestFloatNumberAsStringPalindromeTrue()
        {
            // Arrange
            String input = "101.101";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestFloatNumberAsStringPalindromeFalse()
        {
            // Arrange
            String input = "20.22";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.False(isPalindrome);
        }
    }
}