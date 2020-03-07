using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entry = Microcharts.Entry;
using Microcharts;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using TiendaSilvia.Datos;

namespace TiendaSilvia.VentaRapida
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Graficos : ContentPage
	{
        int yearActual = DateTime.Now.Year;
        int yearAnterior = DateTime.Now.AddYears(-1).Year;

        Decimal MontoEnero = 0;
        Decimal MontoFebrero = 0;
        Decimal MontoMarzo = 0;
        Decimal MontoAbril = 0;
        Decimal MontoMayo = 0;
        Decimal MontoJunio = 0;
        Decimal MontoJulio = 0;
        Decimal MontoAgosto = 0;
        Decimal MontoSeptiembre = 0;
        Decimal MontoOctubre = 0;
        Decimal MontoNoviembre = 0;
        Decimal MontoDiciembre = 0;
        public Graficos ()
		{
			InitializeComponent ();
            GetGrafico();
        }
        public async void GetGrafico()
        {
            try
            {
                DateTime Enero1 = new DateTime(yearActual, 1, 1, 1, 1, 1);
                DateTime Enero31 = Enero1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Febrero1 = new DateTime(yearActual, 2, 1, 1, 1, 1);
                DateTime Febrero29 = Febrero1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Marzo1 = new DateTime(yearActual, 3, 1, 1, 1, 1);
                DateTime Marzo31 = Marzo1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Abril1 = new DateTime(yearActual, 4, 1, 1, 1, 1);
                DateTime Abril30 = Abril1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Mayo1 = new DateTime(yearActual, 5, 1, 1, 1, 1);
                DateTime Mayo31 = Mayo1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Junio1 = new DateTime(yearActual, 6, 1, 1, 1, 1);
                DateTime Junio30 = Junio1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Julio1 = new DateTime(yearActual, 7, 1, 1, 1, 1);
                DateTime Julio31 = Junio1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Agosto1 = new DateTime(yearActual, 8, 1, 1, 1, 1);
                DateTime Agosto31 = Agosto1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Septiembre1 = new DateTime(yearActual, 9, 1, 1, 1, 1);
                DateTime Septiembre30 = Septiembre1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Octubre1 = new DateTime(yearActual, 10, 1, 1, 1, 1);
                DateTime Octubre31 = Octubre1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Noviembre1 = new DateTime(yearActual, 11, 1, 1, 1, 1);
                DateTime Noviembre30 = Noviembre1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);
                DateTime Diciembre1 = new DateTime(yearActual, 12, 1, 1, 1, 1);
                DateTime Diciembre31 = Diciembre1.AddMonths(1).AddDays(-1).AddHours(22).AddMinutes(58);

                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_tienda_silvia/VentaRapida/listaVentaRapida.php");
                var dataVR = JsonConvert.DeserializeObject<List<venta_rapida>>(response);

                foreach (var item in dataVR)
                {
                    if (item.fecha.Ticks >= Enero1.Ticks)
                    {
                        if(item.fecha.Ticks <= Enero31.Ticks)
                        {
                            MontoEnero = MontoEnero + item.monto;
                        }
                    }
                    if(item.fecha.Ticks >= Febrero1.Ticks)
                    {
                        if(item.fecha.Ticks <= Febrero29.Ticks)
                        {
                            MontoFebrero = MontoFebrero + item.monto;
                        }
                    }
                    if (item.fecha.Ticks >= Marzo1.Ticks)
                    {
                        if (item.fecha.Ticks <= Marzo31.Ticks)
                        {
                            MontoMarzo = MontoMarzo + item.monto;
                        }
                    }
                    if (item.fecha.Ticks >= Abril1.Ticks)
                    {
                        if (item.fecha.Ticks <= Abril30.Ticks)
                        {
                            MontoAbril = MontoAbril + item.monto;
                        }
                    }
                    if (item.fecha.Ticks >= Mayo1.Ticks)
                    {
                        if (item.fecha.Ticks <= Mayo31.Ticks)
                        {
                            MontoMayo = MontoMayo + item.monto;
                        }
                    }
                    if (item.fecha.Ticks >= Junio1.Ticks)
                    {
                        if (item.fecha.Ticks <= Junio30.Ticks)
                        {
                            MontoJunio = MontoJunio + item.monto;
                        }
                    }
                    if (item.fecha.Ticks >= Julio1.Ticks)
                    {
                        if (item.fecha.Ticks <= Julio31.Ticks)
                        {
                            MontoJulio = MontoJulio + item.monto;
                        }
                    }
                    if (item.fecha.Ticks >= Agosto1.Ticks)
                    {
                        if (item.fecha.Ticks <= Agosto31.Ticks)
                        {
                            MontoAgosto = MontoAgosto + item.monto;
                        }
                    }
                    if (item.fecha.Ticks >= Septiembre1.Ticks)
                    {
                        if (item.fecha.Ticks <= Septiembre30.Ticks)
                        {
                            MontoSeptiembre = MontoSeptiembre + item.monto;
                        }
                    }
                    if (item.fecha.Ticks >= Octubre1.Ticks)
                    {
                        if (item.fecha.Ticks <= Octubre31.Ticks)
                        {
                            MontoOctubre = MontoOctubre + item.monto;
                        }
                    }
                    if (item.fecha.Ticks >= Noviembre1.Ticks)
                    {
                        if (item.fecha.Ticks <= Noviembre30.Ticks)
                        {
                            MontoNoviembre = MontoNoviembre + item.monto;
                        }
                    }
                    if (item.fecha.Ticks >= Diciembre1.Ticks)
                    {
                        if (item.fecha.Ticks <= Diciembre31.Ticks)
                        {
                            MontoDiciembre = MontoDiciembre + item.monto;
                        }
                    }
                }
                float Enero2020 = (float)MontoEnero;
                float Febrero2020 = (float)MontoFebrero;
                float Marzo2020 = (float)MontoMarzo;
                float Abril2020 = (float)MontoAbril;
                float Mayo2020 = (float)MontoMayo;
                float Junio2020 = (float)MontoJunio;
                float Julio2020 = (float)MontoJulio;
                float Agosto2020 = (float)MontoAgosto;
                float Septiembre2020 = (float)MontoSeptiembre;
                float Octubre2020 = (float)MontoOctubre;
                float Noviembre2020 = (float)MontoNoviembre;
                float Diciembre2020 = (float)MontoDiciembre;
                List<Entry> entries = new List<Entry>
                {
                    new Entry(Enero2020)
                    {
                        Color=SKColor.Parse("#FF1943"),
                        Label ="Ene",
                        ValueLabel = Enero2020.ToString()
                    },
                    new Entry(Febrero2020)
                    {
                        Color = SKColor.Parse("#FF1943"),
                        Label = "Feb",
                        ValueLabel = Febrero2020.ToString()
                    },
                    new Entry(Marzo2020)
                    {
                        Color=SKColor.Parse("#FF1943"),
                        Label ="Mar",
                        ValueLabel = Marzo2020.ToString()
                    },
                    new Entry(Abril2020)
                    {
                        Color =  SKColor.Parse("#00CED1"),
                        Label = "Abr",
                        ValueLabel = Abril2020.ToString()
                    },
                    new Entry(Mayo2020)
                    {
                        Color = SKColor.Parse("#FF4500"),
                        Label = "May",
                        ValueLabel = Mayo2020.ToString()
                    },
                    new Entry(Junio2020)
                    {
                        Color = SKColor.Parse("#cc0000"),
                        Label = "Jun",
                        ValueLabel = Junio2020.ToString()
                    },
                    new Entry(Julio2020)
                    {
                        Color = SKColor.Parse("#326360"),
                        Label = "Jul",
                        ValueLabel = Julio2020.ToString()
                    },
                    new Entry(Agosto2020)
                    {
                        Color = SKColor.Parse("#333333"),
                        Label = "Ago",
                        ValueLabel = Agosto2020.ToString()
                    },
                    new Entry(Septiembre2020)
                    {
                        Color = SKColor.Parse("#c4a857"),
                        Label = "Sep",
                        ValueLabel = Septiembre2020.ToString()
                    },
                    new Entry(Octubre2020)
                    {
                        Color = SKColor.Parse("#d63232"),
                        Label = "Oct",
                        ValueLabel = Octubre2020.ToString()
                    },
                    new Entry(Noviembre2020)
                    {
                        Color = SKColor.Parse("#b5c1e6"),
                        Label = "Nov",
                        ValueLabel = Noviembre2020.ToString()
                    },
                    new Entry(Diciembre2020)
                    {
                        Color = SKColor.Parse("#f3dde3"),
                        Label = "Dic",
                        ValueLabel = Diciembre2020.ToString()
                    },
                };

                ChartGraficos.Chart = new BarChart() { Entries = entries, LabelTextSize = 40, BarAreaAlpha = 50 };
                ChartGraficos2.Chart = new LineChart() { Entries = entries, LabelTextSize = 40, PointSize = 20, LineMode = LineMode.Straight };
            }
            catch (Exception err)
            {
                await DisplayAlert("ERROR", err.ToString(), "OK");
            }
        }
	}
}