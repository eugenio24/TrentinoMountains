using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrentinoMountains.Models;

namespace TrentinoMountains.Utils
{
    public static class DatabaseUtils
    {
        /// <summary>
        /// Populate the database with the default tracks (sentieri-sat)
        /// </summary>
        /// <returns></returns>
        public static async Task PopulateDatabase()
        {
            var tracks = XmlParser.GetAllTracks();

            //todo: change to insert all
            foreach (Track track in tracks)
            {
                await App.TracksService.AddTrack(track.Name, track.Description, track.Type, track.GPX_ResourceId);
            }
        }
    }
}
