using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGDBDriver;
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
