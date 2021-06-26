using FirstAssignment.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FirstAssignment
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> Songs;
        private List<LeftMenuItem> LeftMenuItems;
        public MainPage()
        {

            this.InitializeComponent();
            BackButton.Visibility = Visibility.Collapsed;
            Songs = new ObservableCollection<Music>();
            MusicManager.GetAllSongs(Songs);


        

        LeftMenuItems = new List<LeftMenuItem>
            {
            new LeftMenuItem

            { 
            Genre = MusicGenre.Classical,
            IconFile = "/Assets/Icons/classical.png"
            },
    new LeftMenuItem
        {
        Genre = MusicGenre.Jazz,
        IconFile = "Assets/Icons/jazz.png"
        },
new LeftMenuItem
{
    Genre = MusicGenre.Pop,
    IconFile = "Assets/Icons/pop.png"

},

new LeftMenuItem
{
    Genre = MusicGenre.Rock,
    IconFile= "Assets/Icons/rock.png"
}

};

}



        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
    MusicSplitView.IsPaneOpen = !MusicSplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
    MusicManager.GetAllSongs(Songs);
    BackButton.Visibility = Visibility.Collapsed;
    CategoryTextBlock.Text = "All Music";



        }

        private void MusicGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
    var song = (Music)e.ClickedItem;
    MusicLibraryMediaElement.Source = new Uri(this.BaseUri, song.AudioFile);
        }
private void MenuItemListview_ItemClick(object sender, ItemClickEventArgs e)
{
    var menuItem = (LeftMenuItem) e.ClickedItem;
    MusicManager.GetAllSongsByGenre(Songs, menuItem.Genre);
    BackButton.Visibility = Visibility.Visible;
    CategoryTextBlock.Text = menuItem.Genre.ToString();
    }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            MusicLibraryMediaElement.Stop();
        }

        private void AddSongButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddMusicPage));
        }
    }
}