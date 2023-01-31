using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class SongModel
    {
        public int SongId { get; set; }
        public string? Artist { get; set; }
        public string? Title { get; set; }
        public int? Year { get; set; }
        public string? Album { get; set; }
        public string? Genre { get; set; }
        public string? FilePath { get; set; }

        public SongModel(Song song)
        {
            this.SongId = song.SongId;
            this.Artist = song.Artist;
            this.Title = song.Title;
            this.Year = song.Year;
            this.Album = song.Album;
            this.Genre = song.Genre;
            this.FilePath = song.FilePath;
        }

        public SongModel() {}

    }


    
}
