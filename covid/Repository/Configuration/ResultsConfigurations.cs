using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.MasterModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configuration
{
    public class ResultsConfigurations : GenericConfiguration<Result>
    {
        public override void Configure(EntityTypeBuilder<Result> builder)
        {
            base.Configure(builder);
            builder.ToTable("Results", "dbo");
        }
    }
}
