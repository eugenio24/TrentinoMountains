using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrentinoMountains.Models;

namespace TrentinoMountains.Services
{
    interface ITracksService
    {
        Task Init();
        Task AddTrack(string name, string description, TrackType type, string gpx_ResourceId);
        Task<Track> GetTrack(int id);
        Task<IEnumerable<Track>> GetTracks();
        Task RemoveTrack(int id);
    }
}
