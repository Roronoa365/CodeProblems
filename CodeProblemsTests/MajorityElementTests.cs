using CodeProblems.Controllers;
using CodeProblems.Services;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Shouldly;

namespace CodeProblemsTests
{
    public class MajorityElementTests
    {
        private IMajorityElementService _majorityElementService;

        [SetUp]
        public void Setup()
        {
            _majorityElementService = new MajorityElementService();
        }

        [TestCase(new int[] { -1, 1, -1 }, -1)]
        [Test]
        public void GetMajorityElement_MinusNumbersSupplied(int[] nums, int result)
        {
            int majorityElement = _majorityElementService.GetMajorityElement(nums);

            majorityElement.ShouldBe(result);
        }

        [TestCase(new int[] {}, 0)]
        [Test]
        public void GetMajorityElement_EmptyArray(int[] nums, int result)
        {
            Should.Throw<Exception>(() =>
            {
                int majorityElement = _majorityElementService.GetMajorityElement(nums);
            });
        }

        [TestCase(new int[] { 1, 1, 2, 2 }, 1)]
        [Test]
        public void GetMajorityElement_ReturnsFirstMajorityElementWhenTied(int[] nums, int result)
        {
            int majorityElement = _majorityElementService.GetMajorityElement(nums);

            majorityElement.ShouldBe(result);
        }

        [TestCase(new int[] { 1 }, 1)]
        [Test]
        public void GetMajorityElement_ReturnsMajorityElementWithOneEntryInArray(int[] nums, int result)
        {
            int majorityElement = _majorityElementService.GetMajorityElement(nums);

            majorityElement.ShouldBe(result);
        }
    }
}