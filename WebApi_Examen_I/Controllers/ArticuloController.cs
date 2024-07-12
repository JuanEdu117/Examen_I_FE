using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Examen_I.Models;

namespace WebApi_Examen_I.Controllers
{
    public class ArticuloController : Controller
    {
        #region EVENTOS DE APERTURA 
        public async Task<IActionResult> Index()                                            //EN MVC A PARTIR DE LA ACCION SE GENERA LA VISTA
        {
            GestorConexionApis obj_Conexion = new GestorConexionApis();                     //INSTANCIO
            List<ArticuloModel> _lstResuldato = await obj_Conexion.ListarAticulo();
            return View(_lstResuldato);
        }

        #endregion



    }
}
