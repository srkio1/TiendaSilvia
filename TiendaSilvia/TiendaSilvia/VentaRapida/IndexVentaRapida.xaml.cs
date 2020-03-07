using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaSilvia.VentasMes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiendaSilvia.VentaRapida
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndexVentaRapida : ContentPage
	{
		public IndexVentaRapida ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            //CALENDARIO
            Navigation.PushAsync(new CalendarioVenta());
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            //venta diaria
            Navigation.PushAsync(new ListaVentaDiaria());
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            //agregar venta rapida
            Navigation.PushAsync(new AgregarVentaRapida());
        }
    }
}