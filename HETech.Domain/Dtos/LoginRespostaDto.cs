using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETech.Domain.Dtos
{
    public  class LoginRespostaDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
