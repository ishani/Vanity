using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Vanity
{
    [Serializable]
    internal class SettingsFromDisk
    {
        static readonly Lazy<SettingsFromDisk> instanceHolder = new Lazy<SettingsFromDisk>(() => LoadSettings());
        public static SettingsFromDisk Instance => instanceHolder.Value;

        private static SettingsFromDisk LoadSettings()
        {
            try
            {
                string fileName = "VanitySettings.json";
                if ( File.Exists( fileName ) )
                {
                    Console.WriteLine( "Loading site settings from VanitySettings.json ..." );

                    string jsonString = File.ReadAllText(fileName);
                    var fromDisk = JsonConvert.DeserializeObject<SettingsFromDisk>( jsonString );

                    Console.WriteLine( $"RootURL        : {fromDisk.RootURL}" );
                    Console.WriteLine( $"GalleryName    : {fromDisk.GalleryName}" );
                    Console.WriteLine( $"GalleryOwner   : {fromDisk.GalleryOwner}" );
                    return fromDisk;
                }
                else
                {
                    Console.WriteLine( "No VanitySettings.json found, using defaults" );
                    return new SettingsFromDisk();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( "Error - failed to read VanitySettings.json, using defaults" );
                Console.WriteLine( ex.Message );
                return new SettingsFromDisk();
            }
        }

        SettingsFromDisk()
        {
        }

        public string RootURL { get; set; }         = "http://photography.ishani.org/";
        public string GalleryName { get; set; }     = "Ishani's Gallery";
        public string GalleryOwner { get; set; }    = "Harry Denholm";
        public string GoogleUATag { get; set; }     = "UA-17765969-6";
        public string CustomAboutText { get; set; } = "";
    }

    internal static class Settings
    {
        public static Int32  AssetReqVersion = (new Random()).Next(9999);
    }

    // -------------------------------------------------------------------------------------------------------------------
    partial class TGalleryPage
    {
        private readonly String mRootURL;
        private readonly String mPageTitle;
        private readonly String mGalleryName;
        private readonly String mGalleryOwner;
        private readonly String mGoogleUATag;

        private readonly AlbumFolder mAlbum;
        private readonly String mGalleryRootURL;
        private readonly String mPhotoRootURL;

        private readonly Int32 mVersion;

        public TGalleryPage( AlbumFolder album )
        {
            mRootURL        = SettingsFromDisk.Instance.RootURL;
            mGalleryName    = SettingsFromDisk.Instance.GalleryName;
            mGalleryOwner   = SettingsFromDisk.Instance.GalleryOwner;
            mGoogleUATag    = SettingsFromDisk.Instance.GoogleUATag;
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
        private readonly String mGalleryName;
        private readonly String mGalleryOwner;
        private readonly String mGoogleUATag;

        private readonly String mCustomAboutText;

        private readonly Int32 mImageCount;
        private readonly Int32 mVersion;

        public TAboutPage( Int32 imageCount )
        {
            mRootURL        = SettingsFromDisk.Instance.RootURL;
            mGalleryName    = SettingsFromDisk.Instance.GalleryName;
            mGalleryOwner   = SettingsFromDisk.Instance.GalleryOwner;
            mGoogleUATag    = SettingsFromDisk.Instance.GoogleUATag;
            mCustomAboutText = SettingsFromDisk.Instance.CustomAboutText;
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
        private readonly String mGalleryName;
        private readonly String mGalleryOwner;
        private readonly String mGoogleUATag;

        private readonly Int32 mVersion;

        public T404Page()
        {
            mRootURL        = SettingsFromDisk.Instance.RootURL;
            mGalleryName    = SettingsFromDisk.Instance.GalleryName;
            mGalleryOwner   = SettingsFromDisk.Instance.GalleryOwner;
            mGoogleUATag    = SettingsFromDisk.Instance.GoogleUATag;
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
                Url = SettingsFromDisk.Instance.RootURL + albumFolder.mRelativeRoot.Replace( "\\", "/" ),
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
            Console.WriteLine( "----------- Vanity Gallery Site Generation -----------" );

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
Sitemap: {0}sitemap.xml", SettingsFromDisk.Instance.RootURL);

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
