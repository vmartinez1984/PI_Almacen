using System.Collections.Generic;

namespace Activities.Dtos
{
    public class ActivitySummaryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<RowStatusDto> ListRowStatus { get; set; }
    }

    public class RowStatusDto
    {
        public string Name { get; set; }

        public int Total { get; set; }

        public string Color { get; set; }
    }
}