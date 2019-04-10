using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlTransformer.Test
{
    [TestClass]
    public class ProcessTest
    {
        [TestMethod]
        public void ProcessShouldNotThrowException()
        {

            try
            {
                string baseDirPath = AppDomain.CurrentDomain.BaseDirectory;

                string cmdArgs = $"-b {baseDirPath}\\Data\\Web.config -t {baseDirPath}\\Data\\Web.Prod.config -o {baseDirPath}\\Data\\Output.config";
                string[] args = cmdArgs.Split(' ');

                Process process = new Process(args);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }
    }
}
