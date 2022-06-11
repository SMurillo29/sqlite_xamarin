using Examen_4_smv.Datos;
using Examen_4_smv.Services;
using Examen_4_smv.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_4_smv
{
    public partial class App : Application
    {
        private clsBasesDatos _BaseDatos;
        public clsBasesDatos BaseDatos
        {
            get
            {
                if (_BaseDatos == null)
                {
                    _BaseDatos = new clsBasesDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));
                }
                return _BaseDatos;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            BaseDatos.CrearTablas();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
