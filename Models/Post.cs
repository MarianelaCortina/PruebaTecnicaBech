namespace PruebaTecnicaBech.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        // Relación uno-a-muchos
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
