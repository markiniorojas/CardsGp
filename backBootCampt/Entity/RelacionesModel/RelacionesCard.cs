using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.RelacionesModel.RelacionesEntities
{
    public class RelacionesCard : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards");

            builder.HasKey(c => c.id);

            builder.Property(c => c.cardName).IsRequired();

            builder.Property(c => c.isDeleted).IsRequired()
              .HasDefaultValue(false);

            builder.Property(c => c.cylinderCapacity).HasPrecision(10, 2);
            builder.Property(c => c.hP).HasPrecision(10, 2);
            builder.Property(c => c.finalSpeed).HasPrecision(10, 2);
            builder.Property(c => c.nOclylinder).HasPrecision(10, 2);
            builder.Property(c => c.weight).HasPrecision(10, 2);
            builder.Property(c => c.torque).HasPrecision(10, 2);

            // Relación uno a muchos: Card → PlayerCard
            builder.HasMany(c => c.PlayerCards)
                   .WithOne(pc => pc.Card)
                   .HasForeignKey(pc => pc.CardId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
