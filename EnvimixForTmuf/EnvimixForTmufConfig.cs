using GbxToolAPI;

namespace EnvimixForTmuf;

public class EnvimixForTmufConfig : Config
{
    public string MapNameFormat { get; set; } = "{0}.{1}";
    public bool IncludeDesertCar { get; set; } = true;
    public bool IncludeSnowCar { get; set; } = true;
    public bool IncludeRallyCar { get; set; } = true;
    public bool IncludeIslandCar { get; set; } = true;
    public bool IncludeBayCar { get; set; } = true;
    public bool IncludeCoastCar { get; set; } = true;
    public bool IncludeStadiumCar { get; set; } = true;
    public bool GenerateDefaultCarVariant { get; set; }
}