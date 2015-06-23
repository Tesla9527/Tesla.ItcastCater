using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System;

namespace Tesla.ItcastCater.CommonHelper
{
    public class ExcelHelper
    {
        /// <summary>
        /// Retrieve values associated with Key in App.config XML file
        /// </summary>
        /// <param name="strKey"></param>
        public static string GetAppConfig(string strKey)
        {
            return ConfigurationManager.AppSettings[strKey];
        }

        /// <summary>
        /// Retrieve data from XLS file
        /// </summary>
        /// <param name="containingFolder"></param>
        /// <param name="xlsFileName"></param>
        /// <returns></returns>
        public static System.Data.DataTable GetXlsDataSource(string containingFolder, string xlsFileName)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            if (Path.GetFileName(GetAppConfig("prefixXlsPath") + containingFolder + "\\" + xlsFileName).Trim().ToUpper().EndsWith("XLS"))
            {
                string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + GetAppConfig("prefixXlsPath") + containingFolder + "\\" + xlsFileName + ";Extended Properties='Excel 8.0'";
                string commandText = " SELECT * FROM [TestData$] ";
                OleDbConnection olconn = new OleDbConnection(connStr);
                olconn.Open();
                OleDbDataAdapter odp = new OleDbDataAdapter(commandText, olconn);
                odp.Fill(dt);
                olconn.Close();
                odp.Dispose();
                olconn.Dispose();
            }
            return dt;
        }
    }
}
