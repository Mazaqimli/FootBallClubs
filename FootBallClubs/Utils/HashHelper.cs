using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FootBallClubs.Utils
{
    public class HashHelper
    {
        public static string  Hash(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            byte[] hash = SHA256.HashData(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
