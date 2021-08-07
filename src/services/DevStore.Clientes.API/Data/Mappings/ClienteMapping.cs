using DevStore.Clients.API.Models;
using DevStore.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Clients.API.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.SocialNumber).IsRequired()
                    .HasColumnType($"varchar(50)");

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            // 1 : 1 => Aluno : Address
            builder.HasOne(c => c.Address)
                .WithOne(c => c.Client);

            builder.ToTable("Clients");
        }
    }
}