using System.Collections.Generic;

namespace Legal.Backend.Model
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string Process { get; set; }
        public string Name { get; set; }
        public string Subdocument { get; set; }
        public string ControlMedium { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();
    }
}