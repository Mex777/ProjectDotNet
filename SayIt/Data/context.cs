using Microsoft.EntityFrameworkCore;
using SayIt.Models.Posts;
using SayIt.Models.Profile;
using SayIt.Models.Tables;

namespace SayIt.Data;

public class Context : DbContext
{
   public DbSet<Post> Posts { get; set; }
   
   public DbSet<User> Users { get; set; }

   public DbSet<Profile> Profiles { get; set; }

   public Context(DbContextOptions<Context> options) : base(options)
   {
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<User>()
         .HasMany(usr => usr.Posts)
         .WithOne(pst => pst.Author)
         .HasPrincipalKey(usr => usr.Username);

      modelBuilder.Entity<User>()
         .HasOne(u => u.Extra)
         .WithOne(p => p.CorespondingUser)
         .HasForeignKey<Profile>(p => p.UserId);
      
      base.OnModelCreating(modelBuilder);
   }
}