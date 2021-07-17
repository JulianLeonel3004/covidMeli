using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.MasterModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configuration
{
    public class CountriesConfiguration : GenericConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);
            builder.ToTable("Countries", "dbo");

            builder.Property(x => x.Description).HasColumnName("name");
        }
    }
}
