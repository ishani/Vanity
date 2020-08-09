using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Vanity
{
    abstract class Utils
    {
        // -----------------------------------------------------------------------------------------------------------------
        // http://stackoverflow.com/questions/12416249/hashing-a-string-with-sha256
        public static string sha256( string stringInput )
        {
            SHA256Managed crypt = new SHA256Managed();

            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(stringInput), 0, Encoding.UTF8.GetByteCount(stringInput));
            foreach ( byte bit in crypto )
            {
                hash += bit.ToString( "x2" );
            }

            return hash;
        }

        // -----------------------------------------------------------------------------------------------------------------
        public static string sha256ForFile( string file )
        {
            SHA256Managed crypt = new SHA256Managed();

            using ( FileStream stream = File.OpenRead( file ) )
            {
                byte[] checksum = crypt.ComputeHash(stream);
                return BitConverter.ToString( checksum ).Replace( "-", String.Empty );
            }
        }

        // -----------------------------------------------------------------------------------------------------------------
        public static void jpegOptimFile( string file )
        {
            StringBuilder jpegArgs = new StringBuilder();
            jpegArgs.Append( " --strip-com --strip-exif -p -q " );
            jpegArgs.Append( "\"" );
            jpegArgs.Append( file );
            jpegArgs.Append( "\"" );

            ProcessStartInfo startInfo = new ProcessStartInfo();
            Process p = new Process();

            startInfo.FileName = "jpegoptim64.exe";
            startInfo.Arguments = jpegArgs.ToString();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;

            p.StartInfo = startInfo;
            p.OutputDataReceived += ( sender, args ) => { if ( args.Data != null && args.Data.Length > 0 ) Console.WriteLine( "#> {0}", args.Data ); };

            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
        }

        // -----------------------------------------------------------------------------------------------------------------
        public static Image GenerateThumbnail( Image source, Int32 thumbWidth )
        {
            // figure out thumbnail dimensions given a fixed width
            float imageAspect   = (float)source.Height / (float)source.Width;
            int thumbHeight     = (int)((float)thumbWidth * imageAspect);

            // resize with the best that the framework can give us, quality wise
            var thumbnailImage = new Bitmap(thumbWidth, thumbHeight, PixelFormat.Format24bppRgb);
            using ( var gr = Graphics.FromImage( thumbnailImage ) )
            {
                gr.Clear( Color.Black );

                gr.InterpolationMode  = InterpolationMode.HighQualityBicubic;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.SmoothingMode      = SmoothingMode.HighQuality;
                gr.PixelOffsetMode    = PixelOffsetMode.HighQuality;
                gr.DrawImage( source, new Rectangle( -1, -1, thumbWidth + 2, thumbHeight + 2 ) );
            }

            return thumbnailImage;
        }

        // -----------------------------------------------------------------------------------------------------------------
        public static Image GenerateAlbumThumbnail( Image source, Int32 thumbWidth, Int32 thumbHeight )
        {
            Image resizedToWidth = GenerateThumbnail(source, thumbWidth);

            var sourceCrop = new Rectangle(0, 0, resizedToWidth.Width, resizedToWidth.Height);

            if ( resizedToWidth.Height > thumbHeight )
            {
                Int32 diff = (resizedToWidth.Height - thumbHeight);
                sourceCrop.Y += (diff / 2);
                sourceCrop.Height -= diff;
            }

            // resize with the best that the framework can give us, quality wise
            var thumbnailImage = new Bitmap(thumbWidth, thumbHeight, PixelFormat.Format24bppRgb);
            using ( var gr = Graphics.FromImage( thumbnailImage ) )
            {
                var fullRect = new Rectangle(0, 0, thumbWidth, thumbHeight);

                gr.Clear( Color.Black );

                gr.InterpolationMode  = InterpolationMode.HighQualityBicubic;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.SmoothingMode      = SmoothingMode.HighQuality;
                gr.PixelOffsetMode    = PixelOffsetMode.HighQuality;
                gr.DrawImage( resizedToWidth, fullRect, sourceCrop, GraphicsUnit.Pixel );
            }

            return thumbnailImage;
        }

        // -----------------------------------------------------------------------------------------------------------------
        public static ImageCodecInfo GetEncoder( ImageFormat format )
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach ( ImageCodecInfo codec in codecs )
            {
                if ( codec.FormatID == format.Guid )
                {
                    return codec;
                }
            }
            return null;
        }

        // -----------------------------------------------------------------------------------------------------------------
        public static string RenderEXIFTag( object tagValue )
        {
            // Arrays don't render well without assistance.
            if ( tagValue is Array array )
            {
                // Hex rendering for really big byte arrays (ugly otherwise)
                if ( array.Length > 20 && 
                     array.GetType().GetElementType() == typeof( byte ) )
                {
                    return "0x" + string.Join( "", array.Cast<byte>().Select( x => x.ToString( "X2" ) ).ToArray() );
                }

                return string.Join( ", ", array.Cast<object>().Select( x => x.ToString() ).ToArray() );
            }

            return tagValue.ToString();
        }

        // -----------------------------------------------------------------------------------------------------------------
        public static string PrettifyName( string name )
        {
            string result = name.Replace('-', ' ').Replace('_', ' ');

            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;
            return textInfo.ToTitleCase( result );
        }

    }
}
