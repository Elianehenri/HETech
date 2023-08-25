using HETech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETech.Domain.Dtos
{
    public class UsuarioRegistrarDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Permissoes? Role { get; set; }

        public UsuarioRegistrarDto()
        {

        }
    }

    
     

}
