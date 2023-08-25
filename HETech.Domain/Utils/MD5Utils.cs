using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HETech.Domain.Utils
{
    public class MD5Utils
    {
        public static string GerarHashMD5(string text)
        {
            using (MD5 md5hash = MD5.Create())
            {
                byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2")); // Converte o byte para formato hexadecimal
                }

                return stringBuilder.ToString();
            }
        }
    }
}

