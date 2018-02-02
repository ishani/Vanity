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
    
    #line 1 "S:\Dev\Web\IO4\photography.ishani.org\Vanity\Thtaccess.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class Thtaccess : ThtaccessBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n<Files .htaccess>\r\norder allow,deny\r\ndeny from all\r\n</Files>\r\n\r\nErrorDocument 4" +
                    "04 /404.html\r\n\r\n\r\n# ------------------------------------------------------------" +
                    "------------------\r\nServerSignature Off\r\nRewriteEngine on\r\nOptions -Indexes\r\nOpt" +
                    "ions -ExecCGI\r\nRemoveHandler .cgi .php .php3 .php4 .php5 .phtml .pl .py .pyc .py" +
                    "o\r\n\r\n# -------------------------------------------------------------------------" +
                    "-----\r\n# 5G BLACKLIST/FIREWALL (2013)\r\n# @ http://perishablepress.com/5g-blackli" +
                    "st-2013/\r\n# 5G:[QUERY STRINGS]\r\n<IfModule mod_rewrite.c>\r\n  RewriteEngine On\r\n  " +
                    "RewriteBase /\r\n  RewriteCond %{QUERY_STRING} (\\\"|%22).*(<|>|%3) [NC,OR]\r\n  Rewri" +
                    "teCond %{QUERY_STRING} (javascript:).*(\\;) [NC,OR]\r\n  RewriteCond %{QUERY_STRING" +
                    "} (<|%3C).*script.*(>|%3) [NC,OR]\r\n  RewriteCond %{QUERY_STRING} (\\\\|\\.\\./|`|=\\\'" +
                    "$|=%27$) [NC,OR]\r\n  RewriteCond %{QUERY_STRING} (\\;|\\\'|\\\"|%22).*(union|select|in" +
                    "sert|drop|update|md5|benchmark|or|and|if) [NC,OR]\r\n  RewriteCond %{QUERY_STRING}" +
                    " (base64_encode|localhost|mosconfig) [NC,OR]\r\n  RewriteCond %{QUERY_STRING} (boo" +
                    "t\\.ini|echo.*kae|etc/passwd) [NC,OR]\r\n  RewriteCond %{QUERY_STRING} (GLOBALS|REQ" +
                    "UEST)(=|\\[|%) [NC]\r\n  RewriteRule .* - [F]\r\n</IfModule>\r\n\r\n# 5G:[USER AGENTS]\r\n<" +
                    "IfModule mod_setenvif.c>\r\n  # SetEnvIfNoCase User-Agent ^$ keep_out\r\n  SetEnvIfN" +
                    "oCase User-Agent (binlar|casper|cmsworldmap|comodo|diavol|dotbot|feedfinder|flic" +
                    "ky|ia_archiver|jakarta|kmccrew|nutch|planetwork|purebot|pycurl|skygrid|sucker|tu" +
                    "rnit|vikspider|zmeu) keep_out\r\n  <limit GET POST PUT>\r\n    Order Allow,Deny\r\n   " +
                    " Allow from all\r\n    Deny from env=keep_out\r\n  </limit>\r\n</IfModule>\r\n\r\n# 5G:[RE" +
                    "QUEST STRINGS]\r\n<IfModule mod_alias.c>\r\n  RedirectMatch 403 (https?|ftp|php)\\://" +
                    "\r\n  RedirectMatch 403 /(https?|ima|ucp)/\r\n  RedirectMatch 403 /(Permanent|Better" +
                    ")$\r\n  RedirectMatch 403 (\\=\\\\\\\'|\\=\\\\%27|/\\\\\\\'/?|\\)\\.css\\()$\r\n  RedirectMatch 403" +
                    " (\\,|\\)\\+|/\\,/|\\{0\\}|\\(/\\(|\\.\\.\\.|\\+\\+\\+|\\||\\\\\\\"\\\\\\\")\r\n  RedirectMatch 403 \\.(cg" +
                    "i|asp|aspx|cfg|dll|exe|jsp|mdb|sql|ini|rar)$\r\n  RedirectMatch 403 /(contac|fpw|i" +
                    "nstall|pingserver|register)\\.php$\r\n  RedirectMatch 403 (base64|crossdomain|local" +
                    "host|wwwroot|e107\\_)\r\n  RedirectMatch 403 (eval\\(|\\_vti\\_|\\(null\\)|echo.*kae|con" +
                    "fig\\.xml)\r\n  RedirectMatch 403 \\.well\\-known/host\\-meta\r\n  RedirectMatch 403 /fu" +
                    "nction\\.array\\-rand\r\n  RedirectMatch 403 \\)\\;\\$\\(this\\)\\.html\\(\r\n  RedirectMatch" +
                    " 403 proc/self/environ\r\n  RedirectMatch 403 msnbot\\.htm\\)\\.\\_\r\n  RedirectMatch 4" +
                    "03 /ref\\.outcontrol\r\n  RedirectMatch 403 com\\_cropimage\r\n  RedirectMatch 403 ind" +
                    "onesia\\.htm\r\n  RedirectMatch 403 \\{\\$itemURL\\}\r\n  RedirectMatch 403 function\\(\\)" +
                    "\r\n  RedirectMatch 403 labels\\.rdf\r\n  RedirectMatch 403 /playing.php\r\n  RedirectM" +
                    "atch 403 muieblackcat\r\n</IfModule>\r\n\r\n# 5G:[REQUEST METHOD]\r\n<ifModule mod_rewri" +
                    "te.c>\r\n  RewriteCond %{REQUEST_METHOD} ^(TRACE|TRACK)\r\n  RewriteRule .* - [F]\r\n<" +
                    "/IfModule>\r\n\r\n# ----------------------------------------------------------------" +
                    "--------------\r\n# | UTF-8 encoding                                              " +
                    "               |\r\n# ------------------------------------------------------------" +
                    "------------------\r\n\r\n# Use UTF-8 encoding for anything served as `text/html` or" +
                    " `text/plain`.\r\nAddDefaultCharset utf-8\r\n\r\n# Force UTF-8 for certain file format" +
                    "s.\r\n<IfModule mod_mime.c>\r\n    AddCharset utf-8 .atom .css .js .json .jsonld .rs" +
                    "s .vtt .webapp .xml\r\n</IfModule>\r\n\r\n\r\n# ----------------------------------------" +
                    "--------------------------------------\r\n# | Compression                         " +
                    "                                       |\r\n# ------------------------------------" +
                    "------------------------------------------\r\n\r\n# HTML, TXT, CSS, JavaScript, JSON" +
                    ", XML, HTC:\r\n<IfModule filter_module>\r\n    FilterDeclare   COMPRESS\r\n    FilterP" +
                    "rovider  COMPRESS  DEFLATE resp=Content-Type $text/html\r\n    FilterProvider  COM" +
                    "PRESS  DEFLATE resp=Content-Type $text/css\r\n    FilterProvider  COMPRESS  DEFLAT" +
                    "E resp=Content-Type $text/plain\r\n    FilterProvider  COMPRESS  DEFLATE resp=Cont" +
                    "ent-Type $text/xml\r\n    FilterProvider  COMPRESS  DEFLATE resp=Content-Type $tex" +
                    "t/x-component\r\n    FilterProvider  COMPRESS  DEFLATE resp=Content-Type $applicat" +
                    "ion/javascript\r\n    FilterProvider  COMPRESS  DEFLATE resp=Content-Type $applica" +
                    "tion/json\r\n    FilterProvider  COMPRESS  DEFLATE resp=Content-Type $application/" +
                    "xml\r\n    FilterProvider  COMPRESS  DEFLATE resp=Content-Type $application/xhtml+" +
                    "xml\r\n    FilterProvider  COMPRESS  DEFLATE resp=Content-Type $application/rss+xm" +
                    "l\r\n    FilterProvider  COMPRESS  DEFLATE resp=Content-Type $application/atom+xml" +
                    "\r\n    FilterProvider  COMPRESS  DEFLATE resp=Content-Type $application/vnd.ms-fo" +
                    "ntobject\r\n    FilterProvider  COMPRESS  DEFLATE resp=Content-Type $image/svg+xml" +
                    "\r\n    FilterProvider  COMPRESS  DEFLATE resp=Content-Type $image/x-icon\r\n    Fil" +
                    "terProvider  COMPRESS  DEFLATE resp=Content-Type $application/x-font-ttf\r\n    Fi" +
                    "lterProvider  COMPRESS  DEFLATE resp=Content-Type $font/opentype\r\n    FilterChai" +
                    "n     COMPRESS\r\n    FilterProtocol  COMPRESS  DEFLATE change=yes;byteranges=no\r\n" +
                    "</IfModule>\r\n\r\n<IfModule !mod_filter.c>\r\n    # Legacy versions of Apache\r\n    Ad" +
                    "dOutputFilterByType DEFLATE text/html text/plain text/css application/json\r\n    " +
                    "AddOutputFilterByType DEFLATE application/javascript\r\n    AddOutputFilterByType " +
                    "DEFLATE text/xml application/xml text/x-component\r\n    AddOutputFilterByType DEF" +
                    "LATE application/xhtml+xml application/rss+xml application/atom+xml\r\n    AddOutp" +
                    "utFilterByType DEFLATE image/x-icon image/svg+xml application/vnd.ms-fontobject " +
                    "application/x-font-ttf font/opentype\r\n</IfModule>\r\n\r\n\r\n# -----------------------" +
                    "-------------------------------------------------------\r\n# | ETags              " +
                    "                                                        |\r\n# -------------------" +
                    "-----------------------------------------------------------\r\n\r\n# Remove `ETags` " +
                    "as resources are sent with far-future expires headers.\r\n# http://developer.yahoo" +
                    ".com/performance/rules.html#etags.\r\n\r\n# `FileETag None` doesn\'t work in all case" +
                    "s.\r\n<IfModule mod_headers.c>\r\n    Header unset ETag\r\n\r\n  <FilesMatch \".(js|css|x" +
                    "ml|gz|html)$\">\r\n    Header append Vary: Accept-Encoding\r\n  </FilesMatch>\r\n\r\n</If" +
                    "Module>\r\n\r\nFileETag None\r\n\r\n# --------------------------------------------------" +
                    "----------------------------\r\n# | Expires headers                               " +
                    "                             |\r\n# ----------------------------------------------" +
                    "--------------------------------\r\n\r\n# The following expires headers are set pret" +
                    "ty far in the future. If you\r\n# don\'t control versioning with filename-based cac" +
                    "he busting, consider\r\n# lowering the cache time for resources such as style shee" +
                    "ts and JavaScript\r\n# files to something like one week.\r\n\r\n<IfModule mod_expires." +
                    "c>\r\n\r\n    ExpiresActive on\r\n    ExpiresDefault                                  " +
                    "    \"access plus 1 month\"\r\n\r\n  # CSS\r\n    ExpiresByType text/css                " +
                    "              \"access plus 1 year\"\r\n\r\n  # Data interchange\r\n    ExpiresByType ap" +
                    "plication/json                      \"access plus 0 seconds\"\r\n    ExpiresByType a" +
                    "pplication/ld+json                   \"access plus 0 seconds\"\r\n    ExpiresByType " +
                    "application/xml                       \"access plus 0 seconds\"\r\n    ExpiresByType" +
                    " text/xml                              \"access plus 0 seconds\"\r\n\r\n  # Favicon (c" +
                    "annot be renamed!) and cursor images\r\n    ExpiresByType image/x-icon            " +
                    "              \"access plus 1 year\"\r\n\r\n  # HTML components (HTCs)\r\n    ExpiresByT" +
                    "ype text/x-component                      \"access plus 1 month\"\r\n\r\n  # HTML\r\n   " +
                    " ExpiresByType text/html                             \"access plus 0 seconds\"\r\n\r\n" +
                    "  # JavaScript\r\n    ExpiresByType application/javascript                \"access " +
                    "plus 1 year\"\r\n\r\n  # Manifest files\r\n    ExpiresByType application/x-web-app-mani" +
                    "fest+json   \"access plus 0 seconds\"\r\n    ExpiresByType text/cache-manifest      " +
                    "             \"access plus 0 seconds\"\r\n\r\n  # Media\r\n    ExpiresByType audio/ogg  " +
                    "                           \"access plus 1 month\"\r\n    ExpiresByType image/gif   " +
                    "                          \"access plus 1 month\"\r\n    ExpiresByType image/jpeg   " +
                    "                         \"access plus 1 month\"\r\n    ExpiresByType image/png     " +
                    "                        \"access plus 1 month\"\r\n    ExpiresByType video/mp4      " +
                    "                       \"access plus 1 month\"\r\n    ExpiresByType video/ogg       " +
                    "                      \"access plus 1 month\"\r\n    ExpiresByType video/webm       " +
                    "                     \"access plus 1 month\"\r\n\r\n  # Web feeds\r\n    ExpiresByType a" +
                    "pplication/atom+xml                  \"access plus 1 hour\"\r\n    ExpiresByType app" +
                    "lication/rss+xml                   \"access plus 1 hour\"\r\n\r\n  # Web fonts\r\n    Ex" +
                    "piresByType application/font-woff                 \"access plus 1 month\"\r\n    Exp" +
                    "iresByType application/vnd.ms-fontobject         \"access plus 1 month\"\r\n    Expi" +
                    "resByType application/x-font-ttf                \"access plus 1 month\"\r\n    Expir" +
                    "esByType font/opentype                         \"access plus 1 month\"\r\n    Expire" +
                    "sByType image/svg+xml                         \"access plus 1 month\"\r\n\r\n</IfModul" +
                    "e>\r\n\r\n");
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
    public class ThtaccessBase
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