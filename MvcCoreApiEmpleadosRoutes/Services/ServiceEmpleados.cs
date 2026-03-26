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

        //añadido después para simplificar las llamadas a API
        //LO QUE NECESITAMOS EN EL METODO GENERICO ES SIMPLEMENTE
        //EL REQUEST DE LA PETICION
        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            //api/Empleados
            string request = "api/empleados";
            List<Empleado> empleados = await CallApiAsync<List<Empleado>>(request);
            return empleados;           
            
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(this.ApiUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(this.header);
            //    HttpResponseMessage response = await client.GetAsync(request);
            //    if (response.IsSuccessStatusCode == true)
            //    {
            //        List<Empleado> data = await response.Content.ReadAsAsync<List<Empleado>>();
            //        return data;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
        }

        public async Task<Empleado> FindEmpleadoAsync(int idEmpleado)
        {
            //api/Empleados/{id}​
            string request = "api/empleados/" + idEmpleado;
            Empleado empleado = await CallApiAsync<Empleado>(request);
            return empleado;
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(this.ApiUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(this.header);
            //    HttpResponseMessage response = await client.GetAsync(request);
            //    if (response.IsSuccessStatusCode == true)
            //    {
            //        Empleado data = await response.Content.ReadAsAsync<Empleado>();
            //        return data;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            //api/Empleados/Oficios
            string request = "api/empleados/oficios";
            List<string> oficios = await CallApiAsync<List<string>>(request);
            return oficios;

            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(this.ApiUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(this.header);
            //    HttpResponseMessage response = await client.GetAsync(request);
            //    if (response.IsSuccessStatusCode == true)
            //    {
            //        List<string> data = await response.Content.ReadAsAsync<List<string>>();
            //        return data;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
        }

        public async Task<List<Empleado>> GetEmpleadosByOficioAsync(string oficio)
        {
            //api/Empleados/EmpleadosByOficio/{oficio}​
            string request = "api/empleados/empleadosbyoficio/" + oficio;
            List<Empleado> empleados = await CallApiAsync<List<Empleado>>(request);
            return empleados;
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(this.ApiUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(this.header);
            //    HttpResponseMessage response = await client.GetAsync(request);
            //    Console.WriteLine(response);
            //    if (response.IsSuccessStatusCode == true)
            //    {
            //        List<Empleado> data = await response.Content.ReadAsAsync<List<Empleado>>();
            //        return data;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
        }
    }
}
