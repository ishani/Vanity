﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
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
    
    #line 1 "S:\Dev\Web\IO4\photography.ishani.org\Vanity\TAboutPage.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class TAboutPage : TAboutPageBase
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
            
            #line 23 "S:\Dev\Web\IO4\photography.ishani.org\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mPageTitle));
            
            #line default
            #line hidden
            this.Write("\" />\r\n\r\n        <title>Ishani\'s Gallery &middot; ");
            
            #line 25 "S:\Dev\Web\IO4\photography.ishani.org\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mPageTitle));
            
            #line default
            #line hidden
            this.Write(@"</title>

        <!-- bootstrap 4 -->
        <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"" integrity=""sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"" crossorigin=""anonymous"">

        <!-- font awesome 5 -->
        <script defer src=""https://use.fontawesome.com/releases/v5.0.6/js/all.js""></script>

        <!-- fonts -->
        <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Open+Sans:300i,400|Abel"">

        <!-- photoswipe CSS -->
        <link rel=""stylesheet"" type=""text/css"" href=""/_assets/photoswipe/css/photoswipe.all.min.css"">

        <!-- local CSS -->
        <link rel=""stylesheet"" type=""text/css"" href=""/_assets/css/local.css?v=");
            
            #line 40 "S:\Dev\Web\IO4\photography.ishani.org\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mVersion));
            
            #line default
            #line hidden
            this.Write("\">\r\n\r\n    </head>\r\n<body>\r\n");
            this.Write("\r\n\r\n  <div class=\"container\">\r\n\r\n        <div class=\"page-top text-center\">\r\n\r\n  " +
                    "          <!-- minimalist navbar -->\r\n            <div class=\"row\">\r\n           " +
                    "     <div class=\"col\">\r\n                    <a href=\"/\"><i class=\"fas fa-home\"><" +
                    "/i> Home</a>\r\n                </div>\r\n                <div class=\"col-6\">\r\n     " +
                    "           </div>\r\n                <div class=\"col text-muted\">\r\n               " +
                    "     <i class=\"fas fa-question-circle\" style=\"margin-left: 2.5px;\"></i> About\r\n " +
                    "               </div>\r\n            </div>\r\n\r\n        </div>\r\n\r\n\r\n  <div class=\"j" +
                    "umbotron bg-dark\">\r\n    <h1>About</h1>\r\n    <p>Hello! I\'m Harry, this is where I" +
                    " park the pictures I can stand to show other people. My main site is <a href=\"ht" +
                    "tp://www.ishani.org/\" target=\"_blank\">over yonder</a>. I also keep a small stash" +
                    " of images on <a href=\"http://500px.com/ishani\" target=\"_blank\">500px</a>.</p>\r\n" +
                    "    <p>Currently I use an <strong>Olympus PEN-F</strong>, a small bag of lenses " +
                    "and <strong>DxO PhotoLab</strong>. Previously: Lightroom, Olympus E-M1, Panasoni" +
                    "c GX1, GF1, Canon 50D, 400D, 300D, 1000F, darkroom.</p>\r\n    <br>\r\n    <p>This g" +
                    "allery is generated offline by my own bespoke C# app - <strong>Vanity</strong>, " +
                    "<a href=\"https://github.com/ishani/Vanity\" target=\"_blank\">source on GitHub</a> " +
                    "- and statically served. Server synchrony is maintained with the excellent <a hr" +
                    "ef=\"http://www.2brightsparks.com/syncback/syncback-hub.html\" target=\"_blank\">Syn" +
                    "cBack</a>. The client code uses <a href=\"http://getbootstrap.com/\" target=\"_blan" +
                    "k\">Bootstrap 4</a> and <a href=\"http://photoswipe.com/\" target=\"_blank\">Photoswi" +
                    "pe</a>. HTML is minified using <a href=\"https://github.com/2xmax/System.Web.Stat" +
                    "icOptimization\" target=\"_blank\">Zeta</a>.</p>\r\n    <br>\r\n    <p>This version was" +
                    " generated on <strong>");
            
            #line 35 "S:\Dev\Web\IO4\photography.ishani.org\Vanity\TAboutPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DateTime.Now.ToString("MMMM dd, yyyy")));
            
            #line default
            #line hidden
            this.Write("</strong>, processing <strong>");
            
            #line 35 "S:\Dev\Web\IO4\photography.ishani.org\Vanity\TAboutPage.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mImageCount));
            
            #line default
            #line hidden
            this.Write("</strong> images.</p>\r\n    <br>\r\n    <p>Questions? Go check <a href=\"https://www." +
                    "ishani.org/contact/\" target=\"_blank\">ishani.org/contact</a></p>\r\n  </div>\r\n </di" +
                    "v>\r\n\r\n");
            this.Write("        <!-- bootstrap -->\r\n        <script src=\"https://code.jquery.com/jquery-3" +
                    ".2.1.slim.min.js\" integrity=\"sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFD" +
                    "MVNA/GpGFF93hXpG5KkN\" crossorigin=\"anonymous\"></script>\r\n        <script src=\"ht" +
                    "tps://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js\" integrity=\"sh" +
                    "a384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl\" crossorig" +
                    "in=\"anonymous\"></script>\r\n\r\n        <!-- photoswipe JS -->\r\n        <script src=" +
                    "\"/_assets/photoswipe/js/photoswipe.all.min.js\"></script>\r\n\r\n        <!-- local J" +
                    "S -->\r\n        <script src=\"/_assets/js/local.js\"></script>\r\n\r\n\r\n\r\n        <!-- " +
                    "Root element of PhotoSwipe. Must have class pswp. -->\r\n        <div class=\"pswp\"" +
                    " tabindex=\"-1\" role=\"dialog\" aria-hidden=\"true\">\r\n            <!-- Background of" +
                    " PhotoSwipe.\r\n            It\'s a separate element as animating opacity is faster" +
                    " than rgba(). -->\r\n            <div class=\"pswp__bg\"></div>\r\n            <!-- Sl" +
                    "ides wrapper with overflow:hidden. -->\r\n            <div class=\"pswp__scroll-wra" +
                    "p\">\r\n                <!-- Container that holds slides.\r\n                PhotoSwi" +
                    "pe keeps only 3 of them in the DOM to save memory.\r\n                Don\'t modify" +
                    " these 3 pswp__item elements, data is added later on. -->\r\n                <div " +
                    "class=\"pswp__container\">\r\n                    <div class=\"pswp__item\"></div>\r\n  " +
                    "                  <div class=\"pswp__item\"></div>\r\n                    <div class" +
                    "=\"pswp__item\"></div>\r\n                </div>\r\n                <!-- Default (Phot" +
                    "oSwipeUI_Default) interface on top of sliding area. Can be changed. -->\r\n       " +
                    "         <div class=\"pswp__ui pswp__ui--hidden\">\r\n                    <div class" +
                    "=\"pswp__top-bar\">\r\n                        <!--  Controls are self-explanatory. " +
                    "Order can be changed. -->\r\n                        <div class=\"pswp__counter\"></" +
                    "div>\r\n                        <button class=\"pswp__button pswp__button--close\" t" +
                    "itle=\"Close (Esc)\"></button>\r\n                        <button class=\"pswp__butto" +
                    "n pswp__button--share\" title=\"Share\"></button>\r\n                        <button " +
                    "class=\"pswp__button pswp__button--fs\" title=\"Toggle fullscreen\"></button>\r\n     " +
                    "                   <button class=\"pswp__button pswp__button--zoom\" title=\"Zoom i" +
                    "n/out\"></button>\r\n                        <!-- Preloader demo http://codepen.io/" +
                    "dimsemenov/pen/yyBWoR -->\r\n                        <!-- element will get class p" +
                    "swp__preloader--active when preloader is running -->\r\n                        <d" +
                    "iv class=\"pswp__preloader\">\r\n                            <div class=\"pswp__prelo" +
                    "ader__icn\">\r\n                                <div class=\"pswp__preloader__cut\">\r" +
                    "\n                                    <div class=\"pswp__preloader__donut\"></div>\r" +
                    "\n                                </div>\r\n                            </div>\r\n   " +
                    "                     </div>\r\n                    </div>\r\n                    <di" +
                    "v class=\"pswp__share-modal pswp__share-modal--hidden pswp__single-tap\">\r\n       " +
                    "                 <div class=\"pswp__share-tooltip\"></div>\r\n                    </" +
                    "div>\r\n                    <button class=\"pswp__button pswp__button--arrow--left\"" +
                    " title=\"Previous (arrow left)\">\r\n                    </button>\r\n                " +
                    "    <button class=\"pswp__button pswp__button--arrow--right\" title=\"Next (arrow r" +
                    "ight)\">\r\n                    </button>\r\n                    <div class=\"pswp__ca" +
                    "ption\">\r\n                        <div class=\"pswp__caption__center\"></div>\r\n    " +
                    "                </div>\r\n                </div>\r\n            </div>\r\n        </di" +
                    "v>\r\n    </body>\r\n</html>");
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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class TAboutPageBase
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
