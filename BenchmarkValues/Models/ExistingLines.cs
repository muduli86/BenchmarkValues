using System;
using System.Collections.Generic;

namespace BenchmarkValues.Models
{
    public class ExistingLines
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public int Estimated { get; set; }

        public int Elapsed { get; set; }

        public bool Clockable { get; set; }

        public string Type { get; set; }

        public string Notes { get; set; }

        public string LinePayer { get; set; }

        public List<WorkNote> WorkNotes { get; set; }

        public List<PartDetails> Parts { get; set; }

        public List<Technician> TechnicianDetails { get; set; }
        public List<TechnicianWithStartDate> ActiveTechnicians { get; set; }

        public List<ExistingLines> Lines { get; set; }

        public DateTime? Started { get; set; }
    }

    public class WorkItem
    {
        public string WorkItemId { get; set; }

        public string WorkItemNotes { get; set; }
    }

    public class WorkNote
    {
        public DateTime? time { get; set; }

        public string workItemNotes { get; set; }
    }

    public class PartDetails
    {
        public string BrandCode { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public double? RequiredQty { get; set; }
        public string PartNumber { get; set; }
        public bool? SalesBlocked { get; set; }
        public int? StockQty { get; set; }
        public string Type { get; set; }
        public double? UnitOfSale { get; set; }
        public List<PartDetails> Alternatives { get; set; }
    }

    public class Technician
    {
        public string Name { get; set; }

        public string Initials { get; set; }
    }

    public class TechnicianWithStartDate : Technician
    {
        public DateTime? StartDateTime { get; set; }
        public int TotalEstimatedTime { get; set; }
        public List<string> WorkItemsWithId { get; set; }
    }
}