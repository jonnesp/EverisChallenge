using EverisChallenge.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Data.Mappings
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(p => p.DDD)
                .IsRequired()
                .HasMaxLength(3);

            
        }
    }
}
