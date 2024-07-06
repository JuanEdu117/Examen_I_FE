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
