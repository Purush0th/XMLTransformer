using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlTransformer.Test
{

    [TestClass]
    public class MergerTest
    {

        [TestMethod]
        public void TestMergeXml()
        {
            string baseConfigString = "<?xml version=\"1.0\"?>" +
                                      "<configuration xmlns:xdt=\"http://schemas.microsoft.com/XML-Document-Transform\">" +
                                      "    <connectionStrings>" +
                                      "    <add name=\"DefaultConnection\" connectionString=\"value for the deployed Web.config file\" xdt:Transform=\"SetAttributes\" xdt:Locator=\"Match(name)\"/>" +
                                      "    </connectionStrings>" +
                                      "</configuration >";


            string targetConfigString = "<?xml version=\"1.0\"?>" +
                                        "<configuration xmlns:xdt=\"http://schemas.microsoft.com/XML-Document-Transform\">" +
                                        "    <connectionStrings>" +
                                        "    <add name=\"DefaultConnection\" connectionString=\"value for the deployed Web.config file\"  " +
                                        "		      providerName=\"System.Data.SqlClient\" xdt:Transform=\"Replace\" xdt:Locator=\"Match(name)\"/>" +
                                        "    </connectionStrings>" +
                                        "</configuration >";

            string expectedOutputString = "<?xml version=\"1.0\"?>\r\n<configuration xmlns:xdt=\"http://schemas.microsoft.com/XML-Document-Transform\">    <connectionStrings>    <add name=\"DefaultConnection\" connectionString=\"value for the deployed Web.config file\" providerName=\"System.Data.SqlClient\" />    </connectionStrings></configuration>";

            string output = Transformer.Merge(baseConfigString, targetConfigString);

            Assert.AreEqual(expectedOutputString, output);
        }
    }
}
