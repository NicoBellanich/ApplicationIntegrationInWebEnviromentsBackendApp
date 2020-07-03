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
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace AWSSeerverlessAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {

        private readonly ILogger<ReservasController> _logger;
        private readonly IConfiguration _config;
        private readonly DynamoDBContext _context;
        public ReservasController(ILogger<ReservasController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            var clienteAWS = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
            _context = new DynamoDBContext(clienteAWS);
        }

        [HttpGet]
        public async Task<IEnumerable<ReservasData>> Get()
        {
            try
            {
                _logger.LogInformation("Inicio");

                var client = new TinyRestClient(new HttpClient(), _config["url_api_proveedor"]);

                var reservas = await client.

                                GetRequest("Reservas").
                                WithOAuthBearer(await AuthorizationHelper.ObtenerAccessToken()).
                                ExecuteAsync<List<Reserva>>();
                
                List<ScanCondition> condiciones = new List<ScanCondition>();
                List<ReservasData> reservas_cliente = await _context.ScanAsync<ReservasData>(condiciones).GetRemainingAsync();


                return reservas_cliente;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservasResponse reservasResponse)
        {
            try
            {
                _logger.LogInformation("Post Reserva");
                Pasajero pasajero1 = new Pasajero()
                {
                    Nombre = "Juan",
                    Apellido = "Perez",
                    Dni = "12312312",
                    Telefono = "351222522",
                    Email = "j.p@juan.com"
                };

                ReservasResponse reserva1 = new ReservasResponse()
                {
                    idCotizacion = "b7538f04-aace-4d6d-a108-7e31bb165c57",
                    pasajero = pasajero1
                };


                var client = new TinyRestClient(new HttpClient(), _config["url_api_proveedor"]);

                _logger.LogInformation("Empieza acá... RESERVA1:", reserva1);
                Console.WriteLine("RESERFVA:", reserva1);

                var data = new { IdCotizacion = reserva1.idCotizacion, Pasajero = reserva1.pasajero };



                var response = await client.
                                PostRequest("Reservas", data).
                                WithOAuthBearer(await AuthorizationHelper.ObtenerAccessToken()).
                                ExecuteAsync<IActionResult>();



                ReservasData reservasData = new ReservasData()
                {
                    CodigoReserva = "123132",
                    idCotizacion = "12331312",
                    FechaHoraReserva = "2020-09-12T00:00:00",
                    UsuarioReserva = "12223",
                    TotalReserva = "8787"
                };

                await _context.SaveAsync<ReservasData>(reservasData);
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return null;
            }
        }
    }
}
