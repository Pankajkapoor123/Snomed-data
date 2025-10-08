using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnomedData.Migrations
{
    /// <inheritdoc />
    public partial class addlonicrecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoincRecords",
                columns: table => new
                {
                    LOINC_NUM = table.Column<string>(type: "text", nullable: false),
                    COMPONENT = table.Column<string>(type: "text", nullable: false),
                    PROPERTY = table.Column<string>(type: "text", nullable: false),
                    TIME_ASPCT = table.Column<string>(type: "text", nullable: false),
                    SYSTEM = table.Column<string>(type: "text", nullable: false),
                    SCALE_TYP = table.Column<string>(type: "text", nullable: false),
                    METHOD_TYP = table.Column<string>(type: "text", nullable: false),
                    CLASS = table.Column<string>(type: "text", nullable: false),
                    VersionLastChanged = table.Column<string>(type: "text", nullable: false),
                    CHNG_TYPE = table.Column<string>(type: "text", nullable: false),
                    DefinitionDescription = table.Column<string>(type: "text", nullable: false),
                    STATUS = table.Column<string>(type: "text", nullable: false),
                    CONSUMER_NAME = table.Column<string>(type: "text", nullable: false),
                    CLASSTYPE = table.Column<string>(type: "text", nullable: false),
                    FORMULA = table.Column<string>(type: "text", nullable: false),
                    EXMPL_ANSWERS = table.Column<string>(type: "text", nullable: false),
                    SURVEY_QUEST_TEXT = table.Column<string>(type: "text", nullable: false),
                    SURVEY_QUEST_SRC = table.Column<string>(type: "text", nullable: false),
                    UNITSREQUIRED = table.Column<string>(type: "text", nullable: false),
                    RELATEDNAMES2 = table.Column<string>(type: "text", nullable: false),
                    SHORTNAME = table.Column<string>(type: "text", nullable: false),
                    ORDER_OBS = table.Column<string>(type: "text", nullable: false),
                    HL7_FIELD_SUBFIELD_ID = table.Column<string>(type: "text", nullable: false),
                    EXTERNAL_COPYRIGHT_NOTICE = table.Column<string>(type: "text", nullable: false),
                    EXAMPLE_UNITS = table.Column<string>(type: "text", nullable: false),
                    LONG_COMMON_NAME = table.Column<string>(type: "text", nullable: false),
                    EXAMPLE_UCUM_UNITS = table.Column<string>(type: "text", nullable: false),
                    STATUS_REASON = table.Column<string>(type: "text", nullable: false),
                    STATUS_TEXT = table.Column<string>(type: "text", nullable: false),
                    CHANGE_REASON_PUBLIC = table.Column<string>(type: "text", nullable: false),
                    COMMON_TEST_RANK = table.Column<string>(type: "text", nullable: false),
                    COMMON_ORDER_RANK = table.Column<string>(type: "text", nullable: false),
                    HL7_ATTACHMENT_STRUCTURE = table.Column<string>(type: "text", nullable: false),
                    EXTERNAL_COPYRIGHT_LINK = table.Column<string>(type: "text", nullable: false),
                    PanelType = table.Column<string>(type: "text", nullable: false),
                    AskAtOrderEntry = table.Column<string>(type: "text", nullable: false),
                    AssociatedObservations = table.Column<string>(type: "text", nullable: false),
                    VersionFirstReleased = table.Column<string>(type: "text", nullable: false),
                    ValidHL7AttachmentRequest = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoincRecords", x => x.LOINC_NUM);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoincRecords");
        }
    }
}
