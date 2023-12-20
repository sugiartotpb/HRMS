using System;
using System.IO;
using System.Security.Cryptography;

namespace SJAHE_BASE_LIBRARY.SecurityHelpers
{
    public static class SecurityEncryptedDecrypted
    {
        //public static string EncrypedProtectString(string strParm)
        //{
        //    var plaintextBytes = Encoding.UTF8.GetBytes(strParm);
        //    string encryptedValue = Convert.ToBase64String(MachineKey.Protect(plaintextBytes, "sjahe123"));
        //    return encryptedValue;
        //}

        //public static string EncrypedProtectInt(int intParm)
        //{
        //    var plaintextBytes = Encoding.UTF8.GetBytes(intParm.ToString());
        //    string encryptedValue = Convert.ToBase64String(MachineKey.Protect(plaintextBytes, "sjahe123"));
        //    return encryptedValue;
        //}

        //public static string DecryptedProtectString(string strParm)
        //{
        //    var bytes = Convert.FromBase64String(strParm);
        //    var output = MachineKey.Unprotect(bytes, "sjahe123");
        //    string parameterOut = Encoding.UTF8.GetString(output);
        //    return parameterOut;
        //}

        //public static int DecryptedProtectInt(string strParm)
        //{
        //    var bytes = Convert.FromBase64String(strParm);
        //    var output = MachineKey.Unprotect(bytes, "sjahe123");
        //    string parameterOut = Encoding.UTF8.GetString(output);
        //    int intParameterOut = Convert.ToInt32(parameterOut);
        //    return intParameterOut;
        //}

        public static string EncryptText(string strText, string strEncrKey)
        {
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            try
            {
                byte[] bykey = System.Text.Encoding.UTF8.GetBytes(strEncrKey);
                byte[] InputByteArray = System.Text.Encoding.UTF8.GetBytes(strText);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write);
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static string DecryptText(string strText, string sDecrKey)
        {
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray;
            try
            {
                byte[] bykey = System.Text.Encoding.UTF8.GetBytes(sDecrKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(bykey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
