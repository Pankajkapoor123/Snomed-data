namespace SnomedData.Models
{
    public class SnomedDescription
    {
     
            public int Id { get; set; } // Primary Key in DB (auto increment)

            public string DescriptionId { get; set; }   // "id" from file
            public string EffectiveTime { get; set; }
            public bool Active { get; set; }
            public string ModuleId { get; set; }
            public string ConceptId { get; set; }
            public string LanguageCode { get; set; }
            public string TypeId { get; set; }
            public string Term { get; set; }
            public string CaseSignificanceId { get; set; }
        }

    
}
