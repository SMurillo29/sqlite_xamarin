using Examen_4_smv.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examen_4_smv.Datos
{
    public class BrokerApuesta
    {
        private readonly SQLiteAsyncConnection oBaseDatos;

        public BrokerApuesta(string RutaBD)
        {
            oBaseDatos = new SQLiteAsyncConnection(RutaBD);
        }

        public Task<List<Apuesta>> GetApuestas()
        {
            return oBaseDatos.Table<Apuesta>().ToListAsync();
        }

        public Task<Apuesta> GetApuestaXID(int Id)
        {
            return oBaseDatos.Table<Apuesta>()
                .Where(vApuesta => vApuesta.ID == Id)
                .FirstOrDefaultAsync();
        }
        public Task<Apuesta> GetApuestaXDocumentoCliente(string Documento)
        {
            return oBaseDatos.Table<Apuesta>()
                .Where(vApuesta => vApuesta.DocCliente == Documento)
                .FirstOrDefaultAsync();
        }
        public Task<int> GrabarApuesta(Apuesta vApuesta)
        {
            if (vApuesta.ID == 0)
            {
                return oBaseDatos.InsertAsync(vApuesta);
            }
            else
            {
                return oBaseDatos.UpdateAsync(vApuesta);
            }
        }
        public Task<int> EliminarApuesta(Apuesta vApuesta)
        {
            return oBaseDatos.DeleteAsync(vApuesta);
        }

        public Apuesta CalcularGanancias(double vApuesta, double multiplicador)
        {
            Apuesta apuesta = new Apuesta();
            double VGanancia = vApuesta * multiplicador;
            double vlrRetencion = 0;
            double vlrPagado = 0;

            if (VGanancia < 300000)
            {
                vlrRetencion = 0;
            }
            else if (VGanancia > 300000 && VGanancia <= 1000000)
            {
                vlrRetencion = VGanancia * 0.2;
            }
            else if (VGanancia > 1000001 && VGanancia <= 2000000)
            {
                vlrRetencion = VGanancia * 0.3;
            }
            else if (VGanancia > 2000000)
            {
                vlrRetencion = VGanancia * 0.35;
            }

            vlrPagado = VGanancia - vlrRetencion + vApuesta;

            apuesta.ValorApuesta = vApuesta;
            apuesta.ValorGanancia = VGanancia;
            apuesta.ValorRetencion = vlrRetencion;
            apuesta.ValorPagado = vlrPagado;

            return apuesta;
        }
    }
}

