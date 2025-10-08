namespace SnomedData.Models
{
    public class SnomedConcept
    {
        public int Id { get; set; }
        public string ConceptId { get; set; }
        public string EffectiveTime { get; set; }
        public bool Active { get; set; }
        public string ModuleId { get; set; }
        public string DefinitionStatusId { get; set; }
    }
}
