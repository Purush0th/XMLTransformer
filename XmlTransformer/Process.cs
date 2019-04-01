using NDesk.Options;
using System;
using System.Drawing;
using Console = Colorful.Console;

namespace XmlTransformer
{
    public class Process
    {

        public Process(string[] args)
        {
            try
            {
                Console.WriteAscii("XML Transformer", Color.CadetBlue);

                string baseConfigPath = null;
                string transformConfigPath = null;
                string outputConfigPath = null;

                var p = new OptionSet {
                    { "b|base=",      i => baseConfigPath = i },
                    { "t|transform=",      i => transformConfigPath = i },
                    { "o|output=", i => outputConfigPath = i  }
                };

                var options = p.Parse(args);

                // validating parameters
                if (baseConfigPath == null)
                    throw new InvalidOperationException("Missing required option -base=FILE");

                if (transformConfigPath == null)
                    throw new InvalidOperationException("Missing required option -transform=FILE");

                if (outputConfigPath == null)
                    throw new InvalidOperationException("Missing required option -output=FILE");

                //end of: validating parameters

                Console.WriteLine($"Reading base file \"{baseConfigPath}\"");
                var baseFileContent = FileUtil.ReadContent(baseConfigPath);

                if (baseFileContent == null)
                {
                    throw new Exception("File could not be read.");
                }

                Console.WriteLine($"Reading transform file \"{transformConfigPath}\"");
                var transformFileContent = FileUtil.ReadContent(transformConfigPath);

                if (transformFileContent == null)
                {
                    throw new Exception("File could not be read.");
                }

                Console.WriteLine("Merging files...");
                var results = Transformer.Merge(baseFileContent, transformFileContent);

                if (results == null)
                    throw new ApplicationException("Error occured.");

                var status = FileUtil.SaveContent(results, outputConfigPath);

                Console.WriteLine();

                if (status)
                    Console.WriteLine("Success", Color.Green);
                else
                    Console.WriteLine("Error", Color.Red);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

