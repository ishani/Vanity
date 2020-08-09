using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Vanity
{
    [XmlRoot( "urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9" )]
    public class Sitemap
    {
        [XmlElement("url")]
        public List<Location> mLocations = new List<Location>();

        public void Clear()
        {
            mLocations.Clear();
        }

        public void Add( Location item )
        {
            mLocations.Add( item );
        }
    }

    // http://blog.mikecouturier.com/2011/07/seo-tip-dynamic-google-xml-sitemaps.html
    public class Location
    {
        public enum eChangeFrequency
        {
            always,
            hourly,
            daily,
            weekly,
            monthly,
            yearly,
            never
        }

        [XmlElement( "loc" )]
        public string Url { get; set; }

        [XmlElement( "changefreq" )]
        public eChangeFrequency? ChangeFrequency { get; set; }
        public bool ShouldSerializeChangeFrequency() { return ChangeFrequency.HasValue; }

        [XmlElement( "lastmod" )]
        public DateTime? LastModified { get; set; }
        public bool ShouldSerializeLastModified() { return LastModified.HasValue; }

        [XmlElement( "priority" )]
        public double? Priority { get; set; }
        public bool ShouldSerializePriority() { return Priority.HasValue; }
    }
}
