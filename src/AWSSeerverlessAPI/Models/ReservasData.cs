using Amazon.DynamoDBv2.Model;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace AWSSeerverlessAPI.Models
{


    public class ReservasData
    {

        public string CodigoReserva { get; set; }
        public string idCotizacion { get; set; }
        public string FechaHoraReserva { get; set; }
        public string UsuarioReserva { get; set; }
        public string TotalReserva { get; set; }

    }


}