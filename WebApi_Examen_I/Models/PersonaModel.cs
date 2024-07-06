using System;

namespace WebApi_Examen_I.Models
{
    public class PersonaModel
    {
        #region VARIABLES PUBLICAS
        public int iCedula { get; set; }
        public string sNombre { get; set; }
        public string sApellido { get; set; }
        public bool bGenero { get; set; }
        public DateTime dtmFechaNacimiento { get; set; }

        public PersonaModel()
        {
            iCedula = 0;
            sNombre = string.Empty;
            sApellido = string.Empty;
            bGenero = true;
            dtmFechaNacimiento = DateTime.MinValue;
        }
        #endregion
    }
}
