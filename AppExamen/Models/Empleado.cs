using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppExamen.Models
{
    public class Empleado
    {
        public int ID_Empleado { get; set; }
        public string CarnetUnico { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public decimal Salario { get; set; }
        public int ID_Categoria { get; set; }
        public Categoria Categoria { get; set; } // Relación con la categoría
    }
}