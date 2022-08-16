namespace PalindromeTests
{
    public class PalindromeTest
    {
        [Fact]
        public void TestOneWordPalindromeTrue()
        {
            // Arrange
            string input = "racecar";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestOneWordPalindromeFalse()
        {
            // Arrange
            string input = "stormtrooper";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.False(isPalindrome);
        }

        [Fact]
        public void TestOneWordPalindromeWithSpoecialCharactersTrue()
        {
            // Arrange
            string input = "rac#ecar";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestOneWordPalindromeWithSpecialCharactersFalse()
        {
            // Arrange
            string input = "stormtro#oper";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.False(isPalindrome);
        }

        [Fact]
        public void TestTwoWordPalindromeTrue()
        {
            // Arrange
            string input = "stack cats";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestTwoWordPalindromeFalse()
        {
            // Arrange
            string input = "stack stacks";

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
        public void TestNumberAsstringPalindromeTrue()
        {
            // Arrange
            string input = "10101";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestNumberAsstringPalindromeFalse()
        {
            // Arrange
            string input = "2022";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.False(isPalindrome);
        }

        [Fact]
        public void TestFloatNumberAsstringPalindromeTrue()
        {
            // Arrange
            string input = "101.101";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void TestFloatNumberAsstringPalindromeFalse()
        {
            // Arrange
            string input = "20.22";

            // Act
            bool isPalindrome = PalindromeChallenge.Palindrome.isPalindrome(input);

            // Assert
            Assert.False(isPalindrome);
        }
    }
}