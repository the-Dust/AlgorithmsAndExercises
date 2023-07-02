using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class DominoTiling
    {
        public void SelfTest()
        {
            var res1 = Calculate(2);
            var res2 = Calculate(3);
            var res3 = Calculate(4);
            var res4 = Calculate(5);
        }

        public int Calculate(int n)
        {
            return n % 2 == 0 ? Standard(n) : Corner(n);
        }

        private int Standard(int n)
        {
            if (n == 2)
                return 3;
            // можно либо поставить три доминошки вертикально на заполненный прямоугольник n-2
            // либо взять прямоугольник n-1 c углом и положить одну доминошку горизонтально (+ зеркальный угол)
            return Standard(n - 2) + 2 * Corner(n - 1);
        }

        private int Corner(int n)
        {
            if (n == 1)
                return 1;
            if (n == 3)
                return 4;
            // можно либо положить угол на заполненный прямоугольник n-1
            // либо поставить три доминошки вертикально на прямоугольник n-2 с углом
            return Standard(n - 1) + Corner(n - 2);
        }
    }
}
