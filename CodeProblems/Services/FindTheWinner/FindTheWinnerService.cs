namespace CodeProblems.Services
{
    public class FindTheWinnerService : IFindTheWinnerService
    {
        //https://leetcode.com/problems/find-the-winner-of-the-circular-game/description/
        public int FindTheWinner(int n, int k)
        {
            if (n < 1)
            {
                throw new Exception("[FindTheWinner] n is not a valid value. Must be greater than 0");
            }

            if (k < 0)
            {
                throw new Exception("[FindTheWinner] k is not a valid value. Must be greater than 0");
            }

            List<int> friendsRange = Enumerable.Range(1, n).ToList();
            int count = 0;

            while (friendsRange.Count > 1)
            {
                for (int i = 0; i < friendsRange.Count;)
                {
                    if (friendsRange.Count == 1)
                    {
                        break;
                    }

                    count++;

                    if (count == k)
                    {
                        count = 0;
                        friendsRange.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return friendsRange[0];
        }
    }
}
