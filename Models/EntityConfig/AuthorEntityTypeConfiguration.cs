using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Classes;

namespace Models.EntityConfig
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasMany(b => b.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired();
        }
    }
}