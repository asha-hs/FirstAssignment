using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Model
{

    public enum SongGenre
        Classical,
        Rock,
        Pop,
}
  public class Song
    {
    public string SongTitle { get; set; }
    public string SongGenre { get; set; }
    public string AudioFile { get; set; }
    public string ImageFile { get; set; }

    public Song(string name, SongGenre category)
    {
        SongTitle = name;
        SongGenre = category;
        AudioFile = "/Assets/SongFiles/{category}/{name}.mp3";
        ImageFile = "/Assets/Cover Art/{ category}/{name}.jpg"";
    }
     
    }
}
