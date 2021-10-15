using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Data.Configuration
{
    public class BetEntityTypeConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Title)
              .IsRequired();
            builder.Property(f => f.Description)
             .IsRequired();
            builder.Property(f => f.TotalBets)
             .IsRequired();
            builder.Property(f => f.TotalPlayers)
             .IsRequired();
            builder.Property(f => f.Status)
             .IsRequired();

            builder.HasMany(s => s.BetOptions)
               .WithOne(sp => sp.Bet)
               .HasForeignKey(sp => sp.BetId);

            builder.Property(f => f.RegistrationDate)
               .HasDefaultValue(DateTime.Now);
        }
    }
}
