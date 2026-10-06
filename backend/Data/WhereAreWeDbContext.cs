using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class WhereAreWeDbContext : DbContext
    {
        public WhereAreWeDbContext(DbContextOptions<WhereAreWeDbContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Clue> Clues { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<DailyChallange> DailyChallanges { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Option> Options { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Clue>()
                .HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.CityId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.City)
                .WithMany()
                .HasForeignKey(q => q.CityId);

            modelBuilder.Entity<Option>()
                .HasOne(o => o.Question)
                .WithMany()
                .HasForeignKey(o => o.QuestionId);

            modelBuilder.Entity<DailyChallange>()
                .HasOne(dc => dc.City)
                .WithMany()
                .HasForeignKey(dc => dc.CityId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.User)
                .WithMany()
                .HasForeignKey(g => g.UserId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.DailyChallange)
                .WithMany()
                .HasForeignKey(g => g.DailyChallangeId);

            modelBuilder.Entity<Clue>()
                .Property(c => c.Point)
                .HasPrecision(5, 2);



        }
    }
}
