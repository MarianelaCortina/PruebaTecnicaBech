using System.Text.Json.Serialization;

namespace PruebaTecnicaBech.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string? Part { get; set; }
        public string? ComponentType { get; set; }
        public string? BrandName { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public string? SerialNumber { get; set; }

        //relación n:1 cada componente pertence a una maquina
        public int MachineId { get; set; }
        [JsonIgnore]
        public Machine? Machine { get; set; }
    }
}
