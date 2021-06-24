using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Model
{
    public enum MusicGenre
    {
        Rock,
        Jazz,
        Pop,
        Hiphop,
        Folk,
        Country,
        Classical
    }
    public class Music
    {
        public string Name { get; set; }
        public MusicGenre Genre { get; set; }
        public string CoverArtFile { get; set; }
        public string AudioFile { get; set; }
        public string Artist { get; set; }

        public Music(string name, MusicGenre genre)
        {
            Name = name;
            Genre = genre;
            CoverArtFile = $"/Assets/CoverArt/{genre}/{name}.jpg";
            AudioFile = $"/Assets/SongFiles/{genre}/{name}.mp3";
        }
    }
}
