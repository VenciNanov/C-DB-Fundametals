using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public BankAccountConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(e => e.BankAccountId);

            builder.Property(e => e.Balance)
                .IsRequired(true);

            builder.Property(e => e.BankName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(e => e.SWIFTCode)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(20);
        }
    }
}
