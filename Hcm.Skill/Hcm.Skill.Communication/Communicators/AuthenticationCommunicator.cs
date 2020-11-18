using System.Threading.Tasks;
using System.Net.Http;
using Hcm.Skill.Domain.Models;
using Hcm.Skill.Domain.Interfaces.Communicators;

namespace Hcm.Skill.Infra.Communication.Communicators
{
    public class AuthenticationCommunicator : BaseClient, IAuthenticationCommunicator
    {
        public AuthenticationCommunicator(CredentialsModel credentials) : base (credentials) { }

        public async Task Login()
        {
            const string LoginUrl = "/bridge/1.0/rest/platform/authentication/actions/login";

            var response = await _client.PostAsJsonAsync(ServerUrl + LoginUrl, _credentials);

            var data = await DescerializeResponse<dynamic>(response);

            _credentials.Authorization = MapAuthorization(data);
        }

        private string MapAuthorization(dynamic data)
        {
            string jsonToken = data?.jsonToken;

            var splitedToken = jsonToken.Split('\"');

            return $"{splitedToken[13]} {splitedToken[17]}";
        }
    }
}
