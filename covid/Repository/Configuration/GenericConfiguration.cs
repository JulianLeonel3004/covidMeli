using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configuration
{
    public class GenericConfiguration<T>: IEntityTypeConfiguration<T> where T : Generic
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
