namespace JsonAnalyzer_MService.Models
{
    public class NodeFile
    {
        public long Id { get; set; }
        public required string Type { get; set; }
        public required string Name { get; set; }
        public NodeFile? Files;
    }
}
