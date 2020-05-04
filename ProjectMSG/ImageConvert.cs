using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace ProjectMSG
{
    internal class ImageConvert
    {
        public static BitmapImage ConvertByteArrayToImage(byte[] array)
        {
            if (array != null)
                using (var ms = new MemoryStream(array))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }

            return null;
        }

        public static byte[] ConvertImageToByteArray(string fileName)
        {
            var bitMap = new Bitmap(fileName);
            var bmpFormat = bitMap.RawFormat;
            var imageToConvert = Image.FromFile(fileName);
            using (var ms = new MemoryStream())
            {
                imageToConvert.Save(ms, bmpFormat);
                return ms.ToArray();
            }
        }
    }
}