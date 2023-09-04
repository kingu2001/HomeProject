using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Playlist
    { 
        [Key]
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
