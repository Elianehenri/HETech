using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETech.Domain.Exceptions
{
    public class InserirDadosException : Exception
    {
        public InserirDadosException(string message) : base(message)
        {
        }
    }
}
