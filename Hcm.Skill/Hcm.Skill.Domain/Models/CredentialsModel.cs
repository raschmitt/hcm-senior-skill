using Newtonsoft.Json;

namespace Hcm.Skill.Domain.Models
{
    public class CredentialsModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public string Authorization { get; set; }
    }
}
