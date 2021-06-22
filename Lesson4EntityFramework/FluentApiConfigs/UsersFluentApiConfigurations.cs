using Lesson4EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.FluentApiConfigs
{
    public class UsersFluentApiConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Users table fluent api
            builder
                .HasKey(u => u.Id);

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(60)
                .IsRequired();

            builder
                .HasOne(u => u.Address)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.AddressId);
        }
    }
}
