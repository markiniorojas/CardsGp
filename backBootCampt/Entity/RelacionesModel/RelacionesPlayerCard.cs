using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.RelacionesModel.RelacionesEntities
{
    public class RelacionesPlayerCard : IEntityTypeConfiguration<PlayerCard>
    {
        public void Configure(EntityTypeBuilder<PlayerCard> builder)
        {
            builder.ToTable("PlayerCards");

            builder.HasKey(pc => pc.id);

            builder.Property(pc => pc.isUsed).IsRequired();
            builder.Property(pc => pc.isDeleted).IsRequired()
                 .HasDefaultValue(false);

            // Relación muchos a uno: PlayerCard → GamePlayer
            builder.HasOne(pc => pc.GamePlayer)
                   .WithMany(gp => gp.PlayerCards)
                   .HasForeignKey(pc => pc.gamePlayerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a uno: PlayerCard → Card
            builder.HasOne(pc => pc.Card)
                   .WithMany(c => c.PlayerCards)
                   .HasForeignKey(pc => pc.CardId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
