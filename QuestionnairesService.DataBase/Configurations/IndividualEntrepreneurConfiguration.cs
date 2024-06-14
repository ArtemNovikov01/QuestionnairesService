using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuestionnairesService.Models.Entities;

namespace QuestionnairesService.DataBase.Configurations;
public class IndividualEntrepreneurConfiguration : IEntityTypeConfiguration<IndividualEntrepreneur>
{
    public void Configure(EntityTypeBuilder<IndividualEntrepreneur> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.RegistrationNumber)
            .IsRequired();

        builder.Property(i => i.SkanContractRent)
            .IsRequired();

        builder.Property(i => i.SkanExtractFromTax)
            .IsRequired();

        builder.Property(i => i.BankRequisites)
            .IsRequired();

        builder.Property(i => i.INN)
            .IsRequired();

        builder.Property(i => i.SkanINN)
            .IsRequired();

        builder.Property(i => i.SkanRegistrationNumber)
            .IsRequired();

        builder.Property(i => i.AvailabilityContract)
            .IsRequired();
    }
}
