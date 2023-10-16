using Microsoft.EntityFrameworkCore;

namespace JsonAnalyzer_MService.Models
{
    public class NodeContext : DbContext
    {
        public NodeContext(DbContextOptions<NodeContext> options) : base(options)
        {
        }

        public DbSet<NodeFile> NodeFiles { get; set; } = null!;
    }
}
