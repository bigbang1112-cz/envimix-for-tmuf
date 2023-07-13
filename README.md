# Envimix For TMUF

With this tool, you can generate the same maps but with different TMUF cars. For TM2 envimix, soon.

It is the first Gbx Web Tool to support multiple outputs on a single tool instance.

## Settings

Configuration can be managed on the website in the Config component or inside the `Config` folder.

You can now have multiple configs and change between them.

```yml
MapNameFormat: '{0}.{1}' # {0} is original map name, {1} is the car's modern name
IncludeDesertCar: true
IncludeSnowCar: true
IncludeRallyCar: true
IncludeIslandCar: true
IncludeBayCar: true
IncludeCoastCar: true
IncludeStadiumCar: true
GenerateDefaultCarVariant: false # If to also generate the environment's default car variant
```

## CLI build

For 100% offline control, you can use the CLI version. Drag and drop your desired replays onto the EnvimixForTmufCLI(.exe).

**The installation paths still suggest ManiaPlanet paths, which is an oversight.** This will be possible to control in the future and fixed for this scenario.

### ConsoleOptions.yml

- **NoPause** - If true, All "Press key to continue..." will be skipped.
- **SingleOutput** - If false, dragging multiple files will produce multiple results. If true, multiple files will produce only one result.
- **CustomConfig** - Name of the config inside the `Config` folder without the extension.
- **OutputDir** - Forced output directory of produced results.

### Update notifications

The tool notifies you about new versions after launching it. You can press U to directly open the web page where you can download the new version. Auto-updater might come in the future.

### Specific command line arguments

- `-nopause`
- `-config [ConfigName]`
- `-o [OutputDir]` or `-output [OutputDir]`
- `-c:[AnySettingName] [value]` - Force setting through the command line, **currently works only for string values.**

<h2 align="center">#20yearsoftrackmania</h2>
