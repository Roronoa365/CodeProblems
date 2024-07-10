namespace CodeProblems.Services
{
    public class MajorityElementService: IMajorityElementService
    {
        //https://leetcode.com/problems/majority-element/description/
        public int GetMajorityElement(int[] nums)
        {
            if (nums.Length == 0)
            {
                throw new Exception("[GetMajorityElement] 'nums' array is empty.");
            }

            Dictionary<int, int> numValues = new Dictionary<int, int>();
            int highestValue = 0;
            int highestNumber = 0;

            foreach (int value in nums)
            {
                if (!numValues.ContainsKey(value))
                {
                    numValues.Add(value, 0);
                }

                numValues[value]++;
                if (numValues[value] > highestValue)
                {
                    highestValue = numValues[value];
                    highestNumber = value;
                }
            }

            return highestNumber;
        }
    }
}
