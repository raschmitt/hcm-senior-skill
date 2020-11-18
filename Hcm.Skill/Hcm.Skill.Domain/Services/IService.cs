using Hcm.Skill.Domain.Models;
using System.Threading.Tasks;

namespace Hcm.Skill.Domain.Services
{
    public interface IService
    {
        Task Login();
        Task<ClockingEvent> GetHits();
    }
}
