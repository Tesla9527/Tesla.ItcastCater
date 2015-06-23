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
    public class ProductPage
    {
        public static void AddProduct(int Num)
        {
            try
            {
                String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                String folderName = Report.getreportname();
                Report.UpdateTestLogTitle(methodName);

                // Test Data
                DataTable dt = ExcelHelper.GetXlsDataSource(folderName, "AddProduct.xls");
                string productCategory = dt.Rows[Num]["ProductCategory"].ToString();
                string productName = dt.Rows[Num]["ProductName"].ToString();
                string number = dt.Rows[Num]["Number"].ToString();
                string price = dt.Rows[Num]["Price"].ToString();
                string unitCost = dt.Rows[Num]["UnitCost"].ToString();
                string spell = dt.Rows[Num]["Spell"].ToString();
                string unit = dt.Rows[Num]["Unit"].ToString();
                string stock = dt.Rows[Num]["Stock"].ToString();
                string remark = dt.Rows[Num]["Remark"].ToString();

                Mouse.Click(ItcastCaterModules.ProductPageUI.UI餐饮管理系统Window.UIBtnCategoryWindow.UIBtnCategoryButton);
                Mouse.Click(ItcastCaterModules.ProductPageUI.UIFrmCategoryWindow.UI增加产品Window.UI增加产品Button);

                ItcastCaterModules.ProductPageUI.UIFrmChangeProductWindow.UICmbCategoryWindow.UICmbCategoryComboBox.SelectedItem = productCategory;
                Keyboard.SendKeys(ItcastCaterModules.ProductPageUI.UIFrmChangeProductWindow.UITxtNameWindow.UITxtNameEdit, productName);
                Keyboard.SendKeys(ItcastCaterModules.ProductPageUI.UIFrmChangeProductWindow.UITxtNumWindow.UITxtNumEdit, number);
                Keyboard.SendKeys(ItcastCaterModules.ProductPageUI.UIFrmChangeProductWindow.UITxtCostWindow.UITxtCostEdit, price);
                Keyboard.SendKeys(ItcastCaterModules.ProductPageUI.UIFrmChangeProductWindow.UITxtPriceWindow.UITxtPriceEdit, unitCost);
                Keyboard.SendKeys(ItcastCaterModules.ProductPageUI.UIFrmChangeProductWindow.UITxtSpellWindow.UITxtSpellEdit, spell);
                Keyboard.SendKeys(ItcastCaterModules.ProductPageUI.UIFrmChangeProductWindow.UITxtUnitWindow.UITxtUnitEdit, unit);
                Keyboard.SendKeys(ItcastCaterModules.ProductPageUI.UIFrmChangeProductWindow.UITxtStockWindow.UITxtStockEdit, stock);
                Keyboard.SendKeys(ItcastCaterModules.ProductPageUI.UIFrmChangeProductWindow.UITxtRemarkWindow.UITxtRemarkEdit, remark);

                Mouse.Click(ItcastCaterModules.ProductPageUI.UIFrmChangeProductWindow.UI确定Window.UI确定Button);

                Assert.AreEqual(true, ItcastCaterModules.ProductPageUI.UI确定Window.UI确定Button.Exists);
                Mouse.Click(ItcastCaterModules.ProductPageUI.UI确定Window.UI确定Button);
                Report.UpdateTestLog("Add Product", "Add Product successfully", Report.Status.PASS);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Add Product", "Add Product failed", Report.Status.FAIL);
                throw new Exception(e.Message);
            }
        }
    }
}
