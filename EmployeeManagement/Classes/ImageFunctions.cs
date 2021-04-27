using Emgu.CV;
using EmployeeManagement.Classes;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace EmployeeManagement
{
    /// <summary>
    /// Class that contains Image Functions.
    /// </summary>
    public static class ImageFunctions
    {
        /// <summary>
        /// Gets Bitmap From Webcam.
        /// Requires Emgu.CV version 3.3.0.2824
        /// </summary>
        /// <returns>Bitmap from Webcam</returns>
        public static Bitmap GetBitmapFromWebcam()
        {
            try
            {
                //create a camera capture
                VideoCapture capture = new VideoCapture();

                //get the bitmap from the camera capture
                Bitmap BMP = capture.QueryFrame().Bitmap;

                //turn camera off
                capture.Dispose();

                //resize bitmap so that height is 100 pixels 
                BMP = ResizeBitmap(BMP, (int)(100m * BMP.Width / BMP.Height), 100);

                return BMP;
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
                _ = MessageBox.Show("There was a problem taking the photo :(",
                                    "Camera not found or ready",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Gets the byte array from an Image in Bitmap format.
        /// </summary>
        /// <param name="imageIn">An Image object</param>
        /// <returns>The byte array of a Bitmap Image</returns>
        public static byte[] GetByteArrayFromBitMapImage(Image imageIn)
        {
            try
            {
                if (imageIn != null)
                {
                    //create a new memory stream
                    MemoryStream ms = new MemoryStream();
                    // here, we save image as a bitmap to a memory stream
                    imageIn.Save(ms, ImageFormat.Bmp);
                    //return the array of bytes in the memory stream
                    return ms.ToArray();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
                return null;
            }
        }

        /// <summary>
        /// Gets an Image from a Byte Array.
        /// </summary>
        /// <param name="byteArrayIn">The byte array for an Image</param>
        /// <returns>An Image object</returns>
        public static Image GetImageFromByteArray(byte[] byteArrayIn)
        {
            try
            {
                if (byteArrayIn != null)
                {
                    // use a memory stream object buit from the byte array
                    using (MemoryStream ms = new MemoryStream(byteArrayIn))
                    {
                        // to return the image
                        return Image.FromStream(ms);
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
                return null;
            }
        }

        /// <summary>
        /// Resizes a Bitmap object.
        /// </summary>
        /// <param name="bmp">The bitmap to resize</param>
        /// <param name="width">The width to resize to</param>
        /// <param name="height">The height to resize to</param>
        /// <returns>The resized bitmap</returns>
        public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            try
            {
                Bitmap result = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.DrawImage(bmp, 0, 0, width, height);
                }

                return result;
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
                return null;
            }
        }

        /// <summary>
        /// Resizes an image.
        /// </summary>
        /// <param name="image">The image to resize</param>
        /// <param name="width">The width to resize to</param>
        /// <param name="height">The height to resize to</param>
        /// <returns>The resized image</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            try
            {
                Rectangle destRect = new Rectangle(0, 0, width, height);
                Bitmap destImage = new Bitmap(width, height);

                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (Graphics graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (ImageAttributes wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                return destImage;

            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
                return null;
            }
        }
    }
}
