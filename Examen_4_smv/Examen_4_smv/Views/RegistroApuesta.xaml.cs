using Examen_4_smv.Datos;
using Examen_4_smv.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_4_smv.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroApuesta : ContentPage
    {
        BrokerApuesta bApuesta = new BrokerApuesta(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));
        public RegistroApuesta()
        {
            InitializeComponent();
        }

        async private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            string DocCliente = txtDocCliente.Text;
            string NombreCliente = txtNombreCliente.Text;
            string NombreEmpleado = txtNombreEmpleado.Text;
            string Fecha = DateTime.Now.ToString("yyyy-MMM-dd");
            double ValorApuesta = Convert.ToDouble(txtValorApuesta.Text);
            double Multiplicador = Convert.ToDouble(txtMultiplicador.Text);
            string lbFecha = lbfecha.Text;

            Apuesta apuesta = bApuesta.CalcularGanancias(ValorApuesta, Multiplicador);
            apuesta.DocCliente = DocCliente;
            apuesta.NombreCliente = NombreCliente;
            apuesta.NombreEmpleado = NombreEmpleado;
            apuesta.Fecha = Fecha;

            lbfecha.Text = lbFecha + Fecha;
            


            await bApuesta.GrabarApuesta(apuesta);
            await DisplayAlert("Inserción de Apuesta", "Se grabó la apuesta con exito en la fecha " + Fecha, "OK");
        }
    }
}