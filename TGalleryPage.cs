﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Vanity
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "F:\Dev\Github\Vanity\TGalleryPage.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class TGalleryPage : TGalleryPageBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write(@"<!DOCTYPE html>
<!-- generated by Vanity -->
<html lang=""en"">
    <head>
        <!-- Global site tag (gtag.js) - Google Analytics -->
        <script async src=""https://www.googletagmanager.com/gtag/js?id=UA-17765969-6""></script>
        <script>
          window.dataLayer = window.dataLayer || [];
          function gtag(){dataLayer.push(arguments);}
          gtag('js', new Date());
          gtag('config', 'UA-17765969-6');
        </script>

        <!-- metadata -->
        <meta charset=""utf-8"">

        <meta http-equiv=""content-type"" content=""text/html; charset=utf-8""/>
        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1""/>

        <meta name=""viewport"" content=""width=device-width, minimum-scale=1, maximum-scale=1""/>
        <meta name=""twitter:card"" content=""summary"">
        <meta name=""og:type"" content=""website"" />
        <meta name=""og:title"" content=""Photography by Harry Denholm - ");
            
            #line 23 "F:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mPageTitle));
            
            #line default
            #line hidden
            this.Write("\" />\r\n\r\n        <title>Ishani\'s Gallery &middot; ");
            
            #line 25 "F:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mPageTitle));
            
            #line default
            #line hidden
            this.Write(@"</title>

        <!-- bootstrap 4 -->
        <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"" integrity=""sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z"" crossorigin=""anonymous"">

        <!-- font awesome 5 -->
        <script defer src=""https://use.fontawesome.com/releases/v5.8.1/js/all.js"" integrity=""sha384-g5uSoOSBd7KkhAMlnQILrecXvzst9TdC09/VM+pjDTCM+1il8RHz5fKANTFFb+gQ"" crossorigin=""anonymous""></script>

        <!-- fonts -->
        <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Open+Sans:300i,400|Abel"">

        <!-- photoswipe CSS -->
        <link rel=""stylesheet"" type=""text/css"" href=""/_assets/photoswipe/css/photoswipe.all.min.css?v=");
            
            #line 37 "F:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mVersion));
            
            #line default
            #line hidden
            this.Write("\">\r\n\r\n        <!-- local CSS -->\r\n        <link rel=\"stylesheet\" type=\"text/css\" " +
                    "href=\"/_assets/css/local.css?v=");
            
            #line 40 "F:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mVersion));
            
            #line default
            #line hidden
            this.Write("\">\r\n\r\n    </head>\r\n<body>\r\n");
            this.Write("\r\n\r\n ");
            
            #line 9 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 Boolean isHomePage = mAlbum.mParentAlbum == null; 
            
            #line default
            #line hidden
            this.Write("\r\n\r\n        <div class=\"container\">\r\n\r\n            <div class=\"page-top text-cent" +
                    "er\">\r\n\r\n                <!-- minimalist navbar -->\r\n                <div class=\"" +
                    "row\">\r\n\r\n                     ");
            
            #line 19 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 if (isHomePage) { 
            
            #line default
            #line hidden
            this.Write("                        <div class=\"col text-muted\">\r\n                        <i " +
                    "class=\"fas fa-home\"></i> Home\r\n                    ");
            
            #line 22 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write(" \r\n                        <div class=\"col\">\r\n                        <a href=\"/\"" +
                    "><i class=\"fas fa-home\"></i> Home</a>\r\n                    ");
            
            #line 25 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@" 

                    </div>
                    <div class=""col-6"">
                    </div>
                    <div class=""col"">
                        <a href=""/about.html""><i class=""fas fa-question-circle"" style=""margin-left: 2.5px;""></i> About</a>
                    </div>
                </div>

                <br>

                <!-- album titles, parents, descriptions, tags -->

                ");
            
            #line 39 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 List<AlbumFolder> parentAlbums = new List<AlbumFolder>();
                   AlbumFolder currentAlbum = mAlbum.mParentAlbum; 
                   while (currentAlbum != null) 
                   {
                        if ( currentAlbum.mParentAlbum != null )
                            parentAlbums.Add(currentAlbum);

                        currentAlbum = currentAlbum.mParentAlbum;
                   }
                   parentAlbums.Reverse();

                   Int32 numParents = parentAlbums.Count();

                   if (numParents > 0) { 
            
            #line default
            #line hidden
            this.Write("                   <div class=\"page-title text-uppercase text-light page-title-pa" +
                    "rent\">\r\n                   ");
            
            #line 54 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } 

                   for (Int32 i=0; i<numParents; i++)
                   {
                   var cur = parentAlbums[i]; 
            
            #line default
            #line hidden
            this.Write("\r\n                   · <a href=\"");
            
            #line 60 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mGalleryRootURL));
            
            #line default
            #line hidden
            
            #line 60 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cur.mRelativeRootHTML));
            
            #line default
            #line hidden
            this.Write("\">");
            
            #line 60 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cur.mPrettyName));
            
            #line default
            #line hidden
            this.Write("</a>\r\n\r\n                   ");
            
            #line 62 "F:\Dev\Github\Vanity\TGalleryPage.tt"
}


                   if (numParents > 0) { 
            
            #line default
            #line hidden
            this.Write("                    · </div>\r\n                   ");
            
            #line 67 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n                ");
            
            #line 69 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 if (isHomePage) { 
            
            #line default
            #line hidden
            this.Write(@"                    <div class=""page-title text-uppercase text-info"">
                        Ishani <span class=""d-none d-sm-inline"">·</span> Gallery
                    </div>                
                    <i>Photography by Harry Denholm. All images <a target=""_blank"" rel=""license"" href=""http://creativecommons.org/licenses/by-nc-nd/4.0/"">CC-BY-NC-ND</a>.</i>
                ");
            
            #line 74 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write(" \r\n                    <div class=\"page-title text-uppercase text-warning\">\r\n    " +
                    "                    ");
            
            #line 76 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mAlbum.mPrettyName));
            
            #line default
            #line hidden
            this.Write("\r\n                    </div>\r\n                ");
            
            #line 78 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } 
            
            #line default
            #line hidden
            this.Write(" \r\n\r\n                ");
            
            #line 80 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 if ( mAlbum.mMetadataDescription.Length > 0 ) { 
            
            #line default
            #line hidden
            this.Write(" <div class=\"album-subdesc\"><i>");
            
            #line 80 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mAlbum.mMetadataDescription));
            
            #line default
            #line hidden
            this.Write("</i></div> ");
            
            #line 80 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n                ");
            
            #line 82 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 if ( mAlbum.mYear > 0 ) { 
            
            #line default
            #line hidden
            this.Write(" <span class=\"badge badge-light\">");
            
            #line 82 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mAlbum.mYear));
            
            #line default
            #line hidden
            this.Write("</span> ");
            
            #line 82 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } 
            
            #line default
            #line hidden
            this.Write("                ");
            
            #line 83 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 if ( !string.IsNullOrEmpty( mAlbum.mCamera ) ) { 
            
            #line default
            #line hidden
            this.Write(" <span class=\"badge badge-light\">");
            
            #line 83 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mAlbum.mCamera));
            
            #line default
            #line hidden
            this.Write("</span> ");
            
            #line 83 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\r\n            </div>\r\n\r\n");
            
            #line 88 "F:\Dev\Github\Vanity\TGalleryPage.tt"

    Int32 albumCount = mAlbum.mOrderedAlbums.Count();
    Boolean shouldPad = albumCount < 4 && (albumCount % 4 ) != 0;

    if (albumCount > 0 ) { 
            
            #line default
            #line hidden
            this.Write("\r\n            <!-- sub-albums -->\r\n            <div class=\"row pinched-row\"> \r\n  " +
                    "          \r\n                ");
            
            #line 97 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 if (shouldPad) { 
            
            #line default
            #line hidden
            this.Write(" <div class=\"col-lg\"></div> ");
            
            #line 97 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 99 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 foreach (var subAlbum in mAlbum.mOrderedAlbums) { 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 101 "F:\Dev\Github\Vanity\TGalleryPage.tt"
     if ( subAlbum.HasPhotosOrSubAlbums() ) { 
            
            #line default
            #line hidden
            this.Write("\r\n                <div class=\"col-md-6 col-lg-3\">\r\n                    <div class" +
                    "=\"card pic-card album-card\">\r\n                        <a href=\"");
            
            #line 105 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mGalleryRootURL));
            
            #line default
            #line hidden
            
            #line 105 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(subAlbum.mRelativeRootHTML));
            
            #line default
            #line hidden
            this.Write("\" itemprop=\"contentUrl\" style=\"height:100%\">\r\n                            <img cl" +
                    "ass=\"card-img-top card-img-in-album\" \r\n                                src=\"");
            
            #line 107 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mPhotoRootURL));
            
            #line default
            #line hidden
            this.Write("/album/");
            
            #line 107 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(subAlbum.mHashedRep));
            
            #line default
            #line hidden
            this.Write(".jpg\" \r\n                                alt=\"");
            
            #line 108 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(subAlbum.mPrettyNameWithYear));
            
            #line default
            #line hidden
            this.Write("\" \r\n                                itemprop=\"thumbnail\">\r\n                      " +
                    "  </a>\r\n                        <div class=\"album-footer\">\r\n                    " +
                    "        <i class=\"fas fa-images\"></i> ");
            
            #line 112 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(subAlbum.mPrettyNameWithYear));
            
            #line default
            #line hidden
            this.Write("\r\n                        </div>\r\n                    </div>\r\n                </d" +
                    "iv>\r\n\r\n");
            
            #line 117 "F:\Dev\Github\Vanity\TGalleryPage.tt"
     } // end of if-has-photos 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 119 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } // end of foreach  
            
            #line default
            #line hidden
            this.Write("\r\n                ");
            
            #line 121 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 if (shouldPad) { 
            
            #line default
            #line hidden
            this.Write(" <div class=\"col-lg\"></div> ");
            
            #line 121 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n                <div class=\"col-12 text-center text-muted\" style=\"font-size: 2." +
                    "0rem\"> • • • </div>\r\n            </div>\r\n\r\n");
            
            #line 126 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } // end of album conditional  
            
            #line default
            #line hidden
            this.Write("\r\n\r\n    ");
            
            #line 129 "F:\Dev\Github\Vanity\TGalleryPage.tt"
	String gfyCat = mAlbum.mGfyCatIntro;
        if ( !string.IsNullOrEmpty(gfyCat) ) { 
            
            #line default
            #line hidden
            this.Write("            <div class=\'gfydiv\'>\r\n            <div style=\'position:relative;paddi" +
                    "ng-bottom:54%\'><iframe src=\'https://gfycat.com/ifr/search/");
            
            #line 132 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(gfyCat));
            
            #line default
            #line hidden
            this.Write("?hd=1\' frameborder=\'0\' scrolling=\'no\' width=\'100%\' height=\'100%\' style=\'position:" +
                    "absolute;top:0;left:0\' allowfullscreen></iframe></div>\r\n            </div>\r\n    " +
                    "");
            
            #line 134 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\r\n            <div class=\"card-columns\">\r\n                <div class=\"my-galler" +
                    "y\" itemscope itemtype=\"http://schema.org/ImageGallery\">\r\n\r\n");
            
            #line 140 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 foreach (Photograph item in mAlbum.mPhotos) { 
            
            #line default
            #line hidden
            this.Write("\r\n                    <div class=\"card pic-card\">\r\n                        <a hre" +
                    "f=\"");
            
            #line 143 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mPhotoRootURL));
            
            #line default
            #line hidden
            this.Write("/full/");
            
            #line 143 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.mHashedPath));
            
            #line default
            #line hidden
            this.Write(".jpg\" itemprop=\"contentUrl\" data-size=\"");
            
            #line 143 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.mImageWidth));
            
            #line default
            #line hidden
            this.Write("x");
            
            #line 143 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.mImageHeight));
            
            #line default
            #line hidden
            this.Write("\">\r\n                            <img class=\"card-img-top\" src=\"");
            
            #line 144 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mPhotoRootURL));
            
            #line default
            #line hidden
            this.Write("/thumb/");
            
            #line 144 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.mHashedPath));
            
            #line default
            #line hidden
            this.Write(".jpg\" alt=\"");
            
            #line 144 "F:\Dev\Github\Vanity\TGalleryPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.mPrettyName));
            
            #line default
            #line hidden
            this.Write("\" itemprop=\"thumbnail\">\r\n                        </a>\r\n                    </div>" +
                    "\r\n\r\n");
            
            #line 148 "F:\Dev\Github\Vanity\TGalleryPage.tt"
 } // end of foreach  
            
            #line default
            #line hidden
            this.Write("\r\n\r\n                </div>\r\n            </div>\r\n\r\n\r\n         </div>\r\n\r\n");
            this.Write("<!-- bootstrap -->\r\n<script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js" +
                    "\" integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6" +
                    "jizo\" crossorigin=\"anonymous\"></script>\r\n<script src=\"https://stackpath.bootstra" +
                    "pcdn.com/bootstrap/4.5.2/js/bootstrap.min.js\" integrity=\"sha384-B4gt1jrGC7Jh4AgT" +
                    "PSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV\" crossorigin=\"anonymous\"></scri" +
                    "pt>\r\n\r\n<!-- photoswipe JS -->\r\n<script src=\"/_assets/photoswipe/js/photoswipe.al" +
                    "l.min.js\"></script>\r\n\r\n<!-- local JS -->\r\n<script src=\"/_assets/js/local.js\"></s" +
                    "cript>\r\n\r\n\r\n\r\n<!-- Root element of PhotoSwipe. Must have class pswp. -->\r\n<div c" +
                    "lass=\"pswp\" tabindex=\"-1\" role=\"dialog\" aria-hidden=\"true\">\r\n    <!-- Background" +
                    " of PhotoSwipe.\r\n    It\'s a separate element as animating opacity is faster than" +
                    " rgba(). -->\r\n    <div class=\"pswp__bg\"></div>\r\n    <!-- Slides wrapper with ove" +
                    "rflow:hidden. -->\r\n    <div class=\"pswp__scroll-wrap\">\r\n        <!-- Container t" +
                    "hat holds slides.\r\n        PhotoSwipe keeps only 3 of them in the DOM to save me" +
                    "mory.\r\n        Don\'t modify these 3 pswp__item elements, data is added later on." +
                    " -->\r\n        <div class=\"pswp__container\">\r\n            <div class=\"pswp__item\"" +
                    "></div>\r\n            <div class=\"pswp__item\"></div>\r\n            <div class=\"psw" +
                    "p__item\"></div>\r\n        </div>\r\n        <!-- Default (PhotoSwipeUI_Default) int" +
                    "erface on top of sliding area. Can be changed. -->\r\n        <div class=\"pswp__ui" +
                    " pswp__ui--hidden\">\r\n            <div class=\"pswp__top-bar\">\r\n                <!" +
                    "--  Controls are self-explanatory. Order can be changed. -->\r\n                <d" +
                    "iv class=\"pswp__counter\"></div>\r\n                <button class=\"pswp__button psw" +
                    "p__button--close\" title=\"Close (Esc)\"></button>\r\n                <button class=\"" +
                    "pswp__button pswp__button--share\" title=\"Share\"></button>\r\n                <butt" +
                    "on class=\"pswp__button pswp__button--fs\" title=\"Toggle fullscreen\"></button>\r\n  " +
                    "              <button class=\"pswp__button pswp__button--zoom\" title=\"Zoom in/out" +
                    "\"></button>\r\n                <!-- Preloader demo http://codepen.io/dimsemenov/pe" +
                    "n/yyBWoR -->\r\n                <!-- element will get class pswp__preloader--activ" +
                    "e when preloader is running -->\r\n                <div class=\"pswp__preloader\">\r\n" +
                    "                    <div class=\"pswp__preloader__icn\">\r\n                        " +
                    "<div class=\"pswp__preloader__cut\">\r\n                            <div class=\"pswp" +
                    "__preloader__donut\"></div>\r\n                        </div>\r\n                    " +
                    "</div>\r\n                </div>\r\n            </div>\r\n            <div class=\"pswp" +
                    "__share-modal pswp__share-modal--hidden pswp__single-tap\">\r\n                <div" +
                    " class=\"pswp__share-tooltip\"></div>\r\n            </div>\r\n            <button cla" +
                    "ss=\"pswp__button pswp__button--arrow--left\" title=\"Previous (arrow left)\"></butt" +
                    "on>\r\n            <button class=\"pswp__button pswp__button--arrow--right\" title=\"" +
                    "Next (arrow right)\"></button>\r\n            <div class=\"pswp__caption\">\r\n        " +
                    "        <div class=\"pswp__caption__center\"></div>\r\n            </div>\r\n        <" +
                    "/div>\r\n    </div>\r\n</div>\r\n    </body>\r\n</html>");
            this.Write("\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class TGalleryPageBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
