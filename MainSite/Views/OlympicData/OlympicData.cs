using MainSite.Models;

namespace MainSite.Views.Olympics
{
    public static class OlympicData
    {
        public static List<OlympicEntry> GetAll() => new List<OlympicEntry>
    {
        new OlympicEntry { Country = "Canada", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagPath = "/images/flags/canada.png" },
        new OlympicEntry { Country = "Sweden", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagPath = "/images/flags/sweden.png" },
        new OlympicEntry { Country = "Great Britain", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagPath = "/images/flags/britain.png" },
        new OlympicEntry { Country = "Jamaica", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagPath = "/images/flags/jamaica.png" },
        new OlympicEntry { Country = "Italy", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagPath = "/images/flags/italy.png" },
        new OlympicEntry { Country = "Japan", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagPath = "/images/flags/japan.png" },
        new OlympicEntry { Country = "Germany", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagPath = "/images/flags/germany.png" },
        new OlympicEntry { Country = "China", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagPath = "/images/flags/china.png" },
        new OlympicEntry { Country = "Mexico", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagPath = "/images/flags/mexico.png" },
        new OlympicEntry { Country = "Brazil", Game = "Summer Olympics", Sport = "Road Cycling", Category = "Outdoor", FlagPath = "/images/flags/brazil.png" },
        new OlympicEntry { Country = "Netherlands", Game = "Summer Olympics", Sport = "Cycling", Category = "Outdoor", FlagPath = "/images/flags/netherlands.png" },
        new OlympicEntry { Country = "USA", Game = "Summer Olympics", Sport = "Road Cycling", Category = "Outdoor", FlagPath = "/images/flags/usa.png" },
        new OlympicEntry { Country = "Thailand", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagPath = "/images/flags/thailand.png" },
        new OlympicEntry { Country = "Uruguay", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagPath = "/images/flags/uruguay.png" },
        new OlympicEntry { Country = "Ukraine", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagPath = "/images/flags/ukraine.png" },
        new OlympicEntry { Country = "Austria", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagPath = "/images/flags/austria.png" },
        new OlympicEntry { Country = "Pakistan", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagPath = "/images/flags/pakistan.png" },
        new OlympicEntry { Country = "Zimbabwe", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagPath = "/images/flags/zimbabwe.png" },
        new OlympicEntry { Country = "France", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagPath = "/images/flags/france.png" },
        new OlympicEntry { Country = "Cyprus", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagPath = "/images/flags/cyprus.png" },
        new OlympicEntry { Country = "Russia", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagPath = "/images/flags/russia.png" },
        new OlympicEntry { Country = "Finland", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagPath = "/images/flags/finland.png" },
        new OlympicEntry { Country = "Slovakia", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagPath = "/images/flags/slovakia.png" },
        new OlympicEntry { Country = "Portugal", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagPath = "/images/flags/portugal.png" },
        // Add more entries here
    };

        public static List<OlympicEntry> Filter(string game, string category)
        {
            var all = GetAll();
            if (game != "ALL") all = all.Where(e => e.Game == game).ToList();
            if (category != "ALL") all = all.Where(e => e.Category == category).ToList();
            return all;
        }
    }
}
