using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Coypu;

namespace Utility
{
    public static class Tools
    {
        public static string TakeScreenshot(string path, BrowserSession session)
        {
            session.SaveScreenshot(path);

            return path;
        }

        public static int GenerateRandomValue()
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                var randomvalue = BitConverter.ToInt32(rno, 0);

                if (randomvalue < 0)
                    return randomvalue * -1;
                else
                    return randomvalue;

            }
            
        }
    }
}
