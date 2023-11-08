using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
namespace Biblioteca.Models
{
    public static class Criptofrafo
    {
        public static string TextoCriptografado(string textoSemFormatacao)
        {
            MD5 MD5Hasher = MD5.Create();

            byte[] By = Encoding.Default.GetBytes(textoSemFormatacao);
            byte[] bytesCritografado = MD5Hasher.ComputeHash(By);

            StringBuilder SB = new StringBuilder();
            foreach (byte b in bytesCritografado)
            {
                string DebugB = b.ToString("x2");
                SB.Append(DebugB);

            }
            return SB.ToString();
        } 
    }
}