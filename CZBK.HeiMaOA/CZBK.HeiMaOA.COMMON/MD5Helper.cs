using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.HeiMaOA.COMMON
{
    /// <summary>
    /// 计算字符串的md5值
    /// </summary>
    public class MD5Helper
    {
        /// <summary>
        /// 计算字符串的MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ComputeStringMD5(string str)
        {

            StringBuilder sb = new StringBuilder();
            //1.创建一个md5对象
            using(MD5 md5 = MD5.Create())
            {
                //1.1把字符串转换为byte[]
                //对于字符串中包含中文，如果在进行md5计算前，使用不同的编码返回字节数组，那么可能最后计算出的md5值会不相同，所以要使用相同的md5编码
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);

                //2.进行md5计算,md5计算完毕后，返回的也是一个byte[]
                byte[] bytes = md5.ComputeHash(buffer);
                md5.Clear();

                //3.把bytes中的每个字节转换为一个16进制表示的字符串，并返回
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 计算文件的MD5
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ComputeFileMD5(string path)
        {
            StringBuilder sb = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                FileStream fsRead = File.OpenRead(path);
                byte[] buffer = md5.ComputeHash(fsRead);

                //清空对象
                md5.Clear();

                for (int i = 0; i < buffer.Length; i++)
                {
                    sb.Append(buffer[i].ToString("X2"));
                }

                fsRead.Dispose();
                return sb.ToString();
            }
        }

        public static string ComputeFileMD5(Stream inputStream)
        {
            StringBuilder sb = new StringBuilder();
            using(MD5 md5 = MD5.Create())
            {
                byte[] buffer = md5.ComputeHash(inputStream);
                md5.Clear();
                for (int i = 0; i < buffer.Length; i++)
                {
                    sb.Append(buffer[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
