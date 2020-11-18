using Hcm.Skill.Domain.Interfaces.Communicators;
using Hcm.Skill.Domain.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hcm.Skill.Infra.Communication.Communicators
{
    public class PontoMobileCommunicator : BaseClient, IPontoMobileCommunicator
    {
        public PontoMobileCommunicator(CredentialsModel credentials) : base(credentials) {}

        public async Task<ClockingEvent> GetHits()
        {
            const string ClockingEventsUrl = "/bridge/1.0/rest/hcm/pontomobile/queries/clockingEventByActiveUserQuery";

            var filter = new ClockingEventFilter();

            var response = await _client.PostAsJsonAsync(ServerUrl + ClockingEventsUrl, filter);

            return await DescerializeResponse<ClockingEvent>(response);
        }
    }
}
