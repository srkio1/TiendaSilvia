using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TiendaSilvia.Datos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiendaSilvia.VentaRapida
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgregarVentaRapida : ContentPage
	{
        
        public AgregarVentaRapida ()
		{
			InitializeComponent ();
		}

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            if(pickFecha != null)
            {
                if (txtDescripion.Text.Length > 0)
                {
                    if (txtCantidad.Text != null)
                    {
                        if (txtMonto.Text != null)
                        {
                            try
                            {
                                venta_rapida venta_ = new venta_rapida()
                                {
                                    fecha = pickFecha.Date,
                                    producto = txtDescripion.Text,
                                    cantidad = Convert.ToInt32(txtCantidad.Text),
                                    monto = Convert.ToDecimal(txtMonto.Text)
                                };
                                var json = JsonConvert.SerializeObject(venta_);
                                var content = new StringContent(json, Encoding.UTF8, "application/json");
                                HttpClient client = new HttpClient();
                                var result = await client.PostAsync("http://dmrbolivia.online/api_tienda_silvia/VentaRapida/agregarVentaRapida.php", content);

                                if (result.StatusCode == HttpStatusCode.OK)
                                {
                                    await DisplayAlert("ENVIADO", "Se guardo correctamente", "OK");
                                    await Navigation.PopAsync();
                                }
                                else
                                {
                                    await DisplayAlert("ERROR", "Algo salio mal intente nuevamente", "OK");
                                    await Navigation.PopAsync();
                                }
                            }
                            catch (Exception err)
                            {
                                await DisplayAlert("ERROR", "Algo salio mal intente nuevamente", "OK");
                            }
                        }
                        else
                        {
                            await DisplayAlert("ERROR", "El campo de Monto esta vacio", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("ERROR", "El campo de cantidad esta vacio", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("ERROR", "El campo de Producto esta vacio", "OK");
                }
            }
            else
            {
                await DisplayAlert("ERROR", "El campo de Fecha esta vacio", "OK");
            }
        }
    }
}