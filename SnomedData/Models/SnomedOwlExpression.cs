public class SnomedOwlExpression
{
    public int Id { get; set; } // DB PK (auto increment)

    public string OwlId { get; set; }   // "id" from file (UUID/GUID)
    public string EffectiveTime { get; set; }
    public bool Active { get; set; }
    public string ModuleId { get; set; }
    public string RefsetId { get; set; }
    public string ReferencedComponentId { get; set; }
    public string OwlExpression { get; set; }
}
