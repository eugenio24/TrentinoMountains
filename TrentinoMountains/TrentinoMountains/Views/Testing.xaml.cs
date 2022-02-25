using Mapsui;
using Mapsui.Geometries;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.UI;
using Mapsui.UI.Forms;
using Mapsui.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrentinoMountains.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Testing : ContentPage
    {
        public Testing()
        {
            InitializeComponent();

            mapView.Map = CreateMap();
        }

        public Map CreateMap()
        {
            var map = new Map()
            {
                CRS = "EPSG:3857",
                Transformation = new MinimalTransformation()
            };

            map.Layers.Add(OpenStreetMap.CreateTileLayer());
            map.Layers.Add(CreateCustomLayer());

            return map;
        }

        public ILayer CreateCustomLayer()
        {
            var lineString = new LineString();
            List<Feature> featureList = new List<Feature>();

            List<GeoWaypoint> geoWaypoints = GetGeoPoints();

            foreach (var wp in geoWaypoints)
            {
                var point = SphericalMercator.FromLonLat(wp.Longitude, wp.Latitude);
                lineString.Vertices.Add(point);

            }

            IStyle linestringStyle = new VectorStyle()
            {
                Fill = null,
                Outline = null,
                Line = { Color = Mapsui.Styles.Color.FromString("Blue"), Width = 4 }
            };
            Feature lineStringFeature = new Feature()
            {
                Geometry = lineString
            };

            lineStringFeature.Styles.Add(linestringStyle);

            featureList.Add(lineStringFeature);

            MemoryProvider memoryProvider = new MemoryProvider(featureList);

            return new MemoryLayer
            {
                DataSource = memoryProvider,
                Name = "layerName_aa"
            };
        }

        private List<GeoWaypoint> GetGeoPoints()
        {
            var list = new List<GeoWaypoint>();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Testing)).Assembly;
            var x = assembly.GetManifestResourceNames();
            Stream stream = assembly.GetManifestResourceStream("TrentinoMountains.Resources.SentieriSat.est.E745.gpx");
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(stream);

                XmlNode root = doc.FirstChild;
                var gpx = root.NextSibling;

                var metadata = gpx["metadata"];
                var track = gpx["trk"];

                var name = track["name"].InnerText;
                var desc = track["desc"]?.InnerText ?? string.Empty;
                var seg = track["trkseg"];

                foreach (XmlNode point in seg)
                {
                    var lat = double.Parse(point.Attributes["lat"].Value);
                    var lon = double.Parse(point.Attributes["lon"].Value);

                    list.Add(new GeoWaypoint() { Latitude = lat, Longitude = lon });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return list;
        }
    }

    internal class GeoWaypoint
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}