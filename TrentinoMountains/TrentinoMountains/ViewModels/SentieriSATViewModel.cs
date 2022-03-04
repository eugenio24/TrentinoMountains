using Mapsui;
using Mapsui.Geometries;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.UI.Forms;
using Mapsui.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TrentinoMountains.Utils;
using TrentinoMountains.ViewModels.Base;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrentinoMountains.ViewModels
{
    class SentieriSATViewModel : BaseViewModel
    {
        #region Properties
        private MapView _mapView;
        public MapView MapView
        {
            get { return _mapView; }
            set
            {
                _mapView = value;
                OnPropertyChanged();
            }
        }

        private bool _mapLoaded;
        public bool MapLoaded
        {
            get { return _mapLoaded; }
            set
            {
                _mapLoaded = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public SentieriSATViewModel(MapView mapView, INavigation navigation) : base(navigation)
        {
            MapView = mapView;
            MapLoaded = false;
        }
        #endregion

        #region Map Functions
        public async Task<Map> CreateMap()
        {
            var map = new Map()
            {
                CRS = "EPSG:3857",
                Transformation = new MinimalTransformation()
            };

            map.Layers.Add(OpenStreetMap.CreateTileLayer());
            
            map.Layers.Add(await CreateTracksLayer());

            return map;
        }

        private async Task<ILayer> CreateTracksLayer()
        {
            List<Feature> featureList = new List<Feature>();

            IStyle linestringStyle = new VectorStyle()
            {
                Fill = null,
                Outline = null,
                Line = { Color = Mapsui.Styles.Color.FromString("Blue"), Width = 4 }
            };
           
            var tracks = await App.TracksService.GetTracks();

            foreach (var gpx_ResourceId in tracks.Select(x => x.GPX_ResourceId))
            {
                var lineStringFeature = CreateSingleTrackLine(gpx_ResourceId);
                lineStringFeature.Styles.Add(linestringStyle);
                featureList.Add(lineStringFeature);
            }

            MemoryProvider memoryProvider = new MemoryProvider(featureList);

            return new MemoryLayer
            {
                DataSource = memoryProvider,
                Name = "SAT_layer"
            };
        }

        private Feature CreateSingleTrackLine(string gpx_ResourceId)
        {
            var lineString = new LineString();

            List<GeoWaypoint> geoWaypoints = XmlParser.GetTrackPoints(gpx_ResourceId).ToList();

            foreach (var wp in geoWaypoints)
            {
                var point = SphericalMercator.FromLonLat(wp.Longitude, wp.Latitude);
                lineString.Vertices.Add(point);

            }

            Feature lineStringFeature = new Feature()
            {
                Geometry = lineString
            };            

            return lineStringFeature;
        }
        #endregion

        #region Commands
        public ICommand PageLoadedCommand => new Command(async () => { MapView.Map = await CreateMap(); MapLoaded = true; });
        #endregion
    }
}
