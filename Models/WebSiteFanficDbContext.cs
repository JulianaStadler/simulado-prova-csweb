using Microsoft.EntityFrameworkCore;
namespace WebSiteFanfic.Models;
public class WebSiteFanficDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Fanfic> Fanfics => Set<Fanfic>();
    public DbSet<ReadingList> ReadingLists => Set<ReadingList>();

    protected override void OnModelCreating(ModelBuilder model)
    {

        /*
        //usuario escreve fanfic
        model.Entity<Fanfic>()
            .HasOne(f => f.User)
            .WithMany(u => u.WritedFanfics)
            .UsingEntity(f => f.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        //reading list tem um usuario
        model.Entity<ReadingList>()
            .HasOne(rd => rd.User)
            .WithOne(u => u.ReadingList)
            .UsingEntity(rd => rd.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        //usuario tem uma reading list
        model.Entity<User>()
            .HasOne(u => u.ReadingList)
            .WithOne(rd => rd.User)
            .UsingEntity(u => u.ReadingListId)
            .OnDelete(DeleteBehavior.NoAction);

        //reading list tem varias fanfics
        model.Entity<Fanfic>()
            .HasMany(f => f.ReadingList)
            .WithMany(rl => rl.Fanfics)
            .OnDelete(DeleteBehavior.NoAction);
        */

        // 1️ Usuário escreve fanfic (1:N)
        model.Entity<Fanfic>()
            .HasOne(f => f.User)
            .WithMany(u => u.WritedFanfics)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // 2️ User ↔ ReadingList (1:1)
        model.Entity<User>()
            .HasOne(u => u.ReadingList)
            .WithOne(rl => rl.User)
            .HasForeignKey<ReadingList>(rl => rl.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // 3️ ReadingList ↔ Fanfic (N:N)
        model.Entity<ReadingList>()
            .HasMany(rl => rl.Fanfics)
            .WithMany(f => f.ReadingLists)
            .UsingEntity(j => j.ToTable("ReadingListFanfics"));

   }
}