namespace MainSite.Models
{
    public class OlympicEntry
    {
        public string Country { get; set; }
        public string Game { get; set; }
        public string Sport { get; set; }
        public string Category { get; set; } // Indoor or Outdoor
        public string FlagPath { get; set; } // "/images/flags/canada.png"

        public string GetKey() => $"{Country}|{Game}|{Sport}";
    }

}
