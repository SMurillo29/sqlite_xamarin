using Examen_4_smv.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Examen_4_smv.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}