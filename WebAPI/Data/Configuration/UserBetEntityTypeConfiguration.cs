using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Data.Configuration
{
    public class UserBetEntityTypeConfiguration : IEntityTypeConfiguration<UserBet>
    {
        public void Configure(EntityTypeBuilder<UserBet> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.User)
                .WithMany(a => a.UserBets)
                .HasForeignKey(a => a.UserId);

            builder.HasOne(f => f.BetOption)
               .WithMany(a => a.UserBets)
               .HasForeignKey(a => a.BetOptionId);

            builder.Property(f => f.Amount)
              .IsRequired();           

            builder.Property(f => f.RegistrationDate)
               .HasDefaultValue(DateTime.Now);
        }
    }
}
