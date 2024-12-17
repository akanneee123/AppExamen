using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppExamen.Models
{
    public class Asignacion
    {
        public int ID_Asignacion { get; set; }
        public int ID_Empleado { get; set; }
        public int ID_Proyecto { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public Empleado Empleado { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}