using SQLite; //Para crear las tablas

namespace Examen_4_smv.Models
{
    [Table("tblApuestas")]
    public class Apuesta
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string DocCliente { get; set; }
        [MaxLength(200)]
        public string NombreCliente { get; set; }
        [MaxLength(200)]
        public string NombreEmpleado { get; set; }
        [MaxLength(20)]
        public string Fecha { get; set; }
        public double ValorApuesta { get; set; }
        public double ValorGanancia { get; set; }
        public double ValorRetencion { get; set; }
        public double ValorPagado { get; set; }
    }
}
