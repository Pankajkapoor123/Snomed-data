public class SnomedConcreteValue
{
    public int Id { get; set; } // DB PK (auto increment)

    public string ConcreteValueId { get; set; }   // "id" from file
    public string EffectiveTime { get; set; }
    public bool Active { get; set; }
    public string ModuleId { get; set; }
    public string SourceId { get; set; }
    public string Value { get; set; }  // e.g., numeric value or string
    public int RelationshipGroup { get; set; }
    public string TypeId { get; set; }
    public string CharacteristicTypeId { get; set; }
    public string ModifierId { get; set; }
}
