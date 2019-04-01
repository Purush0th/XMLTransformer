using System;
using System.Drawing;
using System.Text;
using System.Xml;
using Microsoft.Web.XmlTransform;
using Console = Colorful.Console;

namespace XmlTransformer
{
    public static class Transformer
    {

        public static string Merge(string webConfigXml, string transformXml)
        {
            try
            {
                using (var document = new XmlTransformableDocument())
                {
                    document.PreserveWhitespace = true;
                    document.LoadXml(webConfigXml);

                    using (var transform = new XmlTransformation(transformXml, false, null))
                    {
                        if (transform.Apply(document))
                        {
                            var stringBuilder = new StringBuilder();
                            var xmlWriterSettings = new XmlWriterSettings { Indent = true, IndentChars = "    " };

                            using (var xmlTextWriter = XmlWriter.Create(stringBuilder, xmlWriterSettings))
                            {
                                document.WriteTo(xmlTextWriter);
                            }

                            var result = stringBuilder.ToString();

                            return result;
                        }

                        Console.WriteLine("Transformation failed for unknown reason", Color.Red);
                        return null;
                    }
                }
            }
            catch (XmlTransformationException xmlTransformationException)
            {
                Console.WriteLine(xmlTransformationException.Message, Color.Red);
                return null;
            }
            catch (XmlException xmlException)
            {
                Console.WriteLine(xmlException.Message, Color.Red);
                return null;
            }
        }

    }
}
