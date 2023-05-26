using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public sealed class PasswordUtility
    {
        private PasswordUtility() { }
        private static PasswordUtility instance = null;
        public static PasswordUtility Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PasswordUtility();
                }
                return instance;
            }
        }
        public bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                var computedpasswordHash = Convert.FromBase64String(passwordHash);
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != computedpasswordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
