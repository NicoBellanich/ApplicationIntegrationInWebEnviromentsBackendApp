using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWSSeerverlessAPI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AWSSeerverlessAPI.Authorization;
using Tiny.RestClient;
using System.Net.Http;

namespace AWSSeerverlessAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaisesController : ControllerBase
    {

        private readonly ILogger<PaisesController> _logger;
        private readonly IConfiguration _config;
        public PaisesController(ILogger<PaisesController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public async Task<IEnumerable<Pais>> Get()
        {
            try
            {
                _logger.LogInformation("Inicio");

                var client = new TinyRestClient(new HttpClient(), _config["url_api_proveedor"]);

                var paises = await client.

                                GetRequest("Paises").
                                WithOAuthBearer(await AuthorizationHelper.ObtenerAccessToken()).
                                ExecuteAsync<List<Pais>>();

                return paises;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return null;
            }
        }
    }
}
