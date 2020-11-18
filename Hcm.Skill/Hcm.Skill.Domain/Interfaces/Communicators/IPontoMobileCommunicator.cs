using Hcm.Skill.Domain.Models;
using System.Threading.Tasks;

namespace Hcm.Skill.Domain.Interfaces.Communicators
{
    public interface IPontoMobileCommunicator
    {
        Task<ClockingEvent> GetHits();
    }
}
