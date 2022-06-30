using System.Collections.Generic;
using System.Linq;

namespace BenchmarkValues
{
    public class LoopingList
    {
        public IEnumerable<string> ForEachSequential(IEnumerable<string> items) {
            var result = new List<string>();
            foreach (var n in items) {
                result.Add(n);
            }

            return result;
        }

        public IEnumerable<string> AsParallelForAll(IEnumerable<string> items) {
            var result = new List<string>();
            items.AsParallel().ForAll(n => result.Add(n));
            return result;
        }
    }
}