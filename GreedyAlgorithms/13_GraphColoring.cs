﻿using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class GraphColoring
    {
        public void SelfTest()
        {

        }

        public void Calculate()
        {
            // Оптимальная раскраска графа - NP-полная задача, поэтому тут предлагается теорема, что граф
            // со степенью K может быть раскрашен максимум в K+1 цветов (*). 
            // Жадный алгоритм на основе теоремы: раскрасить первую вершину в цвет c1, раскрасить соседей в цвет с2,
            // если у соседа уже есть соседи цвета с2, то выбрать цвет с3 и т.д.
            // * Доказательство теоремы. Поскольку степень графа - K, то произвольная вершина может соседствовать с вершинами,
            // раскрашенными в K цветов. Тогда у нас остаётся цвет K+1, чтобы покрасить данную вершину.
        }
    }
}
