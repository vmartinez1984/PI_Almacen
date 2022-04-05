using System.Collections.Generic;

namespace Activities.Dtos
{
    public class ActivitySummaryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Dictionary<string, int> Data { get; set; }
    }
}