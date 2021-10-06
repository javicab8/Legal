using System;

namespace Legal.Backend.Model
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