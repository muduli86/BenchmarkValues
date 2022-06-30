using BenchmarkDotNet.Running;

namespace BenchmarkValues
{
    internal class Program
    {
        static void Main(string[] args) {
            BenchmarkRunner.Run<LoopingListComplexBenchMark>();

            // var ExistingLinesMock = Helpers.BuildResponse("ExistingLines.json");
            // List<ExistingLines> lines = JsonConvert.DeserializeObject<List<ExistingLines>>(ExistingLinesMock);
            // LoopingListComplex loopingList= new LoopingListComplex();
            // loopingList.ForEachSequentialComplex(lines);
        }
    }
}

// run the run-benchmark.bat file