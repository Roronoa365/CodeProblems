using CodeProblems.Controllers;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Shouldly;

namespace CodeProblemsTests
{
    public class MajorityElementTests
    {
        private ILogger<MajorityElementController> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _loggerMock = A.Fake<ILogger<MajorityElementController>>();
        }

        [TestCase(new int[] { -1, 1, -1 }, -1)]
        [Test]
        public void GetMajorityElement_MinusNumbersSupplied(int[] nums, int result)
        {
            MajorityElementController majorityElementController = new MajorityElementController(_loggerMock);
            int majorityElement = majorityElementController.GetMajorityElement(nums);

            majorityElement.ShouldBe(result);
        }

        [TestCase(new int[] {}, 0)]
        [Test]
        public void GetMajorityElement_EmptyArray(int[] nums, int result)
        {
            MajorityElementController majorityElementController = new MajorityElementController(_loggerMock);

            Should.Throw<Exception>(() =>
            {
                int majorityElement = majorityElementController.GetMajorityElement(nums);
            });
        }

        [TestCase(new int[] { 1, 1, 2, 2 }, 1)]
        [Test]
        public void GetMajorityElement_ReturnsFirstMajorityElementWhenTied(int[] nums, int result)
        {
            MajorityElementController majorityElementController = new MajorityElementController(_loggerMock);
            int majorityElement = majorityElementController.GetMajorityElement(nums);

            majorityElement.ShouldBe(result);
        }

        [TestCase(new int[] { 1 }, 1)]
        [Test]
        public void GetMajorityElement_ReturnsMajorityElementWithOneEntryInArray(int[] nums, int result)
        {
            MajorityElementController majorityElementController = new MajorityElementController(_loggerMock);
            int majorityElement = majorityElementController.GetMajorityElement(nums);

            majorityElement.ShouldBe(result);
        }
    }
}