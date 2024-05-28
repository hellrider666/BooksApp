using System.Text.Json.Serialization;

namespace BooksApp.Application.Mapping.DTOs
{
    public class AuthorDTO
    {
        public virtual Guid Guid { get; set; }
        public string Name { get; set; }
        public string? Lastname { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Surname { get; set; }
    }
}
