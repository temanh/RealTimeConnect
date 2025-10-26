using Microsoft.EntityFrameworkCore;
using RealTimeConnect.Models.User;

namespace RealTimeConnect
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Conversation> Conversations => Set<Conversation>();
        public DbSet<ConversationMember> ConversationMembers => Set<ConversationMember>();
        public DbSet<Message> Messages => Set<Message>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversationMember>()
                .HasKey(cm => new { cm.UserId, cm.ConversationId });
        }
    }
}
