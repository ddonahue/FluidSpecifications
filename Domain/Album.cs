namespace FluidInterace.Domain
{
    public class Album
    {
        public Album(string artist, string title, int releaseYear, string genre)
        {
            Artist = artist;
            Title = title;
            ReleaseYear = releaseYear;
            Genre = genre;
        }

        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
    }
}