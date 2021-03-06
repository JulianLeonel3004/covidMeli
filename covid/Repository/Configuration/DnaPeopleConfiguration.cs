using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Configuration
{
    public class DnaPeopleConfiguration
    {
        public DnaPeopleConfiguration (EntityTypeBuilder<DnaPeople> builder)
        {
            builder.ToTable("DNAPeople", "dbo");

            builder.HasKey(x=>x.Id);
            builder.Property(x => x.IdDna).IsRequired();
            builder.Property(x => x.IdPeople).IsRequired();
        }
    }
}
