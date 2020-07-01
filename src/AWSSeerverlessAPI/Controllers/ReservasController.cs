// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using AWSSeerverlessAPI.Models;
// using Microsoft.Extensions.Logging;


// namespace AWSSeerverlessAPI.Controllers
// {
//     [Route("api/[controller]")]
//     public class ReservasController : ControllerBase
//     {

//         private static List<Reserva> listaReservas;
//         private readonly ILogger<ReservasController> _logger;

//         public ReservasController(ILogger<ReservasController> logger)
//         {
//             _logger = logger;

//             if (listaReservas == null)
//             {
//                 listaReservas = new List<Reserva>();
//                 listaReservas.Add(new Reserva()
//                 {
//                     Id = "1",
//                     FechaInicio = "2020-07-03",
//                     FechaFin = "2020-07-04",
//                     PrecioAlquiler = 100,
//                     Activo = true,
//                     IdVehiculo = "1"
//                 });
//                  listaReservas.Add(new Reserva()
//                 {
//                     Id = "2",
//                     FechaInicio = "2020-07-27",
//                     FechaFin = "2020-07-30",
//                     PrecioAlquiler = 500,
//                     Activo = false,
//                     IdVehiculo = "1"
//                 });

//             }

//         }
//         // GET api/values/5
//         [HttpGet("queryreservas/{idciudad}/{fechadesde}/{fechahasta}")]
//         public List<Vehiculo> Get(string idciudad, string fechadesde, string fechahasta)
//         {

//             List<Vehiculo> listaVehiculos = new List<Vehiculo>();
//             Controllers.VehiculosController controladorVehiculos = new Controllers.VehiculosController();
//             listaVehiculos = controladorVehiculos.getListaVehiculosPorCiudad(idciudad);
//             List<Vehiculo> listaReturn = new List<Vehiculo>();
//             bool bandera = new bool();
//             foreach (Vehiculo v in listaVehiculos)
//             {
//                 bandera = true;
//                 foreach (Reserva r in listaReservas)
//                 {
//                     if (r.IdVehiculo == v.Id)
//                     {
//                         if (DateTime.Parse(r.FechaFin) < DateTime.Parse(fechadesde) || DateTime.Parse(r.FechaInicio) > DateTime.Parse(fechahasta))
//                         {

//                         }
//                         else
//                         {
//                             bandera = false;
//                         }
//                     }
//                 }
//                 if (bandera)
//                 {
//                     listaReturn.Add(v);
//                 }
//             }

//             return listaReturn;
//         }

//         // GET api/values
//         [HttpGet]
//         public IEnumerable<Reserva> Get()
//         {
//             return listaReservas;
//         }

//         // GET api/values/5
//         [HttpGet("{id}")]
//         public Reserva Get(string id)
//         {
//             return listaReservas.Find(reserva => reserva.Id == id);
//         }

//         // POST api/values
//         [HttpPost]
//         public Reserva Post([FromBody] Reserva bodyParam)
//         {
//             listaReservas.Add(bodyParam);
//             return bodyParam;
//         }

//         // PUT api/values/5
//         [HttpPut("{id}")]
//         public int Put(string id, [FromBody] Reserva bodyParam)
//         {
//             Reserva reserva_encontrada = listaReservas.Find(reseva => reseva.Id == id);
//             int index = listaReservas.IndexOf(reserva_encontrada);
//             listaReservas[index].Activo = bodyParam.Activo;
//             return index;
//         }

//         // DELETE api/values/5
//         [HttpDelete("{id}")]
//         public IEnumerable<Reserva> Delete(string id)
//         {
//             Reserva reseva_encontrada = listaReservas.Find(reserva => reserva.Id == id);
//             int index = listaReservas.IndexOf(reseva_encontrada);
//             listaReservas.RemoveAt(index);
//             return listaReservas;
//         }
//     }
// }
