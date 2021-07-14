using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.People;
using Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Configuration
{
    public class PeopleConfiguration:GenericConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            builder.ToTable("People", "dbo");
            builder.Property(x => x.Description).HasColumnName("name");

            builder.HasOne(x => x.Country).WithMany().HasForeignKey(x => x.IdCountry);
            builder.HasOne(x => x.Result).WithMany().HasForeignKey(x => x.IdResult);
            builder.HasMany(x => x.Dna).WithOne().HasForeignKey(x => x.Id);

            builder.Ignore(x => x.IdCountry);
            builder.Ignore(x => x.IdDna);
            builder.Ignore(x => x.IdResult);

        }
    }
}
