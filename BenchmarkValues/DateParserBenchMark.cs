using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkValues
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParserBenchMark
    {
        const string DateTime = "2022-06-29T08:52:07Z";
        readonly DateParser parser = new DateParser();

        [Benchmark]
        public void GetYear() {
            parser.GetYearFromDate(DateTime);
        }

        [Benchmark]
        public void GetYearFromDateSplit()
        {
            parser.GetYearFromDateSplit(DateTime);
        }

        [Benchmark]
        public void GetYearFromDateSubString()
        {
            parser.GetYearFromDateSubString(DateTime);
        }

        [Benchmark]
        public void GetYearFromDateSpan()
        {
            parser.GetYearFromDateSpan(DateTime);
        }

    }
}

// * Summary *

// BenchmarkDotNet = v0.13.1, OS = Windows 10.0.18363.2274(1909 / November2019Update / 19H2)
// Intel Core i7-10850H CPU 2.70GHz, 1 CPU, 12 logical and 6 physical cores
// [Host]     : .NET Core 3.1.22 (CoreCLR 4.700.21.56803, CoreFX 4.700.21.57101), X64 RyuJIT
// DefaultJob : .NET Core 3.1.22 (CoreCLR 4.700.21.56803, CoreFX 4.700.21.57101), X64 RyuJIT
//
//
//     |                   Method |      Mean |    Error  |    StdDev  | Rank  |  Gen 0  | Allocated  |
//     |------------------------- |----------:| ---------:| ----------:| -----:| -------:| ----------:|
//     | GetYearFromDateSpan      | 20.89 ns  | 0.439 ns  | 0.556 ns   | 1     | -       | -          |
//     | GetYearFromDateSubString | 27.22 ns  | 0.220 ns  | 0.184 ns   | 2     | 0.0051  | 32 B       |
//     | GetYearFromDateSplit     | 87.60 ns  | 1.612 ns  | 2.648 ns   | 3     | 0.0254  | 160 B      |
//     | GetYear                  | 310.79 ns | 6.238 ns  | 11.248 ns  | 4     | -       | -          |
//
// // * Hints *
// Outliers
// DateParserBenchMark.GetYearFromDateSpan: Default-> 1 outlier was  removed (24.14 ns)
// DateParserBenchMark.GetYearFromDateSubString: Default-> 2 outliers were removed (29.65 ns, 31.21 ns)
// DateParserBenchMark.GetYearFromDateSplit: Default-> 4 outliers were removed (96.83 ns..110.49 ns)
// DateParserBenchMark.GetYear: Default-> 2 outliers were removed (348.77 ns, 353.16 ns)
//
// // * Legends *
// Mean: Arithmetic mean of all measurements
// Error     : Half of 99.9% confidence interval
// StdDev    : Standard deviation of all measurements
// Rank      : Relative position of current benchmark mean among all benchmarks (Arabic style)
// Gen 0     : GC Generation 0 collects per 1000 operations
// Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
// 1 ns: 1 Nanosecond(0.000000001 sec)



