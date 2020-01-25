namespace BlazorLeaflet.Models
{
    public enum PredefinedCRS
    {
        /// <summary>
        /// The most common CRS for online maps, used by almost all free and commercial tile providers. Uses Spherical Mercator projection. Set in by default in Map's crs option.
        /// </summary>
        EPSG3857,
        /// <summary>
        /// A common CRS among GIS enthusiasts. Uses simple Equirectangular projection.
        /// </summary>
        EPSG4326,
        /// <summary>
        /// Rarely used by some commercial tile providers. Uses Elliptical Mercator projection.
        /// </summary>
        EPSG3395,
        /// <summary>
        /// A simple CRS that maps longitude and latitude into x and y directly. May be used for maps of flat surfaces (e.g. game maps). Note that the y axis should still be inverted (going from bottom to top).
        /// </summary>
        Simple,
        /// <summary>
        /// A simple CRS that maps longitude and latitude into x and y directly. May be used for maps of flat surfaces (e.g. game maps). X and Y reverted, i.e. Simple is (y, x), SimpleXY is (x,y)
        /// </summary>
        SimpleXY
    }
}