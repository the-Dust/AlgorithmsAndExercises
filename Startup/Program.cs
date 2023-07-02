using AlgorithmicWarmUp;
using DivideConquer;
using DynamicProgramming;
using GreedyAlgorithms;
using Leetcode;
using System.Reflection;
using Utils;

class StartUp
{
    public static void Main(string[] args)
    {
        PrintTasks(5);

        //var res = new Lc3();
        //res.SelfTest();

        void PrintTasks(int n)
        {
            //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            var tasks = new TasksPicker(new StartUp()).Get(n);
            Console.WriteLine(string.Join(Environment.NewLine, tasks));
        }
    }
}