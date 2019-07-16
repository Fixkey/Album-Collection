using Album_Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album_Collection.DAL
{
    class AlbumsDbService
    {
        private AlbumsDbContext _context = new AlbumsDbContext();

        public List<Album> GetAlbums()
        {
            return _context.Albums.ToList();
        }

        public List<Album> GetAlbums(string searchString)
        {
            return _context.Albums.Where(a => a.Name.Contains(searchString) || 
                                              a.Genre.Name.Contains(searchString) || 
                                              a.Artist.Name.Contains(searchString))
                                              .ToList();
        }

        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public List<Artist> GetArtists()
        {
            return _context.Artists.ToList();
        }

        public int AddAlbum(Album album)
        {
            _context.Albums.Add(album);
            return _context.SaveChanges();
        }
    }
}
