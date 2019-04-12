using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopSoft.Models
{
    public class UsuarioEntity
    {
        private int UsuarioId { get; set; }
        public string Email { get; set; }
        private int Clave { get; set; }
        public string NombreUsuario { get; set; }
    }
}
