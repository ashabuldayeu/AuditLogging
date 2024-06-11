using AuditLogging.Core.Config;
using AuditLogging.Core.Persistence;
using AuditLogging.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuditLogging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public Task<IActionResult> Update()
        {
            AuditConfig<TestRootObj> auditConfig = new(x => new AuditLogEntry(x.Id.ToString(),
                new(x.Name, nameof(TestRootObj.Name)),
                new(JsonSerializer.Serialize(x.ComplexObj), nameof(TestRootObj.ComplexObj)),
                new(JsonSerializer.Serialize(x.InnerObjs), nameof(TestRootObj.InnerObjs))
                ));

        }

        [HttpPost]
        public Task<IActionResult> Create()
        {

        }

        [HttpGet]
        public Task<IActionResult> GetAudits()
        {

        }
    }
}
