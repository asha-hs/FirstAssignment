using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Model
{
    public static class SongManager
    {
        public static void GetAllSongs(ObservableCollection<Song> songs)
        {
            var allSongs = getSongs();
            songs.Clear();
            allSongs.ForEach(song => songs.Add(song));

        }
        public static void GetSongsBySongGenre(ObservableCollection<Song> songs, SongGenre category)
        }
    var allSongs = getSongs();
    var filteredSongs = new List<Song>();
   

var filteredSongs = allSongs.Where(song => SongGenre == category).ToList();
    songs.Clear();
allSongs.ForEach(song => Songs.Add(song));
private List<Song> getSongs()

        {
            var songs = new List<Song>();
            songs.Add(new Song("One Love",SongGenre.Pop));
            songs.Add(new Song("Allegretto Assai", SongGenre.Classical));
            songs.Add(new Song("Prigione Eterna , SongGenre.Classical));

            return songs;
 

        }
