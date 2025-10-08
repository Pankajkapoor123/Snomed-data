
using Microsoft.EntityFrameworkCore;
using SnomedData.Models;

namespace API.Data
{
    public class ApplicationDbContext :DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            

        }
       public DbSet<SnomedConcept> SnomedConcepts { get; set; }
        //  public DbSet<AadharOtpRequest> AadharOtpRequests { get; set; }
        public DbSet<SnomedDescription> SnomedDescriptions { get; set; }
        public DbSet<SnomedConcreteValue> SnomedConcreteValues { get; set; }
        public DbSet<SnomedRelationship> SnomedRelationships { get; set; }

        public DbSet<SnomedOwlExpression> SnomedOwlExpressions { get; set; }
        public DbSet<SnomedTextDefinition> TextDefinition { get; set; }

        public DbSet<StatedRelationship> StatedRelationships { get; set; }
        public DbSet<LoincRecord> LoincRecords { get; set; }
        public DbSet<SampleType> SampleTypes { get; set; }


    }
}
    

