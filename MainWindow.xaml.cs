using Album_Collection.DAL;
using Album_Collection.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Album_Collection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AlbumsDbService _service;

        ObservableCollection<Album> AlbumsObservableCollection = new ObservableCollection<Album>();

        public MainWindow()
        {
            InitializeComponent();
            AddDbService();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            AlbumDataGrid.ItemsSource = AlbumsObservableCollection;
            AlbumsObservableCollection.Clear();
            foreach (Album album in _service.GetAlbums())
            {
                AlbumsObservableCollection.Add(album);
            }
        }

        private void FillDataGrid(string searchString)
        {
            AlbumsObservableCollection.Clear();
            foreach (Album album in _service.GetAlbums(searchString))
            {
                AlbumsObservableCollection.Add(album);
            }
        }

        private void AddDbService()
        {
            try
            {
                _service = new AlbumsDbService();
            }
            catch (Exception e) // not the best idea
            {
                MessageBox.Show("Can't connect to database");
                Close();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid(SearchTextBox.Text);
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
            SearchTextBox.Clear();
        }

        private void NewAlbum_Click(object sender, RoutedEventArgs e)
        {
            Album newAlbum = new Album();
            var addAlbum = new AddAlbum(newAlbum, _service.GetArtists(), _service.GetGenres());
            addAlbum.ShowDialog();
            if (newAlbum.Artist==null || newAlbum.Genre==null || newAlbum.Name==null)
            {
                return;
            }
            if (_service.AddAlbum(newAlbum) == 1)
            {
                AlbumsObservableCollection.Add(newAlbum);
            }
        }
    }
}
