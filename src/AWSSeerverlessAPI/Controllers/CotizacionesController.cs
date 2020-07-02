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
    public class CotizacionesController : ControllerBase
    {

        private readonly ILogger<CotizacionesController> _logger;
        private readonly IConfiguration _config;
        public CotizacionesController(ILogger<CotizacionesController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public async Task<IEnumerable<Cotizacion>> Get(string idCiudad, string fechaHoraRetiro, string fechaHoraDevolucion)
        {
            try
            {
                _logger.LogInformation("Inicio");

                var client = new TinyRestClient(new HttpClient(), _config["url_api_proveedor"]);
                
                List<Cotizacion> arregloVacio = new List<Cotizacion>();

                var cotizaciones = await client.

                                GetRequest("Vehiculos/cotizar").
                                AddQueryParameter("idCiudad", idCiudad).
                                AddQueryParameter("fechaHoraRetiro", fechaHoraRetiro).
                                AddQueryParameter("fechaHoraDevolucion", fechaHoraDevolucion).
                                WithOAuthBearer(await AuthorizationHelper.ObtenerAccessToken()).
                                ExecuteAsync<List<Cotizacion>>();
                
                Console.WriteLine("string cotizaciones:", cotizaciones);
                if(cotizaciones == null){
                    return arregloVacio;
                }else{
                    return cotizaciones;
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return null;
            }
        }
    }
}



