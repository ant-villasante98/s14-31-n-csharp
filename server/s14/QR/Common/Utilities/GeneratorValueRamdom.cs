using System.Security.Cryptography;
using System.Text.Json;
using QRCoder;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace S14.QR.Commmon.Utilities;
public static class QrStringGenerator
{
    public static string GenerateValue()
    {
        var randomNumber = new byte[8];

        using var generator = RandomNumberGenerator.Create();

        generator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    public static string GenerateQrString<T>(T obj)
    where T : class
    {
        var objBytes = ToByte<T>(obj);
        if (objBytes is null)
        {
            throw new NullReferenceException();
        }

        string stringValue = Convert.ToBase64String(objBytes);
        return stringValue;
    }

    public static T GetValue<T>(string value)
    where T : class
    {
        var objBytes = Convert.FromBase64String(value);
        var obj = FromByte<T>(objBytes);
        if (obj is null)
        {
            throw new NullReferenceException();
        }

        return obj;
    }

    public static string GenerateSvg(string value)
    {
        var barcodeWriter = new BarcodeWriterSvg()
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Width = 200,
                Height = 300,
                PureBarcode = true
            },
            Renderer = new SvgRenderer
            {
                Foreground = SvgRenderer.Color.Black
            }
        };
        var svgImage = barcodeWriter.Write(value);
        var svgContent = svgImage.Content;
        var startIndex = svgContent.IndexOf("<svg");
        if (startIndex >= 0)
        {
            var endIndex = svgContent.LastIndexOf("</svg>");
            if (endIndex >= 0)
            {
                return svgContent.Substring(startIndex, endIndex - startIndex + 6);
            }
        }
        
        return svgContent;
    }

    private static byte[] ToByte<T>(T value)
    where T : class
    {
        return JsonSerializer.SerializeToUtf8Bytes(value);
    }

    private static T? FromByte<T>(byte[] value)
    where T : class
    {
        return JsonSerializer.Deserialize<T>(value);
    }
}