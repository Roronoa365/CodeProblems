using CodeProblems.Controllers;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Shouldly;

namespace CodeProblemsTests
{
    public class FirstPalindromeTests
    {
        private ILogger<FirstPalindromeController> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _loggerMock = A.Fake<ILogger<FirstPalindromeController>>();
        }

        [Test]
        [TestCase("ada", new string[] { "abc", "car", "ada", "racecar", "cool" })]
        [TestCase("racecar", new string[] { "notapalindrome", "racecar" })]
        [TestCase("", new string[] { "def", "ghi" })]
        public void FirstPalindrome_PositiveTestCases(string result, params string[] words)
        {
            FirstPalindromeController firstPalindromeController = new FirstPalindromeController(_loggerMock);
            string firstPalindrome = firstPalindromeController.GetFirstPalindrome(words);

            firstPalindrome.ShouldBe(result);
        }
    }
}