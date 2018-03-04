using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace Vanity
{
    // -------------------------------------------------------------------------------------------------------------------
    public class Photograph
    {
        public FileInfo mFI;
        public String mPrettyName;
        public AlbumFolder mDir;
        public String mRelativePath;
        public String mHashedPath;

        public Int32 mImageWidth,
                      mImageHeight;

        public Int32 mThumbWidth,
                      mThumbHeight;
    }

    // -------------------------------------------------------------------------------------------------------------------
    public class AlbumFolder
    {
        public AlbumFolder mParentAlbum = null;

        public String mRelativeRoot = String.Empty;
        public String mRelativeRootHTML = String.Empty;

        public String mName = String.Empty;
        public String mPrettyName = String.Empty;
        public String mPrettyNameWithYear = String.Empty;

        public String mGfyCatIntro = String.Empty;

        public String mMetadataJSON = String.Empty;
        public dynamic mMetadata = null;

        public String mMetadataDescription = String.Empty;
        public String mMetadataRep = String.Empty;

        public String mHashedRep = String.Empty;
        public Int32 mAlbumThumbWidth = 0;
        public Int32 mAlbumThumbHeight = 0;

        public String mCamera = String.Empty;
        public Int32 mYear = 0;

        public List<Photograph> mPhotos = new List<Photograph>();
        public Dictionary<String, AlbumFolder> mSubAlbums = new Dictionary<string, AlbumFolder>(16);

        public List<AlbumFolder> mOrderedAlbums = null;

        public DateTime? mLastModified = null;
    }

    // -------------------------------------------------------------------------------------------------------------------
    public class ImageTree
    {
        public enum Constants
        {
            ThumbnailWidth = 520,
            AlbumThumbnailHeight = 390
        };

        public AlbumFolder mRootAlbum { get; private set; }
        public String mBasePath { get; private set; }

        public String mPhotoOutputRoot { get; private set; }

        public String mPhotoOutputFull { get; private set; }
        public String mPhotoOutputThumb { get; private set; }
        public String mPhotoOutputAlbumThumb { get; private set; }

        Dictionary<string, string> mUniqueHashCheck = new Dictionary<string, string>(1024);

        ImageCodecInfo mJPEGEncoder;
        EncoderParameters mJPEGEncoderParameters;

        public Int32 mImageCount = 0;

        // -----------------------------------------------------------------------------------------------------------------
        public ImageTree(String basePath, String photoOutputPath, bool alwaysRebuildThumbnails)
        {
            mBasePath = basePath;
            {
                mPhotoOutputRoot = photoOutputPath;

                mPhotoOutputFull = Path.GetFullPath(mPhotoOutputRoot + "\\full\\");
                Directory.CreateDirectory(mPhotoOutputFull);

                mPhotoOutputThumb = Path.GetFullPath(mPhotoOutputRoot + "\\thumb\\");
                Directory.CreateDirectory(mPhotoOutputThumb);

                mPhotoOutputAlbumThumb = Path.GetFullPath(mPhotoOutputRoot + "\\album\\");
                Directory.CreateDirectory(mPhotoOutputAlbumThumb);
            }

            {
                mJPEGEncoder = Utils.GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                mJPEGEncoderParameters = new EncoderParameters(3);
                mJPEGEncoderParameters.Param[0] = new EncoderParameter(myEncoder, 80L);
                mJPEGEncoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.ScanMethod, (int)EncoderValue.ScanMethodInterlaced);
                mJPEGEncoderParameters.Param[2] = new EncoderParameter(System.Drawing.Imaging.Encoder.RenderMethod, (int)EncoderValue.RenderProgressive);

            }

            mRootAlbum = null;

            WalkDirectoryTree(basePath, ref mImageCount, alwaysRebuildThumbnails);

            Console.WriteLine("Images Gathered: " + mImageCount);
        }

        // -----------------------------------------------------------------------------------------------------------------
        void WalkDirectoryTree(String root, ref Int32 mImageCount, bool alwaysRebuildThumbnails)
        {
            char[] pathSplits = new char[] { '\\', '/' };

            String originalRoot = root;
            String relativeRoot = root.Remove(0, mBasePath.Length).TrimStart(pathSplits);

            Console.WriteLine(">> " + relativeRoot);

            AlbumFolder currentAlbum = mRootAlbum;

            String[] pathBits = relativeRoot.Split(pathSplits);
            foreach (String pathBit in pathBits)
            {
                AlbumFolder newAlbumFolder = null;

                if (currentAlbum != null &&
                    currentAlbum.mSubAlbums.ContainsKey(pathBit))
                {
                    newAlbumFolder = currentAlbum.mSubAlbums[pathBit];
                }
                else
                {
                    newAlbumFolder = new AlbumFolder();
                    newAlbumFolder.mParentAlbum = currentAlbum;
                    newAlbumFolder.mRelativeRoot = relativeRoot;
                    newAlbumFolder.mRelativeRootHTML = newAlbumFolder.mRelativeRoot.Replace("\\", "/");
                    newAlbumFolder.mName = pathBit;
                    newAlbumFolder.mPrettyName = Utils.PrettifyName(newAlbumFolder.mName);

                    String metadataPath = originalRoot + "\\metadata.json";
                    if (File.Exists(metadataPath))
                    {
                        newAlbumFolder.mMetadataJSON = File.ReadAllText(metadataPath);
                        newAlbumFolder.mMetadata = Newtonsoft.Json.JsonConvert.DeserializeObject(newAlbumFolder.mMetadataJSON);

                        try { newAlbumFolder.mMetadataDescription = newAlbumFolder.mMetadata.desc; } catch (Exception) { }
                        try { newAlbumFolder.mMetadataRep = newAlbumFolder.mMetadata.rep; } catch (Exception) { }
                        try { if (newAlbumFolder.mMetadata.name != null) newAlbumFolder.mPrettyName = newAlbumFolder.mMetadata.name; } catch (Exception) { }
                        try { if (newAlbumFolder.mMetadata.cam != null) newAlbumFolder.mCamera = newAlbumFolder.mMetadata.cam; } catch (Exception) { }
                        try { if (newAlbumFolder.mMetadata.year != null) newAlbumFolder.mYear = newAlbumFolder.mMetadata.year; } catch (Exception) { }
                        try { if (newAlbumFolder.mMetadata.gfycat != null) newAlbumFolder.mGfyCatIntro = newAlbumFolder.mMetadata.gfycat; } catch (Exception) { }
                    }

                    bool buildPrettyWithYear = true;

                    // inherit Year and Camera from parent?
                    if (newAlbumFolder.mParentAlbum != null)
                    {
                        if (newAlbumFolder.mYear == 0 && newAlbumFolder.mParentAlbum.mYear > 0)
                        {
                            newAlbumFolder.mYear = newAlbumFolder.mParentAlbum.mYear;
                            buildPrettyWithYear = false;
                        }
                        if (newAlbumFolder.mCamera.Length == 0 && newAlbumFolder.mParentAlbum.mCamera.Length > 0)
                        {
                            newAlbumFolder.mCamera = newAlbumFolder.mParentAlbum.mCamera;
                        }
                    }


                    newAlbumFolder.mPrettyNameWithYear = newAlbumFolder.mPrettyName;
                    if (newAlbumFolder.mYear > 0 && buildPrettyWithYear)
                    {
                        newAlbumFolder.mPrettyNameWithYear = string.Format("{0} {1}", newAlbumFolder.mPrettyName, newAlbumFolder.mYear);
                    }

                    if (newAlbumFolder.mMetadataRep == null || newAlbumFolder.mMetadataRep.Length == 0)
                    {
                        DirectoryInfo findFirstJpg = new DirectoryInfo(originalRoot);

                        var fileList = findFirstJpg.GetFiles("*.jpg");
                        if (fileList.Length > 0)
                            newAlbumFolder.mMetadataRep = Path.GetFileNameWithoutExtension(fileList[0].FullName);
                    }
                    if (newAlbumFolder.mMetadataDescription == null)
                    {
                        newAlbumFolder.mMetadataDescription = "";
                    }

                    // generate album thumbnail
                    if (newAlbumFolder.mMetadataRep != null && newAlbumFolder.mMetadataRep.Length != 0)
                    {
                        String repImagePath = originalRoot + "\\" + newAlbumFolder.mMetadataRep + ".jpg";

                        if (!File.Exists(repImagePath))
                            throw new FileNotFoundException("Cannot find representative image: " + repImagePath);

                        newAlbumFolder.mAlbumThumbWidth = (Int32)Constants.ThumbnailWidth;
                        newAlbumFolder.mAlbumThumbHeight = (Int32)Constants.AlbumThumbnailHeight;

                        Image repImage = Image.FromFile(repImagePath);
                        Image repImageThumb = Utils.GenerateAlbumThumbnail(repImage, newAlbumFolder.mAlbumThumbWidth, newAlbumFolder.mAlbumThumbHeight);

                        newAlbumFolder.mHashedRep = Utils.sha256(relativeRoot).Substring(0, 10).ToLower();

                        String outAlbumThumbPath = mPhotoOutputAlbumThumb + newAlbumFolder.mHashedRep + ".jpg";

                        bool generateNewThumbnail = true;
                        if (File.Exists(outAlbumThumbPath))
                        {
                            String shaTestTemp = mPhotoOutputAlbumThumb + newAlbumFolder.mHashedRep + "_temp_.jpg";
                            repImageThumb.Save(shaTestTemp, mJPEGEncoder, mJPEGEncoderParameters);

                            Utils.jpegOptimFile(shaTestTemp);

                            String sha1 = Utils.sha256ForFile(shaTestTemp);
                            String sha2 = Utils.sha256ForFile(outAlbumThumbPath);

                            if (sha1 == sha2)
                            {
                                generateNewThumbnail = false;
                            }

                            File.Delete(shaTestTemp);
                        }

                        if (generateNewThumbnail || alwaysRebuildThumbnails)
                        {
                            Console.WriteLine(" ~ generating new album thumbnail");
                            repImageThumb.Save(outAlbumThumbPath, mJPEGEncoder, mJPEGEncoderParameters);

                            Utils.jpegOptimFile(outAlbumThumbPath);
                        }
                    }


                    if (newAlbumFolder.mParentAlbum == null)
                    {
                        mRootAlbum = newAlbumFolder;
                    }
                    if (currentAlbum != null)
                    {
                        currentAlbum.mSubAlbums.Add(pathBit, newAlbumFolder);
                    }
                }

                currentAlbum = newAlbumFolder;
            }


            FileInfo[] files = null;
            DirectoryInfo thisDir = new DirectoryInfo(root);
            DirectoryInfo[] subDirs = thisDir.GetDirectories();

            try
            {
                files = thisDir.GetFiles("*.jpg");
            }
            catch (Exception e)
            {
                Console.WriteLine("WalkDirectory Error - " + e.Message);
            }

            if (files != null)
            {
                bool shouldLineBreak = false;

                foreach (FileInfo fi in files)
                {
                    // steal the nearest file's modified time for the album, used in sitemap gen
                    if (currentAlbum.mLastModified == null)
                    {
                        currentAlbum.mLastModified = fi.LastWriteTime;
                    }
                    else
                    {
                        if (DateTime.Compare(currentAlbum.mLastModified.GetValueOrDefault(), fi.LastWriteTime) < 0)
                        {
                            currentAlbum.mLastModified = fi.LastWriteTime;
                        }
                    }

                    Photograph imgInfo = new Photograph();
                    imgInfo.mFI = fi;
                    imgInfo.mDir = currentAlbum;

                    imgInfo.mPrettyName = Utils.PrettifyName(Path.GetFileNameWithoutExtension(fi.FullName));

                    imgInfo.mRelativePath = fi.FullName.Remove(0, mBasePath.Length).TrimStart(pathSplits);
                    imgInfo.mHashedPath = Utils.sha256(imgInfo.mRelativePath).Substring(0, 10).ToLower();

                    // keep track of any duplicates
                    if (mUniqueHashCheck.ContainsKey(imgInfo.mHashedPath))
                    {
                        throw new Exception("Duplicate SHA found! " + imgInfo.mRelativePath + " -- " + mUniqueHashCheck[imgInfo.mHashedPath]);
                    }
                    mUniqueHashCheck.Add(imgInfo.mHashedPath, imgInfo.mRelativePath);


                    String outFullPath = mPhotoOutputFull + imgInfo.mHashedPath + ".jpg";
                    String outThumbPath = mPhotoOutputThumb + imgInfo.mHashedPath + ".jpg";

                    Image originalImageData = Image.FromFile(fi.FullName);
                    imgInfo.mImageWidth = originalImageData.Width;
                    imgInfo.mImageHeight = originalImageData.Height;

                    bool doProcessImage = true;

                    // check if the file lenth/time is different, otherwise don't re-copy
                    if (File.Exists(outFullPath))
                    {
                        FileInfo destFi = new FileInfo(outFullPath);
                        if (destFi.Length == fi.Length &&
                            destFi.LastWriteTime == fi.LastWriteTime)
                        {
                            doProcessImage = false;
                        }
                    }

                    if (doProcessImage)
                    {
                        File.Copy(fi.FullName, outFullPath, true);
                        Console.Write(".");
                        shouldLineBreak = true;
                    }

                    // regenerate thumbnail?
                    if ( doProcessImage || !File.Exists(outThumbPath) || alwaysRebuildThumbnails)
                    {
                        using (Image thumbImageData = Utils.GenerateThumbnail(originalImageData, (Int32)Constants.ThumbnailWidth))
                            thumbImageData.Save(outThumbPath, mJPEGEncoder, mJPEGEncoderParameters);                        

                        Utils.jpegOptimFile(outThumbPath);
                    }

                    originalImageData.Dispose();

                    using (Image thumbSizeLoad = Image.FromFile(outThumbPath))
                    {
                        imgInfo.mThumbWidth = thumbSizeLoad.Width;
                        imgInfo.mThumbHeight = thumbSizeLoad.Height;
                    }

                    currentAlbum.mPhotos.Add(imgInfo);
                    mImageCount++;
                }

                if (shouldLineBreak)
                    Console.WriteLine();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo.FullName, ref mImageCount, alwaysRebuildThumbnails);
                }

                if (currentAlbum.mOrderedAlbums == null)
                {
                    var albumList = new List<AlbumFolder>();
                    foreach (var pair in currentAlbum.mSubAlbums)
                    {
                        albumList.Add(pair.Value);
                    }

                    try
                    {
                        if (currentAlbum.mMetadata.order is Newtonsoft.Json.Linq.JArray)
                        {
                            Console.WriteLine("    Custom Order: ");
                            var subAlbumList = new Dictionary<String, AlbumFolder>(currentAlbum.mSubAlbums);

                            albumList.Clear();
                            foreach (var pair in currentAlbum.mMetadata.order)
                            {
                                String albumName = pair.ToString();
                                Console.WriteLine("     - " + albumName);

                                if ( !subAlbumList.ContainsKey(albumName) )
                                {
                                    Console.WriteLine("Error: cannot find specified album at this level: " + albumName);
                                }

                                albumList.Add(subAlbumList[albumName]);
                                subAlbumList.Remove(albumName);
                            }

                            foreach (var pair in subAlbumList)
                            {
                                albumList.Add(pair.Value);
                            }
                        }
                    }
                    catch (KeyNotFoundException knfe)
                    {
                        Console.WriteLine(Environment.NewLine + knfe.Message + Environment.NewLine + knfe.StackTrace );
                        Environment.Exit(-1);
                    }
                    catch (Exception)
                    {

                    }

                    currentAlbum.mOrderedAlbums = albumList;
                }

            }
        }
    }
}
