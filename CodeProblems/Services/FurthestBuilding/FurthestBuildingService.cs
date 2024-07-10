namespace CodeProblems.Services.FurthestBuilding
{
    public class FurthestBuildingService: IFurthestBuildingService
    {
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            if (heights.Length < ladders)
            {
                return heights.Length - 1;
            }

            List<int> differences = GetDifferencesInList(heights);
            List<int> orderedDifferences = new List<int>();
            Dictionary<int, int> ladderDictionary = new Dictionary<int, int>();
            int indexOfLastLadder = 0;
            int laddersUsed = 0;

            while (CanJumpUsingBricks(differences, bricks) == false)
            {
                if (differences.Count == 590)
                {
                    var temp = 0;
                }

                if (ladders > 0)
                {
                    orderedDifferences = differences.OrderByDescending(diff => diff).ToList();
                    int highestNumber = orderedDifferences[0];
                    int highestNumberIndex = differences.IndexOf(highestNumber);
                    differences[highestNumberIndex] = 0;
                    ladders--;

                    ladderDictionary.Add(highestNumberIndex, highestNumber);
                }
                else
                {
                    if (ladderDictionary.ContainsKey(differences.Count - 1))
                    {
                        ladders++;
                        ladderDictionary.Remove(differences.Count - 1);
                    }
                    differences.RemoveAt(differences.Count - 1);
                }
            }

            int furthestBuilding = differences.Count;

            return furthestBuilding;
        }

        internal bool CanJumpUsingBricks(List<int> differences, int bricks)
        {
            if (differences.Select(number => (long)number).Sum() <= bricks)
            {
                return true;
            }

            return false;
        }

        internal List<int> GetDifferencesInList(int[] heights)
        {
            List<int> differences = new List<int>();

            for (int index = 0; index < heights.Length; index++)
            {
                if (index + 1 == heights.Length)
                {
                    continue;
                }

                int difference = heights[index + 1] - heights[index];
                if (difference < 0)
                {
                    difference = 0;
                }
                differences.Add(difference);
            }

            return differences;
        }
    }
}
