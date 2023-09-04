namespace MusicStore.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public Artist Artist{ get; set; }
        public Genre Genre { get; set; }
        public Album Album { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
    }
}
