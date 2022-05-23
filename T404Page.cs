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
    
    #line 1 "E:\Dev\Github\Vanity\T404Page.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class T404Page : T404PageBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("<!DOCTYPE html>\r\n<!-- generated by Vanity, https://github.com/ishani/Vanity -->\r\n" +
                    "<html lang=\"en\">\r\n<head>\r\n    <!-- Global site tag (gtag.js) - Google Analytics " +
                    "-->\r\n    <script async src=\"https://www.googletagmanager.com/gtag/js?id=");
            
            #line 6 "E:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mGoogleUATag));
            
            #line default
            #line hidden
            this.Write("\"></script>\r\n    <script>\r\n        window.dataLayer = window.dataLayer || [];\r\n  " +
                    "      function gtag() { dataLayer.push(arguments); }\r\n        gtag(\'js\', new Dat" +
                    "e());\r\n        gtag(\'config\', \'");
            
            #line 11 "E:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mGoogleUATag));
            
            #line default
            #line hidden
            this.Write(@"');
    </script>

    <!-- metadata -->
    <meta charset=""utf-8"">

    <meta http-equiv=""content-type"" content=""text/html; charset=utf-8"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"" />

    <meta name=""viewport"" content=""width=device-width, minimum-scale=1, maximum-scale=1"" />
    <meta name=""twitter:card"" content=""summary"">
    <meta name=""og:type"" content=""website"" />
    <meta name=""og:title"" content=""Photography by ");
            
            #line 23 "E:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mGalleryOwner));
            
            #line default
            #line hidden
            this.Write(" - ");
            
            #line 23 "E:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mPageTitle));
            
            #line default
            #line hidden
            this.Write("\" />\r\n\r\n    <title>");
            
            #line 25 "E:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mGalleryName));
            
            #line default
            #line hidden
            this.Write(" &middot; ");
            
            #line 25 "E:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mPageTitle));
            
            #line default
            #line hidden
            this.Write(@"</title>

    <!-- bootstrap 4 -->
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css"" integrity=""sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l"" crossorigin=""anonymous"">

    <!-- font awesome 5 -->
    <script defer src=""https://use.fontawesome.com/releases/v5.8.1/js/all.js"" integrity=""sha384-g5uSoOSBd7KkhAMlnQILrecXvzst9TdC09/VM+pjDTCM+1il8RHz5fKANTFFb+gQ"" crossorigin=""anonymous""></script>

    <!-- fonts -->
    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Open+Sans:300i,400|Abel"">

    <!-- photoswipe CSS -->
    <link rel=""stylesheet"" type=""text/css"" href=""/_assets/photoswipe/css/photoswipe.all.min.css?v=");
            
            #line 37 "E:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mVersion));
            
            #line default
            #line hidden
            this.Write("\">\r\n\r\n    <!-- local CSS -->\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"/_" +
                    "assets/css/local.css?v=");
            
            #line 40 "E:\Dev\Github\Vanity\TCommonHeader.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mVersion));
            
            #line default
            #line hidden
            this.Write("\">\r\n\r\n</head>\r\n<body>\r\n");
            this.Write(@"

  <div class=""container"">

        <div class=""page-top text-center"">

            <!-- minimalist navbar -->
            <div class=""row"">
                <div class=""col"">
                    <a href=""/""><i class=""fas fa-home""></i> Home</a>
                </div>
                <div class=""col-6"">
                </div>
                <div class=""col"">
                    <a href=""/about.html""><i class=""fas fa-question-circle"" style=""margin-left: 2.5px;""></i> About</a>
                </div>
            </div>

        </div>


  <div class=""jumbotron bg-dark"">
    <h1>404 Not Found</h1>
    <p>Nothing here!</p>
  </div>
 </div>


");
            this.Write(@"<!-- bootstrap -->
<script src=""https://code.jquery.com/jquery-3.5.1.slim.min.js"" integrity=""sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj"" crossorigin=""anonymous""></script>
<script src=""https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"" integrity=""sha384-Piv4xVNRyMGpqkS2by6br4gNJ7DXjqk09RmUpJ8jgGtD7zP9yug3goQfGII0yAns"" crossorigin=""anonymous""></script>

<!-- photoswipe JS -->
<script src=""/_assets/photoswipe/js/photoswipe.all.min.js""></script>

<!-- local JS -->
<script src=""/_assets/js/local.js?v=");
            
            #line 9 "E:\Dev\Github\Vanity\TCommonFooter.html"
            this.Write(this.ToStringHelper.ToStringWithCulture(mVersion));
            
            #line default
            #line hidden
            this.Write("\"></script>\r\n\r\n\r\n\r\n<!-- Root element of PhotoSwipe. Must have class pswp. -->\r\n<d" +
                    "iv class=\"pswp\" tabindex=\"-1\" role=\"dialog\" aria-hidden=\"true\">\r\n    <!-- Backgr" +
                    "ound of PhotoSwipe.\r\n    It\'s a separate element as animating opacity is faster " +
                    "than rgba(). -->\r\n    <div class=\"pswp__bg\"></div>\r\n    <!-- Slides wrapper with" +
                    " overflow:hidden. -->\r\n    <div class=\"pswp__scroll-wrap\">\r\n        <!-- Contain" +
                    "er that holds slides.\r\n        PhotoSwipe keeps only 3 of them in the DOM to sav" +
                    "e memory.\r\n        Don\'t modify these 3 pswp__item elements, data is added later" +
                    " on. -->\r\n        <div class=\"pswp__container\">\r\n            <div class=\"pswp__i" +
                    "tem\"></div>\r\n            <div class=\"pswp__item\"></div>\r\n            <div class=" +
                    "\"pswp__item\"></div>\r\n        </div>\r\n        <!-- Default (PhotoSwipeUI_Default)" +
                    " interface on top of sliding area. Can be changed. -->\r\n        <div class=\"pswp" +
                    "__ui pswp__ui--hidden\">\r\n            <div class=\"pswp__top-bar\">\r\n              " +
                    "  <!--  Controls are self-explanatory. Order can be changed. -->\r\n              " +
                    "  <div class=\"pswp__counter\"></div>\r\n                <button class=\"pswp__button" +
                    " pswp__button--close\" title=\"Close (Esc)\"></button>\r\n                <button cla" +
                    "ss=\"pswp__button pswp__button--share\" title=\"Share\"></button>\r\n                <" +
                    "button class=\"pswp__button pswp__button--fs\" title=\"Toggle fullscreen\"></button>" +
                    "\r\n                <button class=\"pswp__button pswp__button--zoom\" title=\"Zoom in" +
                    "/out\"></button>\r\n                <!-- Preloader demo http://codepen.io/dimsemeno" +
                    "v/pen/yyBWoR -->\r\n                <!-- element will get class pswp__preloader--a" +
                    "ctive when preloader is running -->\r\n                <div class=\"pswp__preloader" +
                    "\">\r\n                    <div class=\"pswp__preloader__icn\">\r\n                    " +
                    "    <div class=\"pswp__preloader__cut\">\r\n                            <div class=\"" +
                    "pswp__preloader__donut\"></div>\r\n                        </div>\r\n                " +
                    "    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"" +
                    "pswp__share-modal pswp__share-modal--hidden pswp__single-tap\">\r\n                " +
                    "<div class=\"pswp__share-tooltip\"></div>\r\n            </div>\r\n            <button" +
                    " class=\"pswp__button pswp__button--arrow--left\" title=\"Previous (arrow left)\"></" +
                    "button>\r\n            <button class=\"pswp__button pswp__button--arrow--right\" tit" +
                    "le=\"Next (arrow right)\"></button>\r\n            <div class=\"pswp__caption\">\r\n    " +
                    "            <div class=\"pswp__caption__center\"></div>\r\n            </div>\r\n     " +
                    "   </div>\r\n    </div>\r\n</div>\r\n    </body>\r\n</html>");
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
    public class T404PageBase
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
