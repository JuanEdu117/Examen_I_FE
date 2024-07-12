using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi_Examen_I.Models;

namespace WebApi_Examen_I.Controllers
{
    public class GestorConexionApis
    {
        #region VARIABLES PUBLICAS
        public HttpClient hcConexionApis { get; set; }
        public GestorConexionApis() 
        {
            hcConexionApis = new HttpClient();
            EstablecerDataBaseConexion();
        }
        #endregion

        #region METODOS

        #region METODO PRIVADO
        private void EstablecerDataBaseConexion() 
        {
                                                                            // INDICAR QUE EL TRASLADO DE DATOS VA EN FORMATO JSON Y QUE CUAL ES LA DIRECCION BASE AL QUE VA APUNTAR
            hcConexionApis.BaseAddress = new Uri("http://localhost:35449");              // EL URI AGARRA LA RUTA BASE  DEL API
            hcConexionApis.DefaultRequestHeaders.Accept.Clear();                        //SE LIMPIAN LOS VALORES POR DEFECTO   
            hcConexionApis.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
        #endregion

        #region METODOS PUBLICOS

        #region ARTÍCULOS MONGODB
        public async Task<List<ArticuloModel>> ListarAticulo() 
        {
            List<ArticuloModel> _lstResultado = new List<ArticuloModel>();
            string _sRutaAPI = @"api/Articulo/ConsultarArticulo";                              //VA A CONCATENAR A LA RUTA BASE

            HttpResponseMessage resultadoconsumo = await hcConexionApis.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string _sJsonstring = await resultadoconsumo.Content.ReadAsStringAsync();   //AL RESULTADO CONSUMO LEER EL CONTENIDO QUE TRAE
                _lstResultado = JsonSerializer.Deserialize<List<ArticuloModel>>(_sJsonstring);
            }
            return _lstResultado;
        }
        public async Task<List<ArticuloModel>> FiltrarArticulo(ArticuloModel Obj_Articulo)                   // MATERIA CLASE V ↓↓↓↓
        {
            List<ArticuloModel> _lstResultado = new List<ArticuloModel>();
            string _sRutaAPI = @"api/Articulo/FiltrarArticulo";                              //VA A CONCATENAR A LA RUTA BASE

            hcConexionApis.DefaultRequestHeaders.Add("iCod", Obj_Articulo.iCodigo.ToString());
            hcConexionApis.DefaultRequestHeaders.Add("sDescrip", Obj_Articulo.sDescripcion);
            hcConexionApis.DefaultRequestHeaders.Add("dbPrecio", Obj_Articulo.dbPrecio_Unitario.ToString());

            HttpResponseMessage resultadoconsumo = await hcConexionApis.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string _sJsonstring = await resultadoconsumo.Content.ReadAsStringAsync(); //AL RESULTADO CONSUMO LEER EL CONTENIDO QUE TRAE
                _lstResultado = JsonSerializer.Deserialize<List<ArticuloModel>>(_sJsonstring);
            }
            return _lstResultado;
        }
        public async Task<bool> AgregarArticulo(ArticuloModel Obj_Articulo) 
        {
            string _sRutaAPI = @"api/Articulo/AgregarArticulo";                              //VA A CONCATENAR A LA RUTA BASE
            HttpResponseMessage resultadoconsumo = await hcConexionApis.PostAsJsonAsync(_sRutaAPI, Obj_Articulo);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarArticulo(ArticuloModel Obj_Articulo) 
        {
            string _sRutaAPI = @"api/Articulo/ModificarArticulo";                              //VA A CONCATENAR A LA RUTA BASE
            hcConexionApis.DefaultRequestHeaders.Add("_sId", Obj_Articulo.sId);
            HttpResponseMessage resultadoconsumo = await hcConexionApis.PutAsJsonAsync(_sRutaAPI, Obj_Articulo);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarArticulo(ArticuloModel Obj_Articulo)
        {
            string _sRutaAPI = @"api/Articulo/EliminarArticulo";                              //VA A CONCATENAR A LA RUTA BASE
            hcConexionApis.DefaultRequestHeaders.Add("_sId", Obj_Articulo.sId);
            HttpResponseMessage resultadoconsumo = await hcConexionApis.DeleteAsync(_sRutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #region PERSONA SQLServer
        public async Task<List<PersonaModel>> ConsultarPersona() 
        {
            List<PersonaModel> _lstResultado = new List<PersonaModel>();
            string _sRutaAPI = @"api/Persona/ConsultarPersona";             //VA A CONCATENAR A LA RUTA BASE
            HttpResponseMessage resultadoconsumo = await hcConexionApis.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode) 
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync(); //AL RESULTADO CONSUMO LEER EL CONTENIDO QUE TRAE
                _lstResultado = JsonSerializer.Deserialize<List<PersonaModel>>(jsonstring);
            }
            return _lstResultado;
        }
        public async Task<bool> AgregarPersona(PersonaModel Obj_Persona) 
        {
            string _sRutaAPI = @"api/Persona/AgregarPersona";             //VA A CONCATENAR A LA RUTA BASE
            HttpResponseMessage resultadoconsumo = await hcConexionApis.PostAsJsonAsync(_sRutaAPI, Obj_Persona);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarPersona(PersonaModel Obj_Persona)
        {
            string _sRutaAPI = @"api/Persona/ModificarPersona";             //VA A CONCATENAR A LA RUTA BASE
            hcConexionApis.DefaultRequestHeaders.Add("_iCed", Obj_Persona.iCedula.ToString());
            HttpResponseMessage resultadoconsumo = await hcConexionApis.PutAsJsonAsync(_sRutaAPI, Obj_Persona);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarPersona(PersonaModel Obj_Persona)
        {
            string _sRutaAPI = @"api/Persona/EliminarPersona";             //VA A CONCATENAR A LA RUTA BASE
            hcConexionApis.DefaultRequestHeaders.Add("_iCed", Obj_Persona.iCedula.ToString());
            HttpResponseMessage resultadoconsumo = await hcConexionApis.DeleteAsync(_sRutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #endregion

        #endregion
    }
}
