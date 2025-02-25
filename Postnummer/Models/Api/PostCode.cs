using Newtonsoft.Json;

namespace Postnummer.Models.Api
{
    public class PostCode
    {

        public Api api { get; set; }
        public Result[] results { get; set; }
    }

    public class Api
    {
        public string name { get; set; }
        public string url { get; set; }
        public string version { get; set; }
        public string updated { get; set; }
        public string encoding { get; set; }
    }

    public class Result
    {
        [JsonProperty("postal_code")]
        public string Postal_code { get; set; }
        public string city { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string county_code { get; set; }
        public string county { get; set; }
        public string state_code { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string[] maps { get; set; }
        public string note { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
    }
}
