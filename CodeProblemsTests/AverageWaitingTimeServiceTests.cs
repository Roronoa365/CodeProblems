using CodeProblems.Controllers;
using CodeProblems.Services;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Shouldly;

namespace CodeProblemsTests
{
    public class AverageWaitingTimeServiceTests
    {
        private IAverageWaitingTimeService _averageWaitingTimeService;

        [SetUp]
        public void Setup()
        {
            _averageWaitingTimeService = new AverageWaitingTimeService();
        }

        public static IEnumerable<AverageWaitingTimeTestObject> GetTestCase1()
        {
            int[] arrayObject1 = { 1, 2 };
            int[] arrayObject2 = { 2, 5 };
            int[] arrayObject3 = { 4, 3 };
            yield return new AverageWaitingTimeTestObject()
            {
                Customers = new int[][] { arrayObject1, arrayObject2, arrayObject3 },
                Result = 5.0
            };
        }

        public static IEnumerable<AverageWaitingTimeTestObject> GetTestCase2()
        {
            int[] arrayObject1 = { 5, 2 };
            int[] arrayObject2 = { 5, 4 };
            int[] arrayObject3 = { 10, 3 };
            int[] arrayObject4 = { 20, 1 };
            yield return new AverageWaitingTimeTestObject()
            {
                Customers = new int[][] { arrayObject1, arrayObject2, arrayObject3, arrayObject4 },
                Result = 3.25
            };
        }

        // details were not supplied in how they would like to handle negative numbers or for the time wrapping back around
        [TestCaseSource(nameof(GetTestCase1))]
        [TestCaseSource(nameof(GetTestCase2))]
        [Test]
        public void GetAverageWaitingTime_SuppliedTestCases(AverageWaitingTimeTestObject testCase)
        {
            double averageWaitingTime = _averageWaitingTimeService.GetAverageWaitingTime(testCase.Customers);

            averageWaitingTime.ShouldBe(testCase.Result);
        }
    }

    public class AverageWaitingTimeTestObject
    {
        public int[][] Customers { get; set; }
        public double Result { get; set; }
    }
}