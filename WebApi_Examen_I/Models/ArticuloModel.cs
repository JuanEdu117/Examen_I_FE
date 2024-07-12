using System;
using System.Diagnostics.Contracts;

namespace WebApi_Examen_I.Models
{
    public class ArticuloModel
    {
        #region VARIABLES PUBLICAS
        public string sId { get; set; }
        public string sDescripcion { get; set; }
        public int iCodigo { get; set; }
        public int iCant_Disponible { get; set; }
         public DateTime dtmFecha_Caducidad { get; set; }
        public double dbPrecio_Unitario { get; set; }
        public ArticuloModel() 
        {
            sId = string.Empty;
            sDescripcion = string.Empty;
            iCodigo = 0;
            iCant_Disponible = 0;
            dtmFecha_Caducidad = DateTime.MinValue;
            dbPrecio_Unitario = 0;
        }
        #endregion
    }
}
