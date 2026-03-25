using Microsoft.AspNetCore.Mvc;
using NugetApiModelsACV.Models;
using MvcCoreApiEmpleadosRoutes.Services;

namespace MvcCoreApiEmpleadosRoutes.Controllers
{
    public class EmpleadosController : Controller
    {
        private ServiceEmpleados service;

        public EmpleadosController(ServiceEmpleados service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<string> oficios = await this.service.GetOficiosAsync();
            ViewBag.Oficios = oficios;
            List<Empleado> empleados = await this.service.GetEmpleadosAsync();
            return View(empleados);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string oficio)
        {
            List<string> oficios = await this.service.GetOficiosAsync();
            ViewBag.Oficios = oficios;
            List<Empleado> empleados = await this.service.GetEmpleadosByOficioAsync(oficio);
            return View(empleados);
        }
        public async Task<IActionResult> Detalles(int idempleado)
        {
            Empleado empleado = await this.service.FindEmpleadoAsync(idempleado);
            return View(empleado);
        }
    }
}
