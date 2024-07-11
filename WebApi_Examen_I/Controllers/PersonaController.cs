using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // CREAR VISTA PARA ABRIR NUEVO REGISTRO
        public IActionResult AbrirNuevoRegistro()   //CREAMOS VISTA DE TIPO CREATE REFERENTE AL MODEL PERSONA CON EL WIZARD
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarPersona(string _sCedula)         //CREAMOS VISTA DE TIPO EDIT
        {
            GestorConexionApis Obj_GECNX = new GestorConexionApis();
            List<PersonaModel> _lstResultado = await Obj_GECNX.ConsultarPersona();      //COMO VIENE INT PASARLO A TOSTRING
            PersonaModel Obj_Encontrado = _lstResultado.Where(item => item.iCedula.ToString().Equals(_sCedula)).FirstOrDefault();  //BUSCAR EN LA LISTA MEMORIA
            return View(Obj_Encontrado);
        }

        #endregion

        #region EVENTOS DE MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertPersona(PersonaModel Obj_Persona)
        {
            GestorConexionApis Obj_GECNX = new GestorConexionApis();
            await Obj_GECNX.AgregarPersona(Obj_Persona);
            return RedirectToAction("Index", "Persona");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePersona(PersonaModel Obj_Persona)
        {
            GestorConexionApis Obj_GECNX = new GestorConexionApis();
            await Obj_GECNX.ModificarPersona(Obj_Persona);
            return RedirectToAction("Index", "Persona");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePersona(string _sCedula)
        {
            GestorConexionApis Obj_GECNX = new GestorConexionApis();
            await Obj_GECNX.EliminarPersona(new PersonaModel { iCedula = Convert.ToInt32(_sCedula) });
            return RedirectToAction("Index", "Persona");
        }
        #endregion
    }
}
