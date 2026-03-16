using System;
namespace BlazorLeaflet.Models
{
    /// <summary>
    /// The Leaflet-supported _c_oordinate _r_eference _s_ystems.
    ///
    /// Used in WMS tile layers.
    /// </summary>
    public class Crs
    {
        public string Code { get; }

        private Crs(string code) => Code = code;

        /// <summary>
        /// Rarely used by some commercial tile providers. Uses Elliptical
        /// Mercator projection.
        /// </summary>
        public static Crs Epsg3595 => new Crs("EPSG:3595");

        /// <summary>
        /// The most common CRS for online maps, used by almost all free and
        /// commercial tile providers. Uses Spherical Mercator projection. Set
        /// in by default in Map's crs option.
        /// </summary>
        public static Crs Epsg3857 => new Crs("EPSG:3857");

        /// <summary>
        /// A common CRS among GIS enthusiasts. Uses simple Equirectangular
        /// projection. Leaflet 1.0.x complies with the TMS coordinate scheme
        /// for EPSG:4326, which is a breaking change from 0.7.x behaviour. If
        /// you are using a TileLayer with this CRS, ensure that there are two
        /// 256x256 pixel tiles covering the whole earth at zoom level zero, and
        /// that the tile coordinate origin is (-180,+90), or (-180,-90) for
        /// TileLayers with the tms option set.
        /// </summary>
        public static Crs Epsg4326 => new Crs("EPSG:4326");
    }
}
