using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Formulario.Models.ViewModels
{
    public class ListCrudViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
    }
}