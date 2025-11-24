using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Drawing;
using System.Net.WebSockets;

namespace segundoEjemploASPNET.Herramientas.Tags
{
    [HtmlTargetElement("codigoqr")]
    public class CodigoQRTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var contenido = context.AllAttributes["contenido"]?.Value?.ToString() ?? "Texto por defecto";
            var ancho = context.AllAttributes["ancho"]?.Value?.ToString() ?? "950";
            var alto = context.AllAttributes["alto"]?.Value?.ToString() ?? "950";

            var barcodeWriterPixelData = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = int.Parse(alto),
                    Width = int.Parse(ancho),
                    Margin = 0
                }
            };
            var pixelData = barcodeWriterPixelData.Write(contenido);
            using (var bitmap = new Bitmap(pixelData.Width,pixelData.Height,System.Drawing.Imaging.PixelFormat.Format32bppRgb)) {
                using (var memoriaStream = new MemoryStream()) { 
                    var datosBitmap = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                        System.Drawing.Imaging.ImageLockMode.WriteOnly,
                        System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    // try-catch-finally
                    try
                    {
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, datosBitmap.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(datosBitmap);
                    }
                    bitmap.Save(memoriaStream, System.Drawing.Imaging.ImageFormat.Png);
                    output.TagName = "img";// <img>
                    output.Attributes.Clear();
                    output.Attributes.Add("width", ancho); // <img width="950">
                    output.Attributes.Add("height", alto); // <img width="950" height="950">
                    output.Attributes.Add("src", "data:image/png;base64," + Convert.ToBase64String(memoriaStream.ToArray()));
                }
            }
        }
    }

    [HtmlTargetElement("codigobr")]
    public class CodigoBarraTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var contenido = context.AllAttributes["contenido"]?.Value?.ToString() ?? "Texto por defecto";
            var ancho = context.AllAttributes["ancho"]?.Value?.ToString() ?? "950";
            var alto = context.AllAttributes["alto"]?.Value?.ToString() ?? "950";

            var barcodeWriterPixelData = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = int.Parse(alto),
                    Width = int.Parse(ancho),
                    Margin = 0
                }
            };
            var pixelData = barcodeWriterPixelData.Write(contenido);
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            {
                using (var memoriaStream = new MemoryStream())
                {
                    var datosBitmap = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                        System.Drawing.Imaging.ImageLockMode.WriteOnly,
                        System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    // try-catch-finally
                    try
                    {
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, datosBitmap.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(datosBitmap);
                    }
                    bitmap.Save(memoriaStream, System.Drawing.Imaging.ImageFormat.Png);
                    output.TagName = "img";// <img>
                    output.Attributes.Clear();
                    output.Attributes.Add("width", ancho); // <img width="950">
                    output.Attributes.Add("height", alto); // <img width="950" height="950">
                    output.Attributes.Add("src", "data:image/png;base64," + Convert.ToBase64String(memoriaStream.ToArray()));
                }
            }
        }
    }
}
