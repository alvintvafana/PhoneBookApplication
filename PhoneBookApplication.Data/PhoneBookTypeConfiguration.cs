using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApplication.Data
{
    internal class PhoneBookTypeConfiguration : IEntityTypeConfiguration<PhoneBookAggregateRoot>
    {
        public void Configure(EntityTypeBuilder<PhoneBookAggregateRoot> walletConfiguration)
        {
            walletConfiguration.ToTable("PhoneBook", PhoneBookContext.DEFAULT_SCHEMA);
            // Other configuration
            // ...
            var navigation =
            walletConfiguration.Metadata.FindNavigation(nameof(PhoneBookAggregateRoot.Entries));
            //EF access the OrderItem collection property through its backing field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            // Other configuration
            // ...
        }
    }
}
