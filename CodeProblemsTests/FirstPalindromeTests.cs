using CodeProblems.Controllers;
using CodeProblems.Services;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Shouldly;

namespace CodeProblemsTests
{
    public class FirstPalindromeTests
    {
        private IFirstPalindromeService _firstPalindromeService;

        [SetUp]
        public void Setup()
        {
            _firstPalindromeService = new FirstPalindromeService();
        }

        [Test]
        [TestCase("ada", new string[] { "abc", "car", "ada", "racecar", "cool" })]
        [TestCase("racecar", new string[] { "notapalindrome", "racecar" })]
        [TestCase("", new string[] { "def", "ghi" })]
        public void FirstPalindrome_PositiveTestCases(string result, params string[] words)
        {
            string firstPalindrome = _firstPalindromeService.GetFirstPalindrome(words);

            firstPalindrome.ShouldBe(result);
        }
    }
}