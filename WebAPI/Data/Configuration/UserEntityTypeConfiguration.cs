using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Data.Configuration
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.FullName)
              .IsRequired();

            builder.Property(f => f.Username)
             .IsRequired();
            
            builder.Property(f => f.IdentificationDocument)
             .IsRequired();

            builder.Property(f => f.Email)
             .IsRequired();

            builder.Property(f => f.CreditCardNumber)
             .IsRequired();

            builder.Property(f => f.CVV)
             .IsRequired();

            builder.Property(f => f.CreditCardExpirationDate)
             .IsRequired();

            builder.Property(f => f.Password)
             .IsRequired();

            builder.Property(f => f.Balance)
             .IsRequired();

            builder.HasMany(s => s.UserBets)
               .WithOne(sp => sp.User)
               .HasForeignKey(sp => sp.UserId);

            builder.HasMany(s => s.BalanceTransactions)
               .WithOne(sp => sp.User)
               .HasForeignKey(sp => sp.UserID);

            builder.Property(f => f.RegistrationDate)
               .HasDefaultValue(DateTime.Now);
        }
    }
}
