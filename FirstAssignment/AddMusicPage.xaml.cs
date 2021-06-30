using FirstAssignment.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FirstAssignment
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddMusicPage : Page
    {
        private string root = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
        private string genre = string.Empty;
        StorageFile SelectedMusicFile;

        public ObservableCollection<Music> AllMusic;
        public AddMusicPage()
        {
            this.InitializeComponent();
            AllMusic = new ObservableCollection<Music>();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void PickMusicButton_Click(object sender, RoutedEventArgs e)
        {
            genre = GenreText.Text;
            FileOpenPicker fop = new FileOpenPicker();
            fop.ViewMode = PickerViewMode.Thumbnail;
            fop.SuggestedStartLocation = PickerLocationId.Desktop;
            fop.FileTypeFilter.Add(".mp3");
            
            StorageFile file = await fop.PickSingleFileAsync();
            if(file != null)
            {
               // $"/Assets/CoverArt/{genre}/{name}.jpg";
                MusicFileName.Text = file.Name;
                SelectedMusicFile = file;

                // Get the path to the app's Assets folder.

                /* string songFolderpath = root + @"\Assets\SongFiles";
                 StorageFolder localSongFolder = await StorageFolder.GetFolderFromPathAsync(songFolderpath);

                 StorageFile newFile = await file.CopyAsync(localSongFolder,file.Name,NameCollisionOption.ReplaceExisting);

                StorageFolder assets = await Package.Current.InstalledLocation.GetFolderAsync($"Assets/SongFiles/{genre}");
                await file.CopyAsync(assets);*/


                StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                StorageFolder assetsFolder = await appInstalledFolder.GetFolderAsync($"/Assets/SongFiles/{genre}");
                await file.CopyAsync(assetsFolder);

            }
            else
            {
                MusicFileName.Text = "File not picked";
            }
        }

        private async void PickCoverArtButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.ViewMode = PickerViewMode.Thumbnail;
            fop.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            fop.FileTypeFilter.Add(".jpg");

            StorageFile file = await fop.PickSingleFileAsync();
            if (file != null)
            {
                CoverArtName.Text = file.Name;


                // Get the path to the app's Assets CoverArt folder
                /* string coverArtFolderpath = root + @"\Assets\CoverArt";
                 StorageFolder localCoverArtFolder = await StorageFolder.GetFolderFromPathAsync(coverArtFolderpath);

                 StorageFile newFile = await file.CopyAsync(localCoverArtFolder,file.Name,NameCollisionOption.ReplaceExisting);*/

                StorageFolder assets = await Package.Current.InstalledLocation.GetFolderAsync($"Assets/CoverArt/{genre}");
                await file.CopyAsync(assets);
            }
            else
            {
                CoverArtName.Text = "File not picked";
            }

        }

        private void SaveSongButton_Click(object sender, RoutedEventArgs e)
        {
            // if(SelectedMusicFile.IsAvailable)
            var fileName = SelectedMusicFile.DisplayName;
            var genre = GenreText.Text;
            
            var newMusic = new Music(fileName, MusicGenre.Pop);


        }
    }
}
