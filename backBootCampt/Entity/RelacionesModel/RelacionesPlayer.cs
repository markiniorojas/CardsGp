using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.RelacionesModel.RelacionesEntities
{
    public class RelacionesPlayer : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");

            builder.HasKey(p => p.id);

            builder.Property(p => p.userName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.IsEnabled)
                  .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(p => p.isDeleted)
                   .IsRequired()
                    .HasDefaultValue(false);

            // Relación uno a muchos: Player → GamePlayer
            builder.HasMany(p => p.GamePlayers)
                   .WithOne(gp => gp.Player)
                   .HasForeignKey(gp => gp.playersId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
