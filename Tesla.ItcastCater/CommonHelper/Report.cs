using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tesla.ItcastCater.CommonHelper
{
    public class Report
    {
        private static string testLogPath, screenshotpath, reportname;
        private static string headingColor, settingColor, bodyColor;
        private static bool takeScreenshotFailedStep, takeScreenshotPassedStep;
        private static int stepno;
        private static int pass_no;
        private static int fail_no;
        private static DateTime start_time;
        private static DateTime end_time;
        private static string functioncontent;
        private static int function_no;
        public enum Status
        {
            PASS, FAIL, DONE
        }

        public static void setstepno(int newstepno)
        {
            stepno = newstepno;
        }

        public static int getstepno()
        {
            return stepno;
        }

        public static void setpassno(int newpassno)
        {
            pass_no = newpassno;
        }

        public static int getpassno()
        {
            return pass_no;
        }

        public static void setfailno(int newfailno)
        {
            fail_no = newfailno;
        }

        public static int getfailno()
        {
            return fail_no;
        }

        public static void setstarttime(DateTime newstarttime)
        {
            start_time = newstarttime;
        }

        public static DateTime getstarttime()
        {
            return start_time;
        }

        public static void setendtime(DateTime newendtime)
        {
            end_time = newendtime;
        }

        public static DateTime getendtime()
        {
            return end_time;
        }

        public static void InitialReport(string reportPath, string ReportName, bool TakeScreenshotFailedStep, bool TakeScreenshotPassedStep)
        {
            reportname = ReportName;

            CreateIfMissing(reportPath);
            testLogPath = reportPath + reportname + "_" + DateTime.Now.ToString("dd_MMM_yyyy_hh_mm_ss_tt") + ".html";

            screenshotpath = reportPath + "Screenshots\\";
            CreateIfMissing(screenshotpath);

            headingColor = "#687C7D";
            settingColor = "#C6D0D1";
            bodyColor = "#EDEEF0";

            takeScreenshotFailedStep = TakeScreenshotFailedStep;
            takeScreenshotPassedStep = TakeScreenshotPassedStep;
        }

        private static void CreateIfMissing(string path)
        {
            if (!Directory.Exists(path))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
        }

        public static string getreportname()
        {
            return reportname;
        }

        public static void CreateTestLogHeader(string projectName)
        {
            string testLogHeader;
            testLogHeader = "<html>" +
                                "<head>" +
                                    "<title>" +
                                        projectName + " - " + reportname + " Automation Execution Results" +
                                    "</title>" +

                                    "<script>" +

                                    "function toggleMenu(objID) {  if (!document.getElementById) return; 	 var ob = document.getElementById(objID).style;  if(ob.display === 'none') { 					 try {  ob.display='table-row-group';  } catch(ex) {						 ob.display='block';  }  }  else {  ob.display='none';  }  } " +
                                    "function toggleSubMenu(objId) { for(i=1; i<10000; i++) { 	 var ob = document.getElementById(objId.concat(i));  if(ob === null) {  break;  }  if(ob.style.display === 'none') {  try { ob.style.display='table-row'; } catch(ex) { ob.style.display='block'; } } else { ob.style.display='none';  }}}" +

                                    "</script>" +


                                "</head>" +

                                "<body>" +
                                    "<p align='center'>" +
                                        "<table border='1' bordercolor='#000000' bordercolorlight='#FFFFFF' cellspacing='0' id='table1' width='1000' height='100'>" +
                                            "<tr bgcolor='" + headingColor + "'>" +
                                                "<td colspan='5'>" +
                                                    "<p align='center'><font color='" + bodyColor + "' size='4' face='Copperplate Gothic Bold'>" +
                                                        projectName + " - " + reportname + " Automation Execution Results" +
                                                    "</font></p>" +
                                                "</td>" +
                                            "</tr>" +

                                            "<tr bgcolor='" + settingColor + "'>" +
                                                "<td colspan='3'>" +
                                                    "<p align='justify'><b><font color='" + headingColor + "' size='2' face='Verdana'>" +
                                                        "DATE: " + DateTime.Now.ToString("dd-MM-yyyy") +
                                                    "</p></font></b>" +
                                                "</td>" +
                                                "<td colspan='2'>" +
                                                    "<p align='justify'><b><font color='" + headingColor + "' size='2' face='Verdana'>" +
                                                        "Time: " + DateTime.Now.ToString("hh:mm:ss tt") +
                                                    "</p></font></b>" +
                                                "</td>" +
                                            "</tr>" +





                                            "<tr bgcolor='" + headingColor + "'>" +
                                                "<td><b><font color='" + bodyColor + "' size='2' face='Verdana'>Step No</font></b></td>" +
                                                "<td><b><font color='" + bodyColor + "' size='2' face='Verdana'>Step Name</font></b></td>" +
                                                "<td><b><font color='" + bodyColor + "' size='2' face='Verdana'>Description</font></b></td>" +
                                                "<td><b><font color='" + bodyColor + "' size='2' face='Verdana'>Status</font></b></td>" +
                                                "<td><b><font color='" + bodyColor + "' size='2' face='Verdana'>Time</font></b></td>" +
                                            "</tr>";
            try
            {
                File.WriteAllText(testLogPath, testLogHeader, System.Text.Encoding.GetEncoding("GB2312"));
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);

            }
        }

        public static void UpdateTestLogTitle(string currentfunctionname)
        {
            StreamWriter streamWriter = null;
            try
            {
                functioncontent = currentfunctionname;
                function_no = 0;
                streamWriter = new StreamWriter(testLogPath, true);
                string testStepRow = "<tr class='subheading subsection'>" +
                                        "<td colspan='5' size='2' face='Verdana'onclick=\"toggleSubMenu('" + functioncontent +
                                        "')\">" +
                                        "<font size='2' face='Verdana'>&nbsp;+ " + functioncontent + "</font>" +
                                        "</td>" +
                                      "</tr>";
                streamWriter.Write(testStepRow);
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);

            }
            finally
            {
                streamWriter.Close();
            }
        }


        public static void UpdateTestLog(string stepName, string stepDescription, Status stepStatus)
        {
            string screenShotName;
            StreamWriter streamWriter = null;
            stepno = stepno + 1;
            function_no = function_no + 1;
            try
            {
                streamWriter = new StreamWriter(testLogPath, true);

                string testStepRow = "<tr bgcolor='" + bodyColor + "' class='content' id='" + functioncontent + function_no + "'>" +
                                        "<td>" +
                                            "<font size='2' face='Verdana'>" + stepno + "</font>" +
                                        "</td>" +
                                        "<td>" +
                                            "<font size='2' face='Verdana'>" + stepName + "</font>" +
                                        "</td>" +
                                        "<td>" +
                                            "<font size='2' face='Verdana'>" + stepDescription + "</font>" +
                                        "</td>";


                if (stepStatus.Equals(Status.FAIL))
                {
                    fail_no = fail_no + 1;
                    if (takeScreenshotFailedStep)
                    {
                        screenShotName = functioncontent + "_Fail_" + DateTime.Now.ToString("dd_MMM_yyyy_hh_mm_ss_tt");
                        ScreenshotHelper.TakeScreenshot(screenshotpath + screenShotName + ".png");

                        testStepRow += "<td>" +
                                           "<a href='Screenshots\\" + screenShotName + ".png" + "' target='about_blank'>" +
                                               "<font color='red' size='2' face='Verdana'><b>" + stepStatus + "</b></font>" +
                                           "</a>" +
                                       "</td>";
                    }
                    else
                    {
                        testStepRow += "<td>" +
                                            "<font color='red' size='2' face='Verdana'><b>" + stepStatus + "</b></font>" +
                                        "</td>";
                    }
                }
                else if (stepStatus.Equals(Status.PASS))
                {

                    pass_no = pass_no + 1;
                    if (takeScreenshotPassedStep)
                    {
                        screenShotName = functioncontent + "_Pass_" + DateTime.Now.ToString("dd_MMM_yyyy_hh_mm_ss_tt");
                        ScreenshotHelper.TakeScreenshot(screenshotpath + screenShotName + ".png");
                        testStepRow += "<td>" +
                                            "<a href='Screenshots\\" + screenShotName + ".png" + "' target='about_blank'>" +
                                                "<font color='green' size='2' face='Verdana'><b>" + stepStatus + "</b></font>" +
                                            "</a>" +
                                        "</td>";
                    }
                    else
                    {
                        testStepRow += "<td>" +
                                            "<font color='green' size='2' face='Verdana'><b>" + stepStatus + "</b></font>" +
                                        "</td>";
                    }
                }
                else
                {
                    testStepRow += "<td>" +
                                        "<font size='2' face='Verdana'><b>" + stepStatus + "</b></font>" +
                                    "</td>";
                }

                testStepRow += "<td>" +
                                    "<font size='2' face='Verdana'>" + Util.GetCurrentFormattedTime() + "</font>" +

                                        "</td>" +
                                    "</tr>";

                streamWriter.Write(testStepRow);

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);

            }
            finally
            {
                streamWriter.Close();
            }
        }

        public static void CreateTestLogFooter(string executionTime, int nStepsPassed, int nStepsFailed)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(testLogPath, true);

                string testLogFooter = "<tr bgcolor='" + settingColor + "'>" +
                                            "<td colspan='5'>" +
                                                "<center><b><font color='" + headingColor + "' size='2' face='Verdana'>Execution Duration: " + executionTime + "</font></b></center>" +
                                            "</td>" +
                                        "</tr>" +
                                        "<tr bgcolor='" + settingColor + "'>" +
                                            "<td colspan='3'>" +
                                                "<b><font color='green' face='Verdana'>PASS: " + nStepsPassed + "</b></font>" +
                                            "</td>" +
                                            "<td colspan=2>" +
                                                "<b><font color='red' face='Verdana'>FAIL: " + nStepsFailed + "</b></font>" +
                                            "</td>" +
                                        "</tr>" +
                                    "</table>" +
                                "</body>" +
                            "</html>";

                streamWriter.Write(testLogFooter);

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);

            }
            finally
            {
                streamWriter.Close();
            }
        }

    }
}