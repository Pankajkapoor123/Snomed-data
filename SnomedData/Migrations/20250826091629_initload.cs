using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SnomedData.Migrations
{
    /// <inheritdoc />
    public partial class initload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SnomedConcepts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConceptId = table.Column<string>(type: "text", nullable: false),
                    EffectiveTime = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModuleId = table.Column<string>(type: "text", nullable: false),
                    DefinitionStatusId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnomedConcepts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnomedConcreteValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConcreteValueId = table.Column<string>(type: "text", nullable: false),
                    EffectiveTime = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModuleId = table.Column<string>(type: "text", nullable: false),
                    SourceId = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    RelationshipGroup = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<string>(type: "text", nullable: false),
                    CharacteristicTypeId = table.Column<string>(type: "text", nullable: false),
                    ModifierId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnomedConcreteValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnomedDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescriptionId = table.Column<string>(type: "text", nullable: false),
                    EffectiveTime = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModuleId = table.Column<string>(type: "text", nullable: false),
                    ConceptId = table.Column<string>(type: "text", nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<string>(type: "text", nullable: false),
                    Term = table.Column<string>(type: "text", nullable: false),
                    CaseSignificanceId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnomedDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnomedOwlExpressions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwlId = table.Column<string>(type: "text", nullable: false),
                    EffectiveTime = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModuleId = table.Column<string>(type: "text", nullable: false),
                    RefsetId = table.Column<string>(type: "text", nullable: false),
                    ReferencedComponentId = table.Column<string>(type: "text", nullable: false),
                    OwlExpression = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnomedOwlExpressions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnomedRelationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RelationshipId = table.Column<string>(type: "text", nullable: false),
                    EffectiveTime = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModuleId = table.Column<string>(type: "text", nullable: false),
                    SourceId = table.Column<string>(type: "text", nullable: false),
                    DestinationId = table.Column<string>(type: "text", nullable: false),
                    RelationshipGroup = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<string>(type: "text", nullable: false),
                    CharacteristicTypeId = table.Column<string>(type: "text", nullable: false),
                    ModifierId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnomedRelationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatedRelationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RelationshipId = table.Column<string>(type: "text", nullable: false),
                    EffectiveTime = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModuleId = table.Column<string>(type: "text", nullable: false),
                    SourceId = table.Column<string>(type: "text", nullable: false),
                    DestinationId = table.Column<string>(type: "text", nullable: false),
                    RelationshipGroup = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<string>(type: "text", nullable: false),
                    CharacteristicTypeId = table.Column<string>(type: "text", nullable: false),
                    ModifierId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatedRelationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SnomedTextDefinitionId = table.Column<string>(type: "text", nullable: false),
                    EffectiveTime = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    ModuleId = table.Column<string>(type: "text", nullable: false),
                    ConceptId = table.Column<string>(type: "text", nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<string>(type: "text", nullable: false),
                    Term = table.Column<string>(type: "text", nullable: false),
                    CaseSignificanceId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextDefinition", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SnomedConcepts");

            migrationBuilder.DropTable(
                name: "SnomedConcreteValues");

            migrationBuilder.DropTable(
                name: "SnomedDescriptions");

            migrationBuilder.DropTable(
                name: "SnomedOwlExpressions");

            migrationBuilder.DropTable(
                name: "SnomedRelationships");

            migrationBuilder.DropTable(
                name: "StatedRelationships");

            migrationBuilder.DropTable(
                name: "TextDefinition");
        }
    }
}
