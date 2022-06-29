using System;
using BenchmarkDotNet.Running;

namespace BenchmarkValues
{
    internal class Program
    {
        static void Main(string[] args) {
            BenchmarkRunner.Run<DateParserBenchMark>();
        }
    }
}

// run the run-benchmark.bat file