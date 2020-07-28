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
    public partial class Editarventa : ContentPage
    {
        private int ID_ventarapida;       
        public Editarventa(int Id_venta_rapida, DateTime Fecha, int Cantidad,  decimal Monto, string Producto)
        {
            InitializeComponent();
            ID_ventarapida = Id_venta_rapida;           
            pickFecha.Date = Fecha;
            txtCantidad.Text = Cantidad.ToString();
            txtid.Text = ID_ventarapida.ToString();
            txtDescripion.Text = Producto;
            txtMonto.Text = Monto.ToString();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {// borrar venta rapida
            venta_rapida Venta_rapida = new venta_rapida
            {
                id_venta_rapida = Convert.ToInt32(txtid.Text),
                fecha = pickFecha.Date,
                producto = txtDescripion.Text,
                cantidad = Convert.ToInt32(txtCantidad.Text),
                monto = Convert.ToDecimal(txtMonto.Text)
            };
            var json = JsonConvert.SerializeObject(Venta_rapida);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://dmrbolivia.com/api_tienda_silvia/VentaRapida/borrarVentaRapida.php", content);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("EDITAR", "Se edito correctamente", "OK");
                await Navigation.PopAsync(true);
            }
            else
            {
                await DisplayAlert("ERROR", "Algo salio mal intentelo nuevamente", "OK");
                await Navigation.PopAsync();
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //btn modificar
            if (txtid.Text != null)
            {                
                    if (txtDescripion.Text.Length > 0)
                    {
                        if (txtCantidad.Text.Length >0)
                        {
                            if (txtMonto.Text.Length >0)
                            {
                                try
                                {
                                    venta_rapida modificar = new venta_rapida
                                    {
                                        id_venta_rapida = Convert.ToInt32(txtid.Text),
                                        fecha = pickFecha.Date,
                                        producto = txtDescripion.Text,
                                        cantidad = Convert.ToInt32(txtCantidad.Text),
                                        monto = Convert.ToDecimal(txtMonto.Text),


                                    };
                                    var json = JsonConvert.SerializeObject(modificar);

                                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                                    HttpClient client = new HttpClient();

                                    var result = await client.PostAsync("http://dmrbolivia.com/api_tienda_silvia/VentaRapida/editarVentaRapida.php", content);

                                    if (result.StatusCode == HttpStatusCode.OK)
                                    {
                                        await DisplayAlert("EDITAR", "Se edito correctamente", "OK");
                                        await Navigation.PopAsync();
                                    }
                                    else
                                    {
                                        await DisplayAlert("ERROR", "Algo salio mal intentelo nuevamente1", "OK");
                                        await Navigation.PopAsync();
                                    }
                                }
                                catch (Exception)
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
                            await DisplayAlert("ERROR", "El campo de Cantidad esta vacio", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("ERROR", "El campo de Producto esta vacio", "OK");
                    }
                }
             
               
            else
            {
                await DisplayAlert("ERROR", "El campo de id esta vacio", "OK");
            }
        }
                        }
    }
