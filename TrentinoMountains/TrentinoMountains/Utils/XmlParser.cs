using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using TrentinoMountains.Models;

namespace TrentinoMountains.Utils
{
    public static class XmlParser
    {
        /// <summary>
        /// Returns the list of tracks, parsing the default gpxs files
        /// </summary>
        /// <returns>
        /// An IEnumerable of the default Tracks
        /// </returns>
        public static IEnumerable<Track> GetAllTracks()
        {
            List<Track> tracks = new List<Track>();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(XmlParser)).Assembly;
            var files = assembly.GetManifestResourceNames().Where(x => x.StartsWith("TrentinoMountains.Resources.SentieriSat"));

            foreach (var file in files)
            {
                using (var stream = assembly.GetManifestResourceStream(file))
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(stream);

                        var gpx = doc.FirstChild.NextSibling;                        

                        //var metadata = gpx["metadata"];
                        var track = gpx["trk"];

                        var name = track["name"].InnerText;
                        var desc = track["desc"]?.InnerText ?? string.Empty;

                        tracks.Add(new Track
                        {
                            Name = name,
                            Description = desc,
                            Type = TrackType.SAT,
                            GPX_ResourceId = file
                        });
                    }
                    catch (Exception ex)
                    {
                        //todo: add logging
                        Console.WriteLine(ex);
                    }
                }
            }

            return tracks;
        }

        /// <summary>
        /// Returns the list of points (lat, lon) of a specific track
        /// </summary>
        /// <param name="gpx_ResourceId">Resource ID of the gpx file</param>
        /// <returns>A list of GeoWaypoints (lat, lon)</returns>
        public static IEnumerable<GeoWaypoint> GetTrackPoints(string gpx_ResourceId)
        {
            var points = new List<GeoWaypoint>();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(XmlParser)).Assembly;
            using (var stream = assembly.GetManifestResourceStream(gpx_ResourceId))
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(stream);

                    var gpx = doc.FirstChild.NextSibling;

                    var track = gpx["trk"];
                    var seg = track["trkseg"];

                    foreach (XmlNode point in seg)
                    {
                        var lat = double.Parse(point.Attributes["lat"].Value);
                        var lon = double.Parse(point.Attributes["lon"].Value);

                        points.Add(new GeoWaypoint(lon, lat));
                    }
                }
                catch (Exception ex)
                {
                    //todo: add logging
                    Console.WriteLine(ex);
                }
            }

            return points;
        }
    }
}
