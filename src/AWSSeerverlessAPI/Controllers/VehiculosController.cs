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
//     public class VehiculosController : ControllerBase
//     {   

//         public static List<Vehiculo> listaVehiculo;

//         public List<Vehiculo> getListaVehiculosPorCiudad(string idCiudad){
            
//             List<Vehiculo> listadoReturn = new List<Vehiculo>();
//             foreach( Vehiculo v in listaVehiculo){
//                 if(v.CiudadId == idCiudad){
//                     listadoReturn.Add(v);
//                 }
//             }
            
//             return listadoReturn;
//         }

//         public VehiculosController()
//         {


//             if (listaVehiculo == null)
//             {
//                 listaVehiculo = new List<Vehiculo>();

//                 listaVehiculo.Add(new Vehiculo()
//                 {
//                     Id = "1",
//                     Patente = "123123",
//                     Nombre = "Argentina",
//                     Marca = "MITZUBITIZI",
//                     Modelo = "12",
//                     Costo = 111,
//                     CiudadId = "2"

//                 });
//                 listaVehiculo.Add(new Vehiculo()
//                 {
//                     Id = "2",
//                     Patente = "asd223",
//                     Nombre = "Auto",
//                     Marca = "RENAULT",
//                     Modelo = "14",
//                     Costo = 144,
//                     CiudadId = "2"
//                 });


//             }

//         }

//         // GET api/values
//         [HttpGet]
//         public IEnumerable<Vehiculo> Get()
//         {
//             return listaVehiculo;
//         }

//         // GET api/values/5
//         [HttpGet("{id}")]
//         public Vehiculo Get(string id)
//         {
//             return listaVehiculo.Find(vehiculo => vehiculo.Id == id);
//         }

//         // POST api/values
//         [HttpPost]
//         public Vehiculo Post([FromBody] Vehiculo bodyParam)
//         {
//             listaVehiculo.Add(bodyParam);
//             return bodyParam;
//         }

//         // PUT api/values/5
//         [HttpPut("{id}")]
//         public int Put(string id, [FromBody] Vehiculo bodyParam)
//         {
//             Vehiculo vehiculo_encontrado = listaVehiculo.Find(vehiculo => vehiculo.Id == id);
//             int index = listaVehiculo.IndexOf(vehiculo_encontrado);
//             listaVehiculo[index].Nombre = bodyParam.Nombre;
//             return index;
//         }

//         // DELETE api/values/5
//         [HttpDelete("{id}")]
//         public IEnumerable<Vehiculo> Delete(string id)
//         {
//             Vehiculo vehiculo_encontrado = listaVehiculo.Find(vehiculo => vehiculo.Id == id);
//             int index = listaVehiculo.IndexOf(vehiculo_encontrado);
//             listaVehiculo.RemoveAt(index);
//             return listaVehiculo;
//         }
//     }
// }
