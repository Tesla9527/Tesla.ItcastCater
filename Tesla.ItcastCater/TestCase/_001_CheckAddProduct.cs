using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.ItcastCater.CommonHelper;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tesla.ItcastCater.Modules;

namespace Tesla.ItcastCater.TestCase
{
    [TestClass]
    public class _001_CheckAddProduct
    {
        [TestMethod]
        public void _001__CheckAddProduct()
        {
            try
            {
                LoginPage.LoginItcastCater(0);
                ProductPage.AddProduct(0);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Error message is caught in TC - " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message, Report.Status.FAIL);
                throw new Exception(e.Message);
            }
        }    
   
        #region TestInitialize and TestCleanup
        [TestInitialize]
        public void TestInitialize()
        {
            Initialize(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            CloseReport();
            Playback.Cleanup();
            Assert.AreEqual(0, Report.getfailno());
        }
        public static void Initialize(string reportname)
        {
            bool takeScreenshotFailedStep = Convert.ToBoolean(ExcelHelper.GetAppConfig("TakeScreenshotFailedStep"));
            bool takeScreenshotPassedStep = Convert.ToBoolean(ExcelHelper.GetAppConfig("TakeScreenshotPassedStep"));

            string reportpath = ExcelHelper.GetAppConfig("reportpath");

            Report.InitialReport(reportpath, reportname, takeScreenshotFailedStep, takeScreenshotPassedStep);

            Report.CreateTestLogHeader("ItcastCater Demo");

            Report.setstepno(0);

            Report.setpassno(0);

            Report.setfailno(0);

            Report.setstarttime(DateTime.Now);
        }
        public static void CloseReport()
        {
            Report.setendtime(DateTime.Now);

            Report.CreateTestLogFooter(Util.GetTimeDifference(Report.getstarttime(), Report.getendtime()), Report.getpassno(), Report.getfailno());
        }
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContextInstance)
        {
           AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomainAssemblyResolver.Resolver);
           Playback.Initialize();
        }
        #endregion
    }
}
