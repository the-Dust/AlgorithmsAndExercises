using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class JobScheduling
    {
        public void SelfTest()
        {
            var res = 
                Calculate(new[] { ("A", 50, 2), ("B", 20, 1), ("C", 30, 2), ("D", 25, 1), ("E", 15, 3), }); // C A E - 95
        }

        public (string[] schedule, int profit) Calculate((string id, int profit, int deadline)[] jobs)
        {
            // сортируем работы в порядке уменьшения профита
            // начинаем с наиболее профитной и ставим её как можно ближе к её дедлайну
            // Доказательство. Пусть есть работы A и B, B стартует в дедлайн А и профит от А больше, чем от B.
            // Если А стоит прямо перед B и мы поставим B раньше, то мы не проиграем. Если A стоит после B, то
            // мы недополучаем профит от A и постановка A перед B даст нам больше профита
            // https://stepik.org/lesson/734427/step/1?discussion=6665544&unit=735993
            var sorted = jobs.OrderByDescending(x => x.profit).ToArray();
            var res = new string[jobs.Length];
            var maxProfit = 0;

            foreach (var job in sorted)
            {
                for (int i = job.deadline - 1; i >= 0; i--)
                {
                    if (res[i] is null)
                    {
                        res[i] = job.id;
                        maxProfit += job.profit;
                        break;
                    }
                }
            }
            return (res, maxProfit);
        }
    }
}
