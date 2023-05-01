using System;
using System.IO;
using Xamarin.Forms;

namespace Naruto.ViewsModels
{
    internal static class ConvertImage
    {
        public static ImageSource ToPNG(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                Stream stream = new MemoryStream(imageBytes);
                return ImageSource.FromStream(() => stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}