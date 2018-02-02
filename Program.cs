using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Vanity
{
    abstract class Settings
    {
        public static string AssetsRootURL = "http://assets.ishani.org/ph3";
    }

    // -------------------------------------------------------------------------------------------------------------------
    partial class TGalleryPage
    {
        private String mPageTitle;

        private AlbumFolder mAlbum;
        private String mAssetsRootURL;
        private String mGalleryRootURL;
        private String mPhotoRootURL;

        private Int32 mVersion;

        public TGalleryPage(AlbumFolder album)
        {
            mPageTitle = album.mPrettyName;

            mVersion = (new Random()).Next(5000);

            mAssetsRootURL = Settings.AssetsRootURL;
            mGalleryRootURL = "/";

            mPhotoRootURL = mGalleryRootURL + "_photo";
            mAlbum = album;
        }
    }

    // -------------------------------------------------------------------------------------------------------------------
    partial class TAboutPage
    {
        private String mPageTitle;

        private String mAssetsRootURL;
        private String mGalleryRootURL;

        private Int32 mImageCount;
        private Int32 mVersion;

        public TAboutPage(Int32 imageCount)
        {
            mPageTitle = "About";

            mVersion = (new Random()).Next(5000);
            mImageCount = imageCount;

            mAssetsRootURL = Settings.AssetsRootURL;
            mGalleryRootURL = "/";
        }
    }

    // -------------------------------------------------------------------------------------------------------------------
    partial class T404Page
    {
        private String mPageTitle;

        private String mAssetsRootURL;
        private String mGalleryRootURL;

        private Int32 mVersion;

        public T404Page()
        {
            mPageTitle = "404";

            mVersion = (new Random()).Next(5000);

            mAssetsRootURL = Settings.AssetsRootURL;
            mGalleryRootURL = "/";
        }
    }

    // -------------------------------------------------------------------------------------------------------------------
    class Program
    {
        [CommandLineArgumentAttribute("in")]
        static String argPathIn = null;
        [CommandLineArgumentAttribute("assets")]
        static String argAssets = null;
        [CommandLineArgumentAttribute("out")]
        static String argPathOut = null;

        static ZetaHtmlCompressor.HtmlContentCompressor HtmlCompressor = new ZetaHtmlCompressor.HtmlContentCompressor();

        static void Process(AlbumFolder albumFolder, Sitemap sitemap)
        {
            TGalleryPage genPage = new TGalleryPage(albumFolder);

            string outputHTML = genPage.TransformText();
            outputHTML = HtmlCompressor.Compress(outputHTML);

            // create directory structure
            string outputFilename = Path.GetFullPath(argPathOut + "\\" + albumFolder.mRelativeRoot + "\\");
            Directory.CreateDirectory(outputFilename);
            outputFilename += "index.html";

            Console.WriteLine(outputFilename);
            File.WriteAllText(outputFilename, outputHTML);

            sitemap.Add(new Location()
            {
                Url = "http://photography.ishani.org/" + albumFolder.mRelativeRoot.Replace("\\", "/"),
                ChangeFrequency = Location.eChangeFrequency.monthly,
                LastModified = albumFolder.mLastModified
            }
            );

            foreach (var subAlbum in albumFolder.mOrderedAlbums)
            {
                Process(subAlbum, sitemap);
            }
        }

        static void Main(string[] args)
        {
            CLA.run(typeof(Program), args);

            if (argPathIn == null)
            {
                Console.WriteLine("missing -in argument for album input path");
                return;
            }
            if (argAssets == null)
            {
                Console.WriteLine("missing -assets argument for static assets source path");
                return;
            }
            if (argPathOut == null)
            {
                Console.WriteLine("missing -out argument for build directory");
                return;
            }


            String dataInputPath = Path.GetFullPath(argPathIn);

            String photoOutputPath = Path.GetFullPath(argPathOut + "\\_photo\\");
            Console.WriteLine("Output: " + photoOutputPath);

            try
            {
                Console.WriteLine("Copying static assets...");
                // copy static assets over into output directory, verbatim
                Directory.GetFiles(argAssets, "*.*", SearchOption.AllDirectories)
                    .Select(c => new FileInfo(c))
                    .ToList()
                    .ForEach(c => {
                        // get the source file from [argAssets], erase that input path so we are left with just the relative part eg. css/local.css
                        String relPath = c.FullName.Replace(argAssets, "");

                        // form a target path to copy to
                        String copyPath = Path.GetFullPath(argPathOut + "/_assets/" + relPath);

                        // ensure the directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(copyPath));

                        // copy it
                        c.CopyTo(copyPath, true);
                        }
                    );


                Console.WriteLine("Gathering gallery data...");
                ImageTree imageTree = new ImageTree(dataInputPath, photoOutputPath);

                imageTree.mRootAlbum.mName =
                  imageTree.mRootAlbum.mPrettyName = "Home";

                Sitemap gallerySitemap = new Sitemap();

                Process(imageTree.mRootAlbum, gallerySitemap);


                // about page
                {
                    string aboutPathPath = Path.GetFullPath(argPathOut + "\\about.html");
                    TAboutPage aboutPage = new TAboutPage(imageTree.mImageCount);
                    File.WriteAllText(aboutPathPath, HtmlCompressor.Compress(aboutPage.TransformText()));
                }

                // 404 page
                {
                    string f404PathPath = Path.GetFullPath(argPathOut + "\\404.html");
                    T404Page f404Page = new T404Page();
                    File.WriteAllText(f404PathPath, HtmlCompressor.Compress(f404Page.TransformText()));
                }

                // .htaccess
                {
                    string htAccessPath = Path.GetFullPath(argPathOut + "\\.htaccess");
                    Thtaccess htAccess = new Thtaccess();
                    File.WriteAllText(htAccessPath, htAccess.TransformText());
                }

                // robots.txt
                {
                    string robotsPath = Path.GetFullPath(argPathOut + "\\robots.txt");
                    string robotsTxt = @"
User-agent: *
Allow: /
Sitemap: http://photography.ishani.org/sitemap.xml";

                    File.WriteAllText(robotsPath, robotsTxt);
                }

                {
                    XmlSerializer xs = new XmlSerializer(typeof(Sitemap), new Type[] { typeof(Location) });

                    string sitemapPath = Path.GetFullPath(argPathOut + "\\sitemap.xml");
                    using (TextWriter sitemapFile = new StreamWriter(sitemapPath))
                    {
                        xs.Serialize(sitemapFile, gallerySitemap);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during image gathering : " + ex.Message);
                return;
            }
        }
    }
}
