using Microsoft.EntityFrameworkCore;
using MusicStore.Models;
using System.Data.Common;

namespace MusicStore.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options) 
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<SongPlaylist> SongPlaylists { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
