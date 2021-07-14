using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.MasterModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configuration
{
    public class DnaConfiguration : GenericConfiguration<Dna>
    {
        public override void Configure(EntityTypeBuilder<Dna> builder)
        {
            base.Configure(builder);
            builder.ToTable("Dna", "dbo");
        }
    }
}
