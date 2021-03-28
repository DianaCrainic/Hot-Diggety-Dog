using System.Text.Json.Serialization;
using WebAPI.Data;

namespace WebAPI.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
