using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETech.Domain.Dtos
{
   public class ErrorResponseDto
    {
        public int Status { get; set; }
        public string Description { get; set; }
        public List<string> Errors { get; set; }
    }
}
