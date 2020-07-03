using Amazon.DynamoDBv2.Model;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace AWSSeerverlessAPI.Models
{

    [DynamoDBTable("ReservasData")]
    public class ReservasData
    {
        [DynamoDBHashKey]
        public string CodigoReserva { get; set; }
        [DynamoDBProperty("idCotizacion")]
        public string idCotizacion { get; set; }
        [DynamoDBProperty("FechaHoraReserva")]
        public string FechaHoraReserva { get; set; }
        [DynamoDBProperty("UsuarioReserva")]
        public string UsuarioReserva { get; set; }
        [DynamoDBProperty("TotalReserva")]
        public string TotalReserva { get; set; }

    }


}