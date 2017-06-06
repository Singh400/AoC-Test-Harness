using System;
using System.Diagnostics;
using AoC._2016._05;

namespace AoC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.MonitoringIsEnabled = true;
            ISolveProblem problem = new Problem_2016_05();
            Stopwatch sw = Stopwatch.StartNew();
            problem.Solve();
            sw.Stop();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Took: {sw.Elapsed.TotalMilliseconds} ms ({sw.Elapsed.TotalSeconds} secs)");
            Console.WriteLine($"Allocated: {AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize/1024:#,#} kb");
            Console.WriteLine($"Peak Working Set: {Process.GetCurrentProcess().PeakWorkingSet64/1024:#,#} kb");
        }
    }
}