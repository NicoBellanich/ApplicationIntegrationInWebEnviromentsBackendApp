using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWSSeerverlessAPI.Models;
using Microsoft.Extensions.Logging;
using Tiny.RestClient;
using System.Net.Http;
// using ClienteRestDynamoDbAPI.Models;
using Microsoft.Extensions.Configuration;
using AWSSeerverlessAPI.Authorization;


namespace AWSSeerverlessAPI.Controllers
{
    [Route("api/[controller]")]
    public class CiudadesController : ControllerBase
    {

        private readonly ILogger<CiudadesController> _logger;
        private readonly IConfiguration _config;
        public CiudadesController(ILogger<CiudadesController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public async Task<IEnumerable<Ciudad>> Get()
        {
            try
            {
                _logger.LogInformation("Inicio");
                
                var client = new TinyRestClient(new HttpClient(), _config["url_api_proveedor"]);     
                var ciudades = await client.             
                                GetRequest("Ciudades"). 
                                WithOAuthBearer(await AuthorizationHelper.ObtenerAccessToken()).
                                ExecuteAsync<List<Ciudad>>();
                return ciudades;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return null;
            }
        }
    }
}
