using System.Data.SqlTypes;

namespace Blitzkrieg.QuestV4.Lib.Models;

public class MapLevel
{

    #region "Constants, Fields and Properties"
    private const int MapColsDefault = 120;
    private const int MapRowsDefault = 40;
    private readonly QuestConfigurationRoot _config;
    private  Thing _floor;

    public Thing Floor
    {
        get
        {
            if(_floor == null && _config != null)
            {
                _floor = _config.GetThingByName("floor");
            }
            return _floor;
        }
    }
    #endregion

    #region "CTOR"
    public MapLevel()
    {
        this.Width = MapColsDefault;
        this.Height = MapRowsDefault;
        this.Squares = new MapSquare[MapColsDefault, MapRowsDefault];
    }

    /// <summary>
    /// CTOR
    /// </summary>
    /// <param name="config">QuestConfigurationRoot</param>
    public MapLevel(QuestConfigurationRoot config) : base()
    {
        _config = config;
        FloodWithThing(this.Floor);
    }

    public MapLevel(QuestConfigurationRoot config, MapSquare square) : base()
    {
        _config = config;

    }

    /// <summary>
    /// Creates a MapLevel from a map file.
    /// </summary>
    /// <param name="config"></param>
    /// <param name="mapFilename"></param>
    public MapLevel(QuestConfigurationRoot config, string mapFilename)
    {
        _config = config;
        FromFile(mapFilename);
    }

    public void FromFile(string mapFilename)
    {
        if (!File.Exists(mapFilename)) throw new FileNotFoundException($"Map file '{mapFilename}' not found.");

        using var sr = new StreamReader(mapFilename);
        int y = 0;
        while (!sr.EndOfStream && y < this.Height)
        {
            var line = sr.ReadLine();
            if (line == null) continue;
            var entries = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            for (int x = 0; x < entries.Length && x < this.Width; x++)
            {
                if (int.TryParse(entries[x], out int squareId))
                {
                    var sq = _config.GetThingById(squareId);
                    this.Squares[x, y] = new MapSquare
                    {
                        Id = squareId,
                        Unicode = sq != null && !string.IsNullOrEmpty(sq.Unicode) ? sq.Unicode[0] : ' ',
                        Visible = false
                    };
                }
                else
                {
                    var floor = _config.GetThingByName("floor");
                    this.Squares[x, y] = new MapSquare
                    {
                        Id = floor.Id,
                        Unicode = floor.Unicode[0],
                        Visible = false
                    };
                }
            }
            y++;
        }
    }

    public void ToFile(string mapFilename)
    {
        if (File.Exists(mapFilename)) File.Delete(mapFilename);

        var floor = _config.GetThingByName("floor");

        using StreamWriter sw = new(mapFilename);
        for (int y = 0; y < this.Height; y++)
        {
            for (int x = 0; x < this.Width; x++)
            {
                MapSquare square = this.Squares[x, y];
                if (square.Id >= 0 && square.Id <= 30)
                {
                    sw.Write(square.Id);
                }
                else
                {
                    sw.Write(floor.Id);
                }
                sw.Write(",");
            }
            sw.WriteLine();
        }
    }

    #endregion

    #region "Fields"
    public int Width { get; set; } = MapColsDefault;
    public int Height { get; set; } = MapRowsDefault;
    public MapSquare[,] Squares { get; set; } = new MapSquare[MapColsDefault, MapRowsDefault];
    #endregion

    #region "Delegates and Events"
    public delegate void MapLevelIlluminateEventHandler(object sender, MapIlluminateEventArgs e);

    public event EventHandler<MapIlluminateEventArgs> IlluminateMap;

    protected virtual void OnThresholdReached(MapIlluminateEventArgs e)
    {
        IlluminateMap?.Invoke(this, e);
    }

    #endregion

    #region "Methods"
    /// <summary>
    /// Flood entire map with Thing
    /// </summary>
    /// <param name="t">Thing</param>
    public void FloodWithThing(Thing t)
    {
        for (int y = 0; y < this.Height; y++)
        {
            for (int x = 0; x < this.Width; x++)
            {
                Squares[x, y] = new MapSquare(t.Id, t.Unicode);
            }
        }
    }
    #endregion
}
