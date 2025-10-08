using System.ComponentModel.DataAnnotations;

namespace SnomedData.Models
{
    public class LoincRecord
    {
        [Key]
        public string LOINC_NUM { get; set; }
        public string COMPONENT { get; set; }
        public string PROPERTY { get; set; }
        public string TIME_ASPCT { get; set; }
        public string SYSTEM { get; set; }
        public string SCALE_TYP { get; set; }
        public string METHOD_TYP { get; set; }
        public string CLASS { get; set; }
        public string VersionLastChanged { get; set; }
        public string CHNG_TYPE { get; set; }
        public string DefinitionDescription { get; set; }
        public string STATUS { get; set; }
        public string CONSUMER_NAME { get; set; }
        public string CLASSTYPE { get; set; }
        public string FORMULA { get; set; }
        public string EXMPL_ANSWERS { get; set; }
        public string SURVEY_QUEST_TEXT { get; set; }
        public string SURVEY_QUEST_SRC { get; set; }
        public string UNITSREQUIRED { get; set; }
        public string RELATEDNAMES2 { get; set; }
        public string SHORTNAME { get; set; }
        public string ORDER_OBS { get; set; }
        public string HL7_FIELD_SUBFIELD_ID { get; set; }
        public string EXTERNAL_COPYRIGHT_NOTICE { get; set; }
        public string EXAMPLE_UNITS { get; set; }
        public string LONG_COMMON_NAME { get; set; }
        public string EXAMPLE_UCUM_UNITS { get; set; }
        public string STATUS_REASON { get; set; }
        public string STATUS_TEXT { get; set; }
        public string CHANGE_REASON_PUBLIC { get; set; }
        public string COMMON_TEST_RANK { get; set; }
        public string COMMON_ORDER_RANK { get; set; }
        public string HL7_ATTACHMENT_STRUCTURE { get; set; }
        public string EXTERNAL_COPYRIGHT_LINK { get; set; }
        public string PanelType { get; set; }
        public string AskAtOrderEntry { get; set; }
        public string AssociatedObservations { get; set; }
        public string VersionFirstReleased { get; set; }
        public string ValidHL7AttachmentRequest { get; set; }
        public string DisplayName { get; set; }
    }
}
