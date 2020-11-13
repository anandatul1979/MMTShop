using System.IO;
using System.Text;

namespace Console
{
    public static class StreamExtensions
    {
        public static string ReadAllText(this Stream stream)
        {
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new StreamReader(stream, encoding))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
