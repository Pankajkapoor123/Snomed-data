namespace SnomedData.Models
{
    public class SnomedTextDefinition
    {
        public int Id { get; set; }
        public string SnomedTextDefinitionId { get; set; }
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
