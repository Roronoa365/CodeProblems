using CodeProblems.Controllers;
using CodeProblems.Services;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Shouldly;

namespace CodeProblemsTests
{
    public class FindTheWinnerServiceTests
    {
        private IFindTheWinnerService _findTheWinnerService;

        [SetUp]
        public void Setup()
        {
            _findTheWinnerService = new FindTheWinnerService();
        }

        [TestCase(5, 2, 3)]
        [TestCase(6, 5, 1)]
        [TestCase(5, 1, 5)]
        [TestCase(1, 1, 1)]
        [Test]
        public void FindTheWinner_PositiveTestCases(int amountOfFriends, int elimateOnStep, int result)
        {
            int theWinner = _findTheWinnerService.FindTheWinner(amountOfFriends, elimateOnStep);

            theWinner.ShouldBe(result);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [Test]
        public void FindTheWinner_InvalidNumberOnAmountOfFriends(int amountOfFriends)
        {

            Should.Throw<Exception>(() =>
            {
                int theWinner = _findTheWinnerService.FindTheWinner(amountOfFriends, 1);
            });
        }

        [TestCase(-1)]
        [Test]
        public void FindTheWinner_InvalidNumberOnElimateOnStep(int elimateOnStep)
        {

            Should.Throw<Exception>(() =>
            {
                int theWinner = _findTheWinnerService.FindTheWinner(5, elimateOnStep);
            });
        }
    }
}