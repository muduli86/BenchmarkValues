using System.Collections.Generic;
using System.Linq;
using BenchmarkValues.Models;

namespace BenchmarkValues
{
    public class LoopingListComplex
    {
        public void AsParallelForAllComplex(List<ExistingLines> lines) {
            lines.AsParallel()
                .ForAll(l => l.Lines?.AsParallel()
                    .ForAll(s => s.Lines?.AsParallel()
                        .ForAll(t => t.ActiveTechnicians?.AsParallel()
                            .ForAll(tech => tech.WorkItemsWithId?.ForEach(w => { tech.TotalEstimatedTime += 100; })))));
        }

        internal void ForEachSequentialComplex(List<ExistingLines> lines) {
            foreach (var l1 in lines) {
                foreach (var l2 in l1?.Lines) {
                    if (l2?.Lines != null)
                        foreach (var l3 in l2?.Lines) {
                            foreach (var t1 in l3?.ActiveTechnicians) {
                                foreach (var workItems in t1?.WorkItemsWithId) {
                                    foreach (var w in workItems) {
                                        if (t1 != null) t1.TotalEstimatedTime += 100;
                                    }
                                }
                            }
                        }
                }
            }
        }
    }
}