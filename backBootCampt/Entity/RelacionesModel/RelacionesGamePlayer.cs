using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.RelacionesModel.RelacionesEntities
{
    public class RelacionesGamePlayer : IEntityTypeConfiguration<GamePlayer>
    {
        public void Configure(EntityTypeBuilder<GamePlayer> builder)
        {
            builder.ToTable("GamePlayers");

            builder.HasKey(gp => gp.id);

            builder.Property(gp => gp.points).IsRequired();
            builder.Property(gp => gp.isDeleted).IsRequired()
             .HasDefaultValue(false);

            // Relación muchos a uno: GamePlayer → Player
            builder.HasOne(gp => gp.Player)
                   .WithMany(p => p.GamePlayers)
                   .HasForeignKey(gp => gp.playersId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a uno: GamePlayer → Games
            builder.HasOne(gp => gp.Games)
                   .WithMany(g => g.GamePlayers)
                   .HasForeignKey(gp => gp.GamesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos: GamePlayer → PlayerCard
            builder.HasMany(gp => gp.PlayerCards)
                   .WithOne(pc => pc.GamePlayer)
                   .HasForeignKey(pc => pc.gamePlayerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
