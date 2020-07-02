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
    public class VehiculosController : ControllerBase
    {

        private readonly ILogger<VehiculosController> _logger;
        private readonly IConfiguration _config;
        public VehiculosController(ILogger<VehiculosController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public async Task<IEnumerable<Vehiculo>> Get()
        {
            try
            {
                _logger.LogInformation("Inicio");

                var client = new TinyRestClient(new HttpClient(), _config["url_api_proveedor"]);

                var vehiculos = await client.
                                GetRequest("Vehiculos").
                                WithOAuthBearer(await AuthorizationHelper.ObtenerAccessToken()).
                                ExecuteAsync<List<Vehiculo>>();

                return vehiculos;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return null;
            }
        }
    }
}
