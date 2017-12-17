using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseVillage.Classes
{
    public class Sha512
    {
        public static string GetSHA512(string String)
        {
            byte[] hashValue;
            byte[] message = System.Text.Encoding.UTF8.GetBytes(String);
            SHA512Managed hashString = new SHA512Managed();
            string hexStr = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte b in hashValue)
            {
                hexStr += String.Format("{0:x2}", b);
            }

            return hexStr;
        }
    }
}
