using System.IO;
using System.Text;
using RabinLib;
using System.Numerics;
using System.Linq;
namespace Rabin_Window.BL
{
    public interface IFileManager
    {
        bool isExist(string filepath);
        void SaveContent(string content, string filepath);
        string GetContent(string path);
        string GetContent(string path, BigInteger OpenKey, out bool[] Signs);
        string GetContent(string path, Encoding encoding, BigInteger OpenKey, out bool[] Signs);
        void SaveContent(string content, string filepath, BigInteger p, BigInteger q);
        void SaveContent(string content, string filepath, Encoding encoding, BigInteger p, BigInteger q);
        int GetSymbloCount(string content);
    }

    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        public bool isExist(string filepath)
        {
            return File.Exists(filepath);
        }

        public string GetContent(string path, BigInteger OpenKey, out bool[] Signs)
        {
            return GetContent(path, _defaultEncoding, OpenKey, out Signs);
        }

        public string GetContent(string path)
        {
            return File.ReadAllText(path, _defaultEncoding);
        }

        public string GetContent(string path, Encoding encoding, BigInteger OpenKey, out bool[] Signs)
        {
            BigInteger[] conten = File.ReadAllLines(path, encoding).Select(p => BigInteger.Parse(p)).ToArray();

            string result = Rabin.DecryptModifSignBigText(conten, OpenKey, out Signs);

            return result;
        }

        public void SaveContent(string content, string filepath, BigInteger OpenKey, BigInteger SecretKey)
        {
            SaveContent(content, filepath, _defaultEncoding, OpenKey, SecretKey);
        }

        public void SaveContent(string content, string filepath, Encoding encoding, BigInteger OpenKey, BigInteger SecretKey)
        {
            BigInteger[] EncrypArr = Rabin.ModifCalcSignatureBigText(content, OpenKey, SecretKey);


            string[] res = EncrypArr.Select(p => p + "").ToArray();

            File.WriteAllLines(filepath, res, encoding);

        }

        public void SaveContent(string content, string filepath)
        {
            File.WriteAllText(filepath, content, _defaultEncoding);
        }

        public int GetSymbloCount(string content)
        {
            return content.Length;
        }

    }
}
