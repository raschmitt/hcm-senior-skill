using Hcm.Skill.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hcm.Skill.Infra.Communication
{
    public abstract class BaseClient
    {
        protected const string ServerUrl = "https://platform.senior.com.br/t/senior.com.br";

        protected readonly HttpClient _client;
        protected readonly CredentialsModel _credentials;

        public BaseClient(CredentialsModel credentials)
        {
            _credentials = credentials;

            _client = new HttpClient();

            if (!string.IsNullOrEmpty(_credentials.Authorization))
            {
                _client.DefaultRequestHeaders.Add("Authorization", _credentials.Authorization);
            }
        }

        public async Task<T> DescerializeResponse<T>(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
