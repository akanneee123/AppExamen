using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppExamen.Models
{
    public class Proyecto
    {
        public int ID_Proyecto { get; set; }
        public string NombreProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}