using Newtonsoft.Json;
using NugetApiModelsACV;
using NugetApiModelsACV.Models;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcCoreApiEmpleadosRoutes.Services
{
    public class ServiceEmpleados
    {

        private string ApiUrl;
        private MediaTypeWithQualityHeaderValue header;
        public ServiceEmpleados(IConfiguration configuration)
        {

            this.ApiUrl = configuration.GetValue<string>("ApiUrls:ApiEmpleados");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/empleados";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    List<Empleado> data = await response.Content.ReadAsAsync<List<Empleado>>();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Empleado> FindEmpleadoAsync(int idEmpleado)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/empleados/" + idEmpleado;
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    Empleado data = await response.Content.ReadAsAsync<Empleado>();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/empleados/oficios";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    List<string> data = await response.Content.ReadAsAsync<List<string>>();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Empleado>> GetEmpleadosByOficioAsync(string oficio)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/empleados/empleadosbyoficio/" + oficio;
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode == true)
                {
                    List<Empleado> data = await response.Content.ReadAsAsync<List<Empleado>>();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
