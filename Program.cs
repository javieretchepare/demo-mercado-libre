#region snippet_all
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpClientSample
{

    class Program
    {
        #region snippet_HttpClient
        static HttpClient client = new HttpClient();
        #endregion

        #region ShowData

        static void ShowData(TraceIp traceIp)
        {
            Console.Clear();

            Console.WriteLine($"IP: {traceIp.ip}\t");
            Console.WriteLine($"Pais: {traceIp.pais}\t");
            Console.WriteLine($"Fecha Actual: {traceIp.fecha}\t");
            Console.WriteLine($"ISO Code: {traceIp.iso}\t");
            Console.WriteLine($"Idiomas: {traceIp.idioma}\t"); 
            Console.WriteLine($"Moneda: {traceIp.moneda}\t");
            Console.WriteLine($"Hora: {traceIp.hora}\t");
            Console.WriteLine($"Distancia: {traceIp.distancia} kms\t");
        }

        #endregion

        #region snippet_GetAsync

        static async Task<T> GetAsync<T>(Uri url) where T : class
        {
            T data = null;
       
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsAsync<T>();
            }

            if (data == null) throw new HttpClientException("No Existen datos para " + url);
            
            return data;
        }
        #endregion

        static void Main()
        {
//            var input = "5.6.7.8";

            Console.WriteLine("Ingrese IP - enter X to exit");
            string line;
            while ((line = Console.ReadLine()) != "x")
            {
                Match match = Regex.Match(line, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");

                if (match.Success)
                {
                    RunAsync(line).GetAwaiter().GetResult();
                }
                else
                {
                    Console.WriteLine("Formato incorrecto");
                }

                Console.WriteLine("Ingrese IP - enter X to exit");
            }
      
    }

        #region snippet_run
        static async Task RunAsync(string ip)
        {
       
            try
            {

                TraceIp traceIp = new TraceIp { ip = ip };

                Uri url = new Uri(@"https://api.ip2country.info/ip?" + ip);

                traceIp.geolocalización = await GetAsync<Geolocalización>(url);

                url = new Uri(@"https://restcountries.eu/rest/v2/alpha/" + traceIp.geolocalización.countryCode3);

                traceIp.country = await GetAsync<Country>(url);

                ShowData(traceIp);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        #endregion
    }
}
#endregion