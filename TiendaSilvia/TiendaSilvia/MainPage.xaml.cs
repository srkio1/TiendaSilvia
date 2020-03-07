using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaSilvia.VentaRapida;
using TiendaSilvia.VentasMes;
using Xamarin.Forms;

namespace TiendaSilvia
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnVentaRapida_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IndexVentaRapida());
        }
    }
}
