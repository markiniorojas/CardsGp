using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.RelacionesModel.RelacionesEntities
{
    public class RelacionesGames : IEntityTypeConfiguration<Games>
    {
        public void Configure(EntityTypeBuilder<Games> builder)
        {
            builder.ToTable("Games");

            builder.HasKey(g => g.id);

            builder.Property(g => g.startTime).IsRequired();
            builder.Property(g => g.endTime).IsRequired();
            builder.Property(g => g.date).IsRequired();
            builder.Property(g => g.isDeleted).IsRequired()
                 .HasDefaultValue(false);

            // Relación uno a muchos: Games → GamePlayer
            builder.HasMany(g => g.GamePlayers)
                   .WithOne(gp => gp.Games)
                   .HasForeignKey(gp => gp.GamesId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
