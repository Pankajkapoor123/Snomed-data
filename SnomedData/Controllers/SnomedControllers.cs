using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnomedData.Models;

namespace SnomedData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnomedControllers : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SnomedControllers(ApplicationDbContext context)
        {
            _context = context;       
        }
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        [RequestSizeLimit(long.MaxValue)]
        [HttpPost("UploadSnomedFile")]
        public async Task<IActionResult> UploadSnomedFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var concepts = new List<SnomedConcept>();

            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                string line;
                bool firstLine = true;

                while ((line = await stream.ReadLineAsync()) != null)
                {
                    // Skip header
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    // Split tab-separated values
                    var columns = line.Split('\t');
                    if (columns.Length < 5) continue;

                    var concept = new SnomedConcept
                    {
                        ConceptId = columns[0],
                        EffectiveTime = columns[1],
                        Active = columns[2] == "1",
                        ModuleId = columns[3],
                        DefinitionStatusId = columns[4]
                    };

                    concepts.Add(concept);
                }
            }

            // Save to DB
            _context.SnomedConcepts.AddRange(concepts);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"{concepts.Count} records saved successfully." });
        }
        [HttpPost("UploadSnomedDescriptionFile")]
        public async Task<IActionResult> UploadSnomedDescriptionFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var descriptions = new List<SnomedDescription>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                bool firstLine = true;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    // Skip header row
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    // Split values by tab
                    var columns = line.Split('\t');
                    if (columns.Length < 9) continue;

                    var desc = new SnomedDescription
                    {
                        DescriptionId = columns[0],
                        EffectiveTime = columns[1],
                        Active = columns[2] == "1",
                        ModuleId = columns[3],
                        ConceptId = columns[4],
                        LanguageCode = columns[5],
                        TypeId = columns[6],
                        Term = columns[7],
                        CaseSignificanceId = columns[8]
                    };

                    descriptions.Add(desc);
                }
            }

            // Save all in one transaction
            _context.SnomedDescriptions.AddRange(descriptions);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"{descriptions.Count} records saved successfully." });
        }
        [HttpPost("UploadConcreteValueFile")]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        [RequestSizeLimit(long.MaxValue)]
        public async Task<IActionResult> UploadConcreteValueFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var concreteValues = new List<SnomedConcreteValue>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                bool firstLine = true;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (firstLine) // skip header
                    {
                        firstLine = false;
                        continue;
                    }

                    var columns = line.Split('\t');
                    if (columns.Length < 10) continue;

                    var concrete = new SnomedConcreteValue
                    {
                        ConcreteValueId = columns[0],
                        EffectiveTime = columns[1],
                        Active = columns[2] == "1",
                        ModuleId = columns[3],
                        SourceId = columns[4],
                        Value = columns[5],
                        RelationshipGroup = int.TryParse(columns[6], out int group) ? group : 0,
                        TypeId = columns[7],
                        CharacteristicTypeId = columns[8],
                        ModifierId = columns[9]
                    };

                    concreteValues.Add(concrete);
                }
            }

            _context.SnomedConcreteValues.AddRange(concreteValues);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"{concreteValues.Count} concrete value records saved successfully." });
        }
        [HttpPost("UploadRelationshipFile")]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        [RequestSizeLimit(long.MaxValue)]
        public async Task<IActionResult> UploadRelationshipFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            int currentLine = 0;

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                bool firstLine = true;
                var relationships = new List<SnomedRelationship>();

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    currentLine++;

                    // Skip header
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                

                    var columns = line.Split('\t');
                    if (columns.Length < 10) continue;

                    var rel = new SnomedRelationship
                    {
                        RelationshipId = columns[0],
                        EffectiveTime = columns[1],
                        Active = columns[2] == "1",
                        ModuleId = columns[3],
                        SourceId = columns[4],
                        DestinationId = columns[5],
                        RelationshipGroup = int.TryParse(columns[6], out int group) ? group : 0,
                        TypeId = columns[7],
                        CharacteristicTypeId = columns[8],
                        ModifierId = columns[9]
                    };

                    relationships.Add(rel);

                    if (relationships.Count >= 50000)
                    {
                        await _context.SnomedRelationships.AddRangeAsync(relationships);
                        await _context.SaveChangesAsync();
                        relationships.Clear();
                    }
                }

            }

            return Ok(new { message = $"Relationship records saved successfully from line onwards." });
        }
        [HttpPost("UploadOwlExpressionFile")]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        [RequestSizeLimit(long.MaxValue)]
        public async Task<IActionResult> UploadOwlExpressionFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var owlExpressions = new List<SnomedOwlExpression>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                bool firstLine = true;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (firstLine) // skip header
                    {
                        firstLine = false;
                        continue;
                    }

                    var columns = line.Split('\t');
                    if (columns.Length < 7) continue;

                    var owl = new SnomedOwlExpression
                    {
                        OwlId = columns[0],
                        EffectiveTime = columns[1],
                        Active = columns[2] == "1",
                        ModuleId = columns[3],
                        RefsetId = columns[4],
                        ReferencedComponentId = columns[5],
                        OwlExpression = columns[6]
                    };

                    owlExpressions.Add(owl);
                }
            }

            _context.SnomedOwlExpressions.AddRange(owlExpressions);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"{owlExpressions.Count} OWL expression records saved successfully." });
        }
        [HttpPost("UploadStatedRelationshipFile")]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        [RequestSizeLimit(long.MaxValue)]
        public async Task<IActionResult> UploadStatedRelationshipFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var relationships = new List<StatedRelationship>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                bool firstLine = true;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    var columns = line.Split('\t');
                    if (columns.Length < 10) continue;

                    var rel = new StatedRelationship
                    {
                        RelationshipId = columns[0],
                        EffectiveTime = columns[1],
                        Active = columns[2] == "1",
                        ModuleId = columns[3],
                        SourceId = columns[4],
                        DestinationId = columns[5],
                        RelationshipGroup = int.TryParse(columns[6], out int group) ? group : 0,
                        TypeId = columns[7],
                        CharacteristicTypeId = columns[8],
                        ModifierId = columns[9]
                    };

                    relationships.Add(rel);
                }
            }

            _context.StatedRelationships.AddRange(relationships);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"{relationships.Count} stated relationship records saved successfully." });
        }
        [HttpPost("UploadTextDefinitionFile")]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        [RequestSizeLimit(long.MaxValue)]
        public async Task<IActionResult> UploadTextDefinitionFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var definitions = new List<SnomedTextDefinition>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                bool firstLine = true;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (firstLine) // Skip header row
                    {
                        firstLine = false;
                        continue;
                    }

                    var columns = line.Split('\t');
                    if (columns.Length < 9) continue;

                    var definition = new SnomedTextDefinition
                    {
                        SnomedTextDefinitionId = columns[0],
                        EffectiveTime = columns[1],
                        Active = columns[2] == "1",
                        ModuleId = columns[3],
                        ConceptId = columns[4],
                        LanguageCode = columns[5],
                        TypeId = columns[6],
                        Term = columns[7],
                        CaseSignificanceId = columns[8]
                    };

                    definitions.Add(definition);
                }
            }

            _context.TextDefinition.AddRange(definitions);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"{definitions.Count} text definition records saved successfully." });
        }
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        [RequestSizeLimit(long.MaxValue)]
        [HttpPost("UploadLoincFile")]
        public async Task<IActionResult> UploadLoincFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var loincRecords = new List<LoincRecord>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                bool firstLine = true;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    var columns = line.Split(',');

                    if (columns.Length < 39) continue; 

                    var record = new LoincRecord
                    {
                        LOINC_NUM = columns[0].Trim(),
                        COMPONENT = columns[1].Trim(),
                        PROPERTY = columns[2].Trim(),
                        TIME_ASPCT = columns[3].Trim(),
                        SYSTEM = columns[4].Trim(),
                        SCALE_TYP = columns[5].Trim(),
                        METHOD_TYP = columns[6].Trim(),
                        CLASS = columns[7].Trim(),
                        VersionLastChanged = columns[8].Trim(),
                        CHNG_TYPE = columns[9].Trim(),
                        DefinitionDescription = columns[10].Trim(),
                        STATUS = columns[11].Trim(),
                        CONSUMER_NAME = columns[12].Trim(),
                        CLASSTYPE = columns[13].Trim(),
                        FORMULA = columns[14].Trim(),
                        EXMPL_ANSWERS = columns[15].Trim(),
                        SURVEY_QUEST_TEXT = columns[16].Trim(),
                        SURVEY_QUEST_SRC = columns[17].Trim(),
                        UNITSREQUIRED = columns[18].Trim(),
                        RELATEDNAMES2 = columns[19].Trim(),
                        SHORTNAME = columns[20].Trim(),
                        ORDER_OBS = columns[21].Trim(),
                        HL7_FIELD_SUBFIELD_ID = columns[22].Trim(),
                        EXTERNAL_COPYRIGHT_NOTICE = columns[23].Trim(),
                        EXAMPLE_UNITS = columns[24].Trim(),
                        LONG_COMMON_NAME = columns[25].Trim(),
                        EXAMPLE_UCUM_UNITS = columns[26].Trim(),
                        STATUS_REASON = columns[27].Trim(),
                        STATUS_TEXT = columns[28].Trim(),
                        CHANGE_REASON_PUBLIC = columns[29].Trim(),
                        COMMON_TEST_RANK = columns[30].Trim(),
                        COMMON_ORDER_RANK = columns[31].Trim(),
                        HL7_ATTACHMENT_STRUCTURE = columns[32].Trim(),
                        EXTERNAL_COPYRIGHT_LINK = columns[33].Trim(),
                        PanelType = columns[34].Trim(),
                        AskAtOrderEntry = columns[35].Trim(),
                        AssociatedObservations = columns[36].Trim(),
                        VersionFirstReleased = columns[37].Trim(),
                        ValidHL7AttachmentRequest = columns[38].Trim(),
                        DisplayName = columns.Length > 39 ? columns[39].Trim() : null
                    };

                    loincRecords.Add(record);
                }
            }

            _context.LoincRecords.AddRange(loincRecords);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"{loincRecords.Count} LOINC records saved successfully." });
        }

    }
}
