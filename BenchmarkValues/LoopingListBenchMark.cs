using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkValues
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LoopingListBenchMark
    {
        string[] items = {"1", "2", "3", "4", "5"};
        readonly LoopingList loopingList = new LoopingList();

        [Benchmark]
        public void ForEachSequential() {
            loopingList.ForEachSequential(items);
        }

        [Benchmark]
        public void AsParallelForAll() {
            loopingList.AsParallelForAll(items);
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