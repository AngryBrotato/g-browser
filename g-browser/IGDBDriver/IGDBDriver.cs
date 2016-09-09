using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;

namespace IGDB
{
    public class IGDBDriver
    {
        private string _apiKey = "Sz4FiniJAmmshgXs5kzoARTpd2Fqp1vkdILjsnHzHnccLGYHS2";
        private string _baseUrl = "https://igdbcom-internet-game-database-v1.p.mashape.com/";
        private string _defaultFields = "*";
        Task<HttpResponse<GamesResponse>> response;
    }

    public class GamesResponse
    {
        public GamesResponse(
            int id,
            string name,
            string slug,
            string url, 
            long createdTime,
            long updatedTime,
            long firstReleaseDate,
            List<ReleaseDate> releaseDates,
            string summary,
            string storyline,
            int collectionNumber,
            int hypes,
            List<int> developers,
            List<int> publishers,
            int category,
            List<int> gameModes,
            List<int> keywords,
            List<int> themes,
            List<int> genres,
            List<Name> alternativeNames, 
            List<Screenshot> screenshots
            )
        {
            this.Id = id;
            this.Name = name;
            this.Slug = slug;
            this.Url = url;
            this.CreatedTime = createdTime;
            this.UpdatedTime = updatedTime;
            this.FirstReleaseDate = firstReleaseDate;
            this.ReleaseDates = releaseDates;
            this.Summary = summary;
            this.Storyline = storyline;
            this.CollectionNumber = collectionNumber;
            this.Hypes = hypes;
            this.Developers = developers;
            this.Publishers = publishers;
            this.Category = category;
            this.GameModes = gameModes;
            this.Keywords = keywords;
            this.Themes = themes;
            this.Genres = genres;
            this.AlternativeNames = alternativeNames;
            this.Screenshots = screenshots;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Url { get; set; }
        public long CreatedTime { get; set; }
        public long UpdatedTime { get; set; }
        public long FirstReleaseDate { get; set; }
        public List<ReleaseDate> ReleaseDates { get; set; }
        public string Summary { get; set; }
        public string Storyline { get; set; }
        public int CollectionNumber { get; set; }
        public int Hypes { get; set; }
        public List<int> Developers { get; set; }
        public List<int> Publishers { get; set; }
        public int Category { get; set; }
        public List<int> GameModes { get; set; }
        public List<int> Keywords { get; set; }
        public List<int> Themes { get; set; }
        public List<int> Genres { get; set; }
        public List<Name> AlternativeNames { get; set; }
        public List<Screenshot> Screenshots { get; set; }
    }

    public class Video
    {
        public Video(string name, string videoId)
        {
            this.Name = name;
            this.VideoId = videoId;
        }

        public string Name { get; set; }
        public string VideoId { get; set; }
    }

    public class Screenshot
    {
        public Screenshot(string cloudinaryId, int width, int height)
        {
            this.CloudinaryId = cloudinaryId;
            this.Width = width;
            this.Height = height;
        }

        public string CloudinaryId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Name
    {
        public Name(string value)
        {
            this.Value = value;
        }
        public string Value { get; set; }
    }
    public class ReleaseDate
    {
        public ReleaseDate(long date, int category, int platform, int region)
        {
            this.Date = date;
            this.Category = category;
            this.Platform = platform;
            this.Region = region;
        }

        public long Date { get; set; }
        public int Category { get; set; }
        public int Platform { get; set; }
        public int Region { get; set; }
    }

    public enum Endpoints
    {
        [Description("companies")]
        Companies,
        [Description("franchises")]
        Franchises,
        [Description("game_modes")]
        GameModes,
        [Description("games")]
        Games,
        [Description("genres")]
        Genres,
        [Description("keywords")]
        Keywords,
        [Description("people")]
        People,
        [Description("platforms")]
        Platforms,
        [Description("player_perspectives")]
        PlayerPerspectives,
        [Description("pulses")]
        Pulse,
        [Description("collections")]
        Collections,
        [Description("themes")]
        Themes
    }
}
