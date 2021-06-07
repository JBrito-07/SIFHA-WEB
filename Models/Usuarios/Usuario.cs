using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIFHA_WEB.Models.Usuarios
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="La Contraseña es Requerida")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "El Usuario es Requerido")]
        public string User { get; set; }
        public string NombreUsuario { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Estatus { get; set; }
    }
}
