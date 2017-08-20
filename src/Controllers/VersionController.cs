using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Routing;

namespace dwCheckApi.Controllers
{
    [Route("/[controller]")]
    public class VersionController : BaseController
    {
        public string Get()
        {
            return Assembly.GetEntryAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion;;
        }
    }
}