using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlTransformer.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            string cmdArgs = "XMLTransformer.exe -b Web.config -t Web.Prod.config -o Output.config";
            string[] args = new string[]
            {

            };
            Process process = new Process(args);

        }
    }
}
