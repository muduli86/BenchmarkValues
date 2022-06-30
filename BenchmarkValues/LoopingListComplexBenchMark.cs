using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkValues.Models;
using BenchmarkValues.Utils;
using Newtonsoft.Json;

namespace BenchmarkValues
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LoopingListComplexBenchMark
    {
        readonly LoopingListComplex loopingList = new LoopingListComplex();
        public static string ExistingLinesMock => Helpers.BuildResponse("ExistingLines.json");
        List<ExistingLines> lines = JsonConvert.DeserializeObject<List<ExistingLines>>(ExistingLinesMock);

        [Benchmark]
        public void ForEachSequential() {
            loopingList.ForEachSequentialComplex(lines);
        }

        [Benchmark]
        public void AsParallelForAll() {
            loopingList.AsParallelForAllComplex(lines);
        }
    }
}

// * Summary *

// BenchmarkDotNet = v0.13.1, OS = Windows 10.0.18363.2274(1909 / November2019Update / 19H2)
// Intel Core i7-10850H CPU 2.70GHz, 1 CPU, 12 logical and 6 physical cores
//     .NET SDK=6.0.101
//     [Host]     : .NET Core 3.1.22 (CoreCLR 4.700.21.56803, CoreFX 4.700.21.57101), X64 RyuJIT
// DefaultJob : .NET Core 3.1.22 (CoreCLR 4.700.21.56803, CoreFX 4.700.21.57101), X64 RyuJIT
//
//
//     |            Method |        Mean |      Error  |     StdDev  | Rank  |  Gen 0  | Allocated  |
//     |------------------ |------------:| -----------:| -----------:| -----:| -------:| ----------:|
//     | ForEachSequential | 83.36 ns    | 1.665 ns    | 1.390 ns    | 1     | 0.0331  | 208 B      |
//     | AsParallelForAll  | 9,586.53 ns | 186.561 ns  | 183.228 ns  | 2     | 0.9155  | 5,752 B    |