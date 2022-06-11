using Examen_4_smv.Models;
using SQLite;

namespace Examen_4_smv.Datos
{
    //Clase para crear las tablas de la base de datos
    public class clsBasesDatos
    {
        //Se crea la propiedad de conexion
        private SQLiteAsyncConnection oBaseDatos;
        public clsBasesDatos(string RutaBD)
        {
            oBaseDatos = new SQLiteAsyncConnection(RutaBD);
        }

        public void CrearTablas()
        {
            oBaseDatos.CreateTableAsync<Apuesta>().Wait();

        }
    }
}
