﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class ColoringABoard
    {
        public void SelfTest()
        {
            var res = Calculate(4); // 157_140
        }

        public long Calculate(int n)
        {
            // надо добавить мемоизацию

            return Number3(n) + Number2(n);
        }

        // если раскрашиваем следующую полосу в три цвета
        private long Number3(int n)
        {
            if (n == 1)
                return 4 * 3 * 2;
            // если предыдущая полоса трёхцветная и её цвета ABC:
            // всего вариантов раскраски: 4 * 3 * 2, (первый цвет четырьмя способами, второй тремя, третий двумя)
            // начинаются с того же цвета, что и предыдущая полоса: 1*3*2=6
            // содержит в середине тот же цвет, что и предыдущая полоса: 3*1*2 - 1*1*2 = 4 (т.к. два случая было учтено в предыдущем варианте)
            // содержит в конце тот же цвет, что и предыдущая полоса: 3*2*1 - 2 (ABC + ADC, учтены в первом варианте) - 1 (DBC, учтён во втором)
            // итого: 24 - 6 - 4 - 3 = 11
            // если предыдущая полоса двухцветная и её цвета ABA:
            // всего вариантов раскраски: 4 * 3 * 2,
            // начинаются с того же цвета, что и предыдущая полоса: 1*3*2=6 (AXX)
            // заканчиваются тем же цветом, что и предыдущая полоса: 3*2*1=6 (XXA)
            // содержит в середине тот же цвет, что и предыдущая полоса: 2*1*1 (!AB!A)
            // итого: 24 - 6 - 6 - 2 = 10
            return 11 * Number3(n - 1) + 10 * Number2(n - 1);
        }

        // если раскрашиваем следующую полосу в два цвета
        private long Number2(int n)
        {
            if (n == 1)
                return 4 * 3 * 1;
            // если предыдущая полоса трёхцветная и её цвета ABC:
            // всего вариантов раскраски: 4 * 3 * 1, (первый цвет четырьмя способами, второй тремя, третий тот же, что и первый)
            // начинаются с того же цвета, что и предыдущая полоса: 1*3*1=1 (AXA)
            // заканчиваются тем же цветом, что и предыдущая полоса: 1*3*1=1 (CXC)
            // содержит в середине тот же цвет, что и предыдущая полоса: 1*1*1 (!A,!C)B(!A,!C) - т.е. это только DBD
            // итого: 12 - 3 - 3 - 1 = 5
            // если предыдущая полоса двухцветная и её цвета ABA:
            // всего вариантов раскраски: 4 * 3 * 1,
            // начинаются или заканчиваются с того же цвета, что и предыдущая полоса: 1*3*1=1 (AXA)
            // содержит в середине тот же цвет, что и предыдущая полоса: 2*1*1 !AB!A
            // итого: 12 - 3 - 2 = 7
            return 5 * Number3(n - 1) + 7 * Number2(n - 1);
        }
    }
}
