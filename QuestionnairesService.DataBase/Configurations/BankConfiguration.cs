using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionnairesService.Models.Entities;

namespace QuestionnairesService.DataBase.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.BankCode)
                .IsRequired();

            builder.Property(b => b.PaymentAccount)
                .IsRequired();

            builder.Property(b => b.BranchOfficeName)
                .IsRequired();

            builder.HasOne(b => b.Organization)
                .WithMany(l => l.Banks)
                .IsRequired();
        }
    }
}
