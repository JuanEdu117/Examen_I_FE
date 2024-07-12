using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult AbrirNuevoRegistroArtic()  //CREAMOS VISTA DE TIPO CREATE
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarArtic(string _sIdArtic)   //CREAMOS VISTA DE TIPO EDIT
        {
            GestorConexionApis obj_Conexion = new GestorConexionApis();
            List<ArticuloModel> _lstResultado = await obj_Conexion.FiltrarArticulo(new ArticuloModel { sId = _sIdArtic });
            ArticuloModel Obj_Encontrado = _lstResultado.FirstOrDefault();
            return View(Obj_Encontrado);
        }
        #endregion

        #region MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertArticulo(ArticuloModel Obj_Articulo) 
        {
            GestorConexionApis obj_Conexion = new GestorConexionApis();                     //INSTANCIO
            await obj_Conexion.AgregarArticulo(Obj_Articulo);
            return RedirectToAction("Index","Articulo");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArticulo(ArticuloModel Obj_Articulo)
        {
            GestorConexionApis obj_Conexion = new GestorConexionApis();                     //INSTANCIO
            await obj_Conexion.ModificarArticulo(Obj_Articulo);
            return RedirectToAction("Index", "Articulo");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteArticulo(string _sIdArtic)
        {
            GestorConexionApis obj_Conexion = new GestorConexionApis();                     //INSTANCIO
            await obj_Conexion.EliminarArticulo(new ArticuloModel {sId = _sIdArtic });
            return RedirectToAction("Index", "Articulo");
        }
        #endregion

    }
}
