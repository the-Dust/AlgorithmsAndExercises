using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class MaximumNumberPrizes
    {
        public void SelfTest()
        {
            var res1 = Calculate(6); // 1 2 3
            var res2 = Calculate(8); // 1 2 5
            var res3 = Calculate(2); // 2
        }

        public int[] Calculate(int n)
        {
            // наиболее длинный ряд можно получить с арифметической прогрессией при d=1: 1,2,3,...,k-1,k+b
            // где b - то, что не уместилось в прогрессию, чтобы в сумме получить n
            // сумма прогрессии будет: k(k+1)/2 + b = n => k(k+1)/2 <= n => находим корень квадратного уравнения и округляем
            // его в меньшую сторону. Заполняем массив числами 1,2,3... до последнего элемента, а в последний записываем то,
            // что осталось
            var k = (int)((Math.Sqrt(8 * (double)n + 1) - 1) / 2);
            var arr = new int[k];
            for (int i = 0; i < k - 1; i++)
            {
                arr[i] = i + 1;
                n -= arr[i];
            }
            arr[k - 1] = n;
            return arr;
        }
    }
}
