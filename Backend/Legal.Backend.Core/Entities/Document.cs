using System;

namespace Legal.Backend.Core.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Settlement { get; set; }
        public DateTime RegisterAt { get; set; }
        public string Applicant { get; set; }
        public int DocumentTypeId { get; set; }
    }
}