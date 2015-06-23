using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.ItcastCater.CommonHelper;
using System.Data;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tesla.ItcastCater.Modules
{
    public class LoginPage
    {
        public static void LoginItcastCater(int Num)
        {
            try
            {
                String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                String folderName = Report.getreportname();
                Report.UpdateTestLogTitle(methodName);

                // Test Data
                DataTable dt = ExcelHelper.GetXlsDataSource(folderName, "LoginItcastCater.xls");
                string userName = dt.Rows[Num]["UserName"].ToString();
                string password = dt.Rows[Num]["Password"].ToString();

                Keyboard.SendKeys(ItcastCaterModules.LoginPageUI.UI登陆Window.UITxtNameWindow.UITxtNameEdit, userName);
                Keyboard.SendKeys(ItcastCaterModules.LoginPageUI.UI登陆Window.UITxtPwdWindow.UITxtPwdEdit, password);
                Mouse.Click(ItcastCaterModules.LoginPageUI.UI登陆Window.UI登陆Window1.UI登陆Button);

                Assert.AreEqual(true, ItcastCaterModules.ProductPageUI.UI餐饮管理系统Window.UIBtnCategoryWindow.UIBtnCategoryButton.Exists);
                Report.UpdateTestLog("Login ItcastCater", "Login ItcastCater successfully", Report.Status.PASS);
           
            }
            catch(Exception e)
            {
                Report.UpdateTestLog("Login ItcastCater", "Login ItcastCater manager failed", Report.Status.FAIL);
                throw new Exception(e.Message);  
            }                         
        }
    }
}
