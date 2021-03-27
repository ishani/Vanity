using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Vanity
{
    internal static class Settings
    {
        public static string RootURL = "http://photography.ishani.org/";

        public static Int32  AssetReqVersion = (new Random()).Next(9999);
    }

    // -------------------------------------------------------------------------------------------------------------------
    partial class TGalleryPage
    {
        private readonly String mRootURL;
        private readonly String mPageTitle;

        private readonly AlbumFolder mAlbum;
        private readonly String mGalleryRootURL;
        private readonly String mPhotoRootURL;

        private readonly Int32 mVersion;

        public TGalleryPage( AlbumFolder album )
        {
            mRootURL        = Settings.RootURL;
            mPageTitle      = album.mPrettyName;
            mVersion        = Settings.AssetReqVersion;
            mGalleryRootURL = "/";
            mPhotoRootURL   = mGalleryRootURL + "_photo";
            mAlbum          = album;
        }
    }

    // -------------------------------------------------------------------------------------------------------------------
    partial class TAboutPage
    {
        private readonly String mRootURL;
        private readonly String mPageTitle;

        private readonly Int32 mImageCount;
        private readonly Int32 mVersion;

        public TAboutPage( Int32 imageCount )
        {
            mRootURL        = Settings.RootURL;
            mPageTitle      = "About";
            mVersion        = Settings.AssetReqVersion;
            mImageCount     = imageCount;
        }
    }

    // -------------------------------------------------------------------------------------------------------------------
    partial class T404Page
    {
        private readonly String mRootURL;
        private readonly String mPageTitle;

        private readonly Int32 mVersion;

        public T404Page()
        {
            mRootURL        = Settings.RootURL;
            mPageTitle      = "404";
            mVersion        = Settings.AssetReqVersion;
        }
    }

    // -------------------------------------------------------------------------------------------------------------------
    internal class Program
    {
        // all assigned via reflection (see CLA.cs)
        [CommandLineArgumentAttribute("in")]
        static String argPathIn = null;
        [CommandLineArgumentAttribute("assets")]
        static String argAssets = null;
        [CommandLineArgumentAttribute("out")]
        static String argPathOut = null;
        [CommandLineArgumentAttribute("opt")]
        static String argOpts = null;

        private static readonly ZetaProducerHtmlCompressor.HtmlContentCompressor HtmlCompressor = new ZetaProducerHtmlCompressor.HtmlContentCompressor();

        static void Process( AlbumFolder albumFolder, Sitemap sitemap )
        {
            TGalleryPage genPage = new TGalleryPage(albumFolder);

            Console.WriteLine( $" --> {albumFolder.mRelativeRoot}" );

            string outputHTML = genPage.TransformText();
            outputHTML = HtmlCompressor.Compress( outputHTML );

            // create directory structure
            string outputFilename = Path.GetFullPath(argPathOut + "\\" + albumFolder.mRelativeRoot + "\\");
            Directory.CreateDirectory( outputFilename );
            outputFilename += "index.html";

            Console.WriteLine( outputFilename );
            File.WriteAllText( outputFilename, outputHTML );

            sitemap.Add( new Location()
            {
                Url = Settings.RootURL + albumFolder.mRelativeRoot.Replace( "\\", "/" ),
                ChangeFrequency = Location.eChangeFrequency.monthly,
                LastModified = albumFolder.mLastModified
            } );

            foreach ( var subAlbum in albumFolder.mOrderedAlbums )
            {
                Process( subAlbum, sitemap );
            }
        }

        private static void Main( string[] args )
        {
            CLA.Run( typeof( Program ), args );

            if ( argPathIn == null )
            {
                Console.WriteLine( "missing -in argument for album input path" );
                return;
            }
            if ( argAssets == null )
            {
                Console.WriteLine( "missing -assets argument for static assets source path" );
                return;
            }
            if ( argPathOut == null )
            {
                Console.WriteLine( "missing -out argument for build directory" );
                return;
            }

            bool alwaysRebuildThumbnails = false;
            if ( argOpts != null )
            {
                if ( argOpts.Contains( "rebuild" ) )
                {
                    Console.WriteLine( ">>> REBUILDING THUMBNAILS" );
                    alwaysRebuildThumbnails = true;
                }
            }

            String dataInputPath = Path.GetFullPath(argPathIn);

            String photoOutputPath = Path.GetFullPath(argPathOut + "\\_photo\\");
            Console.WriteLine( $"Output: {photoOutputPath}" );

            try
            {
                Console.WriteLine( "Copying static assets..." );

                argAssets = Path.GetFullPath( argAssets );
                Console.WriteLine( $" .. from {argAssets}" );

                // copy static assets over into output directory, verbatim
                Directory.GetFiles( argAssets, "*.*", SearchOption.AllDirectories )
                    .Select( c => new FileInfo( c ) )
                    .ToList()
                    .ForEach( c =>
                    {
                        // get the source file from [argAssets], erase that input path so we are left with just the relative part eg. css/local.css
                        String relPath = c.FullName.Replace(argAssets, "");

                        // form a target path to copy to
                        String copyPath = Path.GetFullPath(argPathOut + "/_assets/" + relPath);

                        // ensure the directory exists
                        Directory.CreateDirectory( Path.GetDirectoryName( copyPath ) );

                        // copy it
                        c.CopyTo( copyPath, true );
                    });


                Console.WriteLine( "Gathering gallery data..." );
                ImageTree imageTree = new ImageTree(dataInputPath, photoOutputPath, alwaysRebuildThumbnails);

                imageTree.mRootAlbum.mName =
                  imageTree.mRootAlbum.mPrettyName = "Home";

                Sitemap gallerySitemap = new Sitemap();

                Process( imageTree.mRootAlbum, gallerySitemap );


                // about page
                {
                    string aboutPathPath = Path.GetFullPath(argPathOut + "\\about.html");
                    TAboutPage aboutPage = new TAboutPage(imageTree.mImageCount);
                    File.WriteAllText( aboutPathPath, HtmlCompressor.Compress( aboutPage.TransformText() ) );
                }

                // 404 page
                {
                    string f404PathPath = Path.GetFullPath(argPathOut + "\\404.html");
                    T404Page f404Page = new T404Page();
                    File.WriteAllText( f404PathPath, HtmlCompressor.Compress( f404Page.TransformText() ) );
                }

                // .htaccess
                {
                    string htAccessPath = Path.GetFullPath(argPathOut + "\\.htaccess");
                    Thtaccess htAccess = new Thtaccess();
                    File.WriteAllText( htAccessPath, htAccess.TransformText() );
                }

                // robots.txt
                {
                    string robotsPath = Path.GetFullPath(argPathOut + "\\robots.txt");
                    string robotsTxt = string.Format(@"
User-agent: *
Allow: /
Sitemap: {0}sitemap.xml", Settings.RootURL);

                    File.WriteAllText( robotsPath, robotsTxt );
                }

                {
                    XmlSerializer xs = new XmlSerializer(typeof(Sitemap), new Type[] { typeof(Location) });

                    string sitemapPath = Path.GetFullPath(argPathOut + "\\sitemap.xml");
                    using ( TextWriter sitemapFile = new StreamWriter( sitemapPath ) )
                    {
                        xs.Serialize( sitemapFile, gallerySitemap );
                    }
                }

            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Error during image gathering : {ex.Message}\n{ex.StackTrace}" );
                return;
            }
        }
    }
}
