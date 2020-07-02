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
    public class ReservasController : ControllerBase
    {

        private readonly ILogger<ReservasController> _logger;
        private readonly IConfiguration _config;
        public ReservasController(ILogger<ReservasController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public async Task<IEnumerable<Reserva>> Get()
        {
            try
            {
                _logger.LogInformation("Inicio");

                var client = new TinyRestClient(new HttpClient(), _config["url_api_proveedor"]);

                var reservas = await client.

                                GetRequest("Reservas").
                                AddQueryParameter("name", "valor").
                                WithOAuthBearer(await AuthorizationHelper.ObtenerAccessToken()).
                                ExecuteAsync<List<Reserva>>();

                return reservas;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return null;
            }
        }
    }
}
