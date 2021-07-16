using helloweb.Models;
using Microsoft.EntityFrameworkCore;

namespace helloweb.Repositories {
    public class TutorialDbContext : DbContext {

        public TutorialDbContext () { }

        public TutorialDbContext (DbContextOptions<TutorialDbContext> options) : base (options) { }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) { }

        public DbSet<UserEntity> Users { get; set; }

    }
}