using System.Threading.Tasks;

namespace Hcm.Skill.Domain.Interfaces.Communicators
{
    public interface IAuthenticationCommunicator
    {
        Task Login();
    }
}
