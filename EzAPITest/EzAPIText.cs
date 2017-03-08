using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SqlServer.SSIS.EzAPI;
using Microsoft.SqlServer.Dts.Runtime;
using System.Text;
using System.IO;

namespace EzAPITest
{
    [TestClass]
    public class EzAPIText
    {
        [TestMethod]
        public void CheckNoFailLoadFromExistingPackage()
        {
            EzPackage package = new EzPackage();
            package.LoadFromFile(@"D:\Projectos\DevScope\EzApi\BI_adir_AdmissaoDirecta.dtsx");

            Assert.AreEqual(package.Name, "BI_adir_AdmissaoDirecta");
        }

        [TestMethod]
        public void CheckListOfVariables()
        {
            EzPackage package = new EzPackage();
            package.LoadFromFile(@"D:\Projectos\DevScope\EzApi\BI_adir_AdmissaoDirecta.dtsx");
            package.SaveToFile(@"D:\Projectos\DevScope\EzApi\BI_adir_AdmissaoDirectaGerado.dtsx");

            EzPackage package1 = new EzPackage();
            package1.LoadFromFile(@"D:\Projectos\DevScope\EzApi\BI_adir_AdmissaoDirectaGerado.dtsx");

            Variables variables = package1.Variables;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name;Description");

            foreach (Variable x in variables)
            {
                sb.AppendLine(x.Name + ";" + x.Description + ";" + x.Value.ToString());
            }

            File.WriteAllText(@"D:\Projectos\DevScope\EzApi\Variables.csv", sb.ToString());

            Assert.AreEqual("", "");
        }
    }
}
