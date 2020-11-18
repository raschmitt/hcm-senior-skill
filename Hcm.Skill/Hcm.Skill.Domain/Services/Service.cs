using Hcm.Skill.Domain.Interfaces.Communicators;
using Hcm.Skill.Domain.Models;
using System.Threading.Tasks;

namespace Hcm.Skill.Domain.Services
{
    public class Service : IService
    {
        private readonly IAuthenticationCommunicator _authenticationCommunicator;
        private readonly IPontoMobileCommunicator _pontoMobileCommunicator;

        public Service(
            IAuthenticationCommunicator authenticationCommunicator,
            IPontoMobileCommunicator pontoMobileCommunicator)
        {
            _authenticationCommunicator = authenticationCommunicator;
            _pontoMobileCommunicator = pontoMobileCommunicator;
        }

        public async Task Login()
        {
            await _authenticationCommunicator.Login();
        }

        public async Task<ClockingEvent> GetHits()
        {
            return await _pontoMobileCommunicator.GetHits();
        }
    }
}
