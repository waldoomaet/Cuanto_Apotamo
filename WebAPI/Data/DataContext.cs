using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WebAPI.Data.Configuration;
using WebAPI.Domain;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BalanceTransaction> BalanceTransactions { get; set; }
        public DbSet<BetOption> BetOptions { get; set; }
        public DbSet<UserBet> UserBets { get; set; }



        public IConfiguration Configuration { get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BalanceTransactionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BetEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserBetEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BetOptionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());


        }
    }
}
