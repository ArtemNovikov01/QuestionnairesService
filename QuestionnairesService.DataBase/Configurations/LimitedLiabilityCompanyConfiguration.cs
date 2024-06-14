﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuestionnairesService.Models.Entities;

namespace QuestionnairesService.DataBase.Configurations;
public class LimitedLiabilityCompanyConfiguration : IEntityTypeConfiguration<LimitedLiabilityCompany>
{
    public void Configure(EntityTypeBuilder<LimitedLiabilityCompany> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.FullName)
            .IsRequired();

        builder.Property(l => l.ShortName)
            .IsRequired();

        builder.Property(l => l.RegistrationNumber)
            .IsRequired();

        builder.Property(l => l.SkanContractRent)
            .IsRequired();

        builder.Property(l => l.SkanExtractFromTax)
            .IsRequired();

        builder.Property(l => l.BankRequisites)
            .IsRequired();

        builder.Property(l => l.INN)
            .IsRequired();

        builder.Property(l => l.SkanINN)
            .IsRequired();

        builder.Property(l => l.SkanRegistrationNumber)
            .IsRequired();

        builder.Property(l => l.AvailabilityContract)
            .IsRequired();
    }
}
