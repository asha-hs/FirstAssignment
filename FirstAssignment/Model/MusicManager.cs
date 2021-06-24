using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Model
{
    public static class MusicManager
    {
        
        public static void GetAllSongs(ObservableCollection<Music> songs)
        {
            var AllSongs = getSongs();

            songs.Clear();

            AllSongs.ForEach(song => songs.Add(song));
        }

        public static void GetAllSongsByGenre(ObservableCollection<Music> songs,MusicGenre genre)
        {
            songs.Clear();

            var AllSongs = getSongs();
            var filteredSongs = AllSongs.Where(song => song.Genre == genre).ToList();
            filteredSongs.ForEach(song => songs.Add(song));
        }

        private static List<Music> getSongs()
        {
            var songs = new List<Music>();

            songs.Add(new Music("harry-potter1", MusicGenre.Classical));
            songs.Add(new Music("harry-potter2", MusicGenre.Classical));
            songs.Add(new Music("Dee-Yan-Key", MusicGenre.Jazz));
            songs.Add(new Music("harry-potter3", MusicGenre.Pop));
            songs.Add(new Music("harry-potter4", MusicGenre.Pop));
            songs.Add(new Music("Prigione-Eterna", MusicGenre.Rock));
            songs.Add(new Music("Serge-Quadrado", MusicGenre.Rock));

            return songs;
        }
    }
}
