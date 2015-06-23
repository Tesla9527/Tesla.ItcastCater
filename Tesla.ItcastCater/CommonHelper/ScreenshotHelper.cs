using System.Drawing;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Collections;
using System.Configuration;

namespace Tesla.ItcastCater.CommonHelper
{
    public class ScreenshotHelper
    {
        public static void TakeScreenshot(string screenshotPath)
        {
            Bitmap bmpScreenshot = null;
            Graphics gfxScreenshot = null;

            try
            {
                // Set the bitmap object to the size of the screen
                bmpScreenshot = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

                // Create a graphics object from the bitmap
                gfxScreenshot = Graphics.FromImage(bmpScreenshot);

                // Take the screenshot from the upper left corner to the right bottom corner
                gfxScreenshot.CopyFromScreen(System.Windows.Forms.Screen.PrimaryScreen.Bounds.X, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y, 0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                // Save the screenshot to the specified path that the user has chosen
                bmpScreenshot.Save(screenshotPath, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                bmpScreenshot.Dispose();
                gfxScreenshot.Dispose();
            }
        }
    }
}
