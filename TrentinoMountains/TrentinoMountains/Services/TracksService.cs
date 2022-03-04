using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TrentinoMountains.Models;
using TrentinoMountains.Utils;
using Xamarin.Essentials;

namespace TrentinoMountains.Services
{
    public class TracksService : ITracksService
    {
        private SQLiteAsyncConnection _database;

        public async Task Init()
        {
            if (_database != null) return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tracks.db3");
            _database = new SQLiteAsyncConnection(databasePath);          

            var result = await _database.CreateTableAsync<Track>();

            if (result == CreateTableResult.Created)
            {
                await DatabaseUtils.PopulateDatabase();
            }
        }

        public async Task AddTrack(string name, string description, TrackType type, string gpx_ResourceId)
        {
            await Init();

            var track = new Track
            {
                Name = name,
                Description = description,
                Type = type,
                GPX_ResourceId = gpx_ResourceId
            };

            await _database.InsertAsync(track);
        }

        public async Task<Track> GetTrack(int id)
        {
            await Init();

            return await _database.GetAsync<Track>(id);
        }

        public async Task<IEnumerable<Track>> GetTracks()
        {
            await Init();

            return await _database.Table<Track>().ToListAsync();
        }   

        public async Task RemoveTrack(int id)
        {
            await Init();

            await _database.DeleteAsync<Track>(id);
        }
    }
}
