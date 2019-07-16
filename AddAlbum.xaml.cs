using Album_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Album_Collection
{
    /// <summary>
    /// Interaction logic for AddAlbum.xaml
    /// </summary>
    public partial class AddAlbum : Window
    {
        private Album newAlbum;

        public AddAlbum(Album newAlbum, ICollection<Artist> artists, ICollection<Genre> genres)
        {
            InitializeComponent();
            ArtistComboBox.ItemsSource = artists;
            GenreComboBox.ItemsSource = genres;
            this.newAlbum = newAlbum;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            Artist artist = (Artist)ArtistComboBox.SelectedItem;
            Genre genre = (Genre)GenreComboBox.SelectedItem;
            DateTime? date = AlbumDataPicker.SelectedDate;

            if (name == "" || name == null || artist == null || genre == null || !date.HasValue)
            {
                MessageBox.Show("Fill in every field.");
            }
            else
            {
                newAlbum.Name = name;
                newAlbum.Artist = artist;
                newAlbum.Genre = genre;
                newAlbum.ReleaseDate = (DateTime)date;
                Close();
            }
        }
    }
}
