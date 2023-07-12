using GBX.NET.Engines.Game;
using GbxToolAPI;
using TmEssentials;

namespace EnvimixForTmuf;

[ToolName("Envimix for TMUF")]
[ToolDescription("Generates environment mix variants of a TMUF map.")]
[ToolGitHub("bigbang1112-cz/envimix-for-tmuf")]
public class EnvimixForTmufTool : ITool, IHasOutput<IEnumerable<NodeFile<CGameCtnChallenge>>>, IConfigurable<EnvimixForTmufConfig>
{
    private readonly CGameCtnChallenge map;

    private static readonly string[] cars = new[] { "American", "SnowCar", "Rally", "SportCar", "BayCar", "CoastCar", "StadiumCar" };

    public EnvimixForTmufConfig Config { get; set; } = new();

    public EnvimixForTmufTool(CGameCtnChallenge map)
    {
        this.map = map;
    }

    public IEnumerable<NodeFile<CGameCtnChallenge>> Produce()
    {
        if (GameVersion.IsManiaPlanet(map))
        {
            throw new Exception("This tool is only for TMUF maps.");
        }

        var includes = new[]
        {
            Config.IncludeDesertCar, Config.IncludeSnowCar, Config.IncludeRallyCar,
            Config.IncludeIslandCar, Config.IncludeBayCar, Config.IncludeCoastCar,
            Config.IncludeStadiumCar
        };

        var prevPlayerModel = map.PlayerModel;
        var defaultMapName = map.MapName;

        for (int i = 0; i < cars.Length; i++)
        {
            var car = cars[i];
            var include = includes[i];

            if (!include)
            {
                continue;
            }

            if (!Config.GenerateDefaultCarVariant)
            {
                if (map.Collection == "Speed" && car == "American") continue;
                if (map.Collection == "Alpine" && car == "SnowCar") continue;
                if (map.Collection == "Rally" && car == "Rally") continue;
                if (map.Collection == "Island" && car == "SportCar") continue;
                if (map.Collection == "Bay" && car == "BayCar") continue;
                if (map.Collection == "Coast" && car == "CoastCar") continue;
                if (map.Collection == "Stadium" && car == "StadiumCar") continue;
            }

            var modernCar = car switch
            {
                "American" => "DesertCar",
                "Rally" => "RallyCar",
                "SportCar" => "IslandCar",
                _ => car
            };

            map.PlayerModel = (car, "Vehicles", "");
            map.MapName = string.Format(Config.MapNameFormat, defaultMapName, modernCar);

            var pureFileName = $"{TextFormatter.Deformat(map.MapName)}.Challenge.Gbx";
            var validFileName = string.Join("_", pureFileName.Split(Path.GetInvalidFileNameChars()));

            // Each map executes the save method
            yield return new(map, $"Tracks/Envimix/{validFileName}", IsManiaPlanet: false);
        }

        // Return to previous to temporarily fix the mutability issue
        map.PlayerModel = prevPlayerModel;
        map.MapName = defaultMapName;
    }
}
