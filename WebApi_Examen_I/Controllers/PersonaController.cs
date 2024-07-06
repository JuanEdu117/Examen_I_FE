using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Examen_I.Models;

namespace WebApi_Examen_I.Controllers
{
    public class PersonaController : Controller
    {
        #region EVENTOS DE APERTURA VIEW
        public async Task<IActionResult> Index()    //CREAMOS VISTA DE TIPO LIST
        {
            GestorConexionApis Obj_GECNX = new GestorConexionApis();
            List<PersonaModel> _lstResultado = await Obj_GECNX.ConsultarPersona();
            return View(_lstResultado);
        }


        #endregion
    }
}
