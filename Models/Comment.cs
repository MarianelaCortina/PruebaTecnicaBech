using System.Text.Json.Serialization;

namespace PruebaTecnicaBech.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        // Foreign Key
        public int PostId { get; set; }

        // Propiedad de navegación
        [JsonIgnore] //Ignora la propiedad Post al serializar
        public Post? Post { get; set; }
    }
}
