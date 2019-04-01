using System;
using System.Drawing;
using System.IO;
using Console = Colorful.Console;

namespace XmlTransformer
{
    public static class FileUtil
    {
        public static FileInfo GetFile(string filePath)
        {

            try
            {

                bool isFileExists = File.Exists(filePath);

                if (!isFileExists)
                {
                    return null;
                }

                FileInfo fileInfo = new FileInfo(filePath);

                return fileInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, Color.Red);
                return null;
            }

        }

        public static string ReadContent(string filePath)
        {
            try
            {
                var fileInfo = GetFile(filePath);

                return File.ReadAllText(fileInfo.FullName);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, Color.Red);
                return null;
            }
        }

        public static bool SaveContent(string content, string filePath)
        {
            try
            {
                var fileInfo = GetFile(filePath);

                if (fileInfo != null)
                    File.Delete(fileInfo.FullName);

                File.WriteAllText(filePath, content);

                Console.WriteLine($"Saved file to \"{filePath}\"");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, Color.Red);
                return false;
            }

        }


    }
}
