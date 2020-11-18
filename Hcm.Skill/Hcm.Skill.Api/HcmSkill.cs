using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Hcm.Skill.Domain.Services;

namespace Hcm.Function
{
    public class HcmSkill
    {
        private readonly IService _service;

        public HcmSkill(IService service)
        {
            _service = service;
        }

        [FunctionName("Login")]
        public async Task Login([TimerTrigger("0 0 0 * * 1", RunOnStartup = true)] TimerInfo myTimer)
        {
            await _service.Login();
        }

        [FunctionName("Hits")]
        public async Task<IActionResult> GetHits([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hits")] HttpRequest request)
        {
            var result = await _service.GetHits();

            return new OkObjectResult(result);
        }
    }
}
