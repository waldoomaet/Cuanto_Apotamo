using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Data.Configuration
{
    public class BalanceTransactionEntityTypeConfiguration : IEntityTypeConfiguration<BalanceTransaction>
    {
        public void Configure(EntityTypeBuilder<BalanceTransaction> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.User)
                .WithMany(a => a.BalanceTransactions)
                .HasForeignKey(a => a.UserID)
                /*.OnDelete(DeleteBehavior.Cascade)*/;


            builder.Property(f => f.Balance)
                .IsRequired();

            
            builder.Property(f => f.RegistrationDate)
               .HasDefaultValue(DateTime.Now);
        }
    }
}
