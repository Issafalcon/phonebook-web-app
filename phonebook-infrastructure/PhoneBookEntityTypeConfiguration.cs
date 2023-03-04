using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using phonebook_core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phonebook_infrastructure
{
    internal class PhoneBookEntryEntityTypeConfiguration : IEntityTypeConfiguration<PhoneBookEntry>
    {
        public void Configure(EntityTypeBuilder<PhoneBookEntry> builder)
        {
            builder.ToTable("PhoneBookEntry")
                .HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .UseHiLo("phonebook_hilo");

            builder.Property(b => b.FirstName)
                .IsRequired();

            builder.Property(b => b.LastName)
                .IsRequired();

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(12);
        }
    }
}
