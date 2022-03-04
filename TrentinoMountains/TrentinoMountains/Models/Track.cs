using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrentinoMountains.Models
{
    [Table("Tracks")]
    public class Track
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [NotNull]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("type")]
        [NotNull]
        public TrackType Type { get; set; }

        [Column("gpx_resource_id")]
        public string GPX_ResourceId { get; set; } 
    }

    public enum TrackType
    {
        SAT,
        CUSTOM
    }
}
