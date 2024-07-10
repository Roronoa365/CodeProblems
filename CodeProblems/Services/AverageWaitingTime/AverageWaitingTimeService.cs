namespace CodeProblems.Services
{
    public class AverageWaitingTimeService: IAverageWaitingTimeService
    {
        //https://leetcode.com/problems/average-waiting-time/description/
        public double GetAverageWaitingTime(int[][] customers)
        {
            if (customers.Length == 0)
            {
                throw new Exception("[GetAverageWaitingTime] No Customers supplied");
            }

            List<int> waitingTimes = new List<int>();
            int currentTime = 0;

            foreach (var customer in customers)
            {
                int customerArrivalTime = customer[0];
                int customerOrderTime = customer[1];
                int waitingTime = 0;

                // if there is a gap between the current time and the time the customer arrives.
                if (currentTime < customerArrivalTime)
                {
                    waitingTime = customerOrderTime;
                    currentTime = customerArrivalTime + customerOrderTime;
                }
                // if the customer arrives whilst chef is busy with another order.
                else
                {
                    waitingTime = (currentTime - customerArrivalTime) + customerOrderTime;
                    currentTime += customerOrderTime;
                }

                waitingTimes.Add(waitingTime);
            }

            return waitingTimes.Average();
        }
    }
}
