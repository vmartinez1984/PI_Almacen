using System.Collections.Generic;

namespace Files.Models
{
    public class Folder: BaseEntity
    {
        public string Name { get; set; }
        public int? FolderId { get; set; }

        public List<Archive> ListArchives { get; set; }
    }
}
