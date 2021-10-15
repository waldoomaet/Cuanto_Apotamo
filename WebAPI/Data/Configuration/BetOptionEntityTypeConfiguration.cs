using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Data.Configuration
{
    public class BetOptionEntityTypeConfiguration : IEntityTypeConfiguration<BetOption>
    {
        public void Configure(EntityTypeBuilder<BetOption> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.Bet)
                .WithMany(a => a.BetOptions)
                .HasForeignKey(a => a.BetId);

            builder.Property(f => f.Title)
              .IsRequired();

            builder.Property(f => f.TotalBets)
             .IsRequired();

            builder.Property(f => f.Stake)
             .IsRequired();

            builder.Property(f => f.TotalPlayers)
             .IsRequired();

            builder.Property(f => f.DidWin)
             .IsRequired();

            builder.Property(f => f.RegistrationDate)
               .HasDefaultValue(DateTime.Now);
        }
    }
}
