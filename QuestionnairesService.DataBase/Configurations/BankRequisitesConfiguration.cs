using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuestionnairesService.Models.Entities;

namespace QuestionnairesService.DataBase.Configurations;
public class BankRequisitesConfiguration : IEntityTypeConfiguration<BankRequisites>
{
    public void Configure(EntityTypeBuilder<BankRequisites> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.BankCode)
            .IsRequired();

        builder.Property(b => b.PaymentAccount)
            .IsRequired();

        builder.Property(b => b.CorrespondentAccount)
            .IsRequired();

        builder.Property(b => b.BranchOfficeName)
            .IsRequired();
    }
}
