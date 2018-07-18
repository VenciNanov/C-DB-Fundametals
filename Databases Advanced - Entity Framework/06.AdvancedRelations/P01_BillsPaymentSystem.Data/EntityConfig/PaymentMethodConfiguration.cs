using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public PaymentMethodConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new
            {
                e.UserId,
                e.BankAccountId,
                e.CreditCardId
            });

            builder.HasOne(e => e.BankAccount)
                .WithOne(x => x.PaymentMethod)
                .HasForeignKey<PaymentMethod>(x => x.BankAccountId);

            builder.HasOne(e => e.CreditCard)
                .WithOne(x => x.PaymentMethod)
                .HasForeignKey<PaymentMethod>(x => x.CreditCardId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.PaymentMethods)
                .HasForeignKey(x => x.UserId);

        }
    }
}
