namespace Blitzkrieg.QuestV4.Lib.Models;

public class MapLevel
{

    #region "Constants, Fields and Properties"
    public const int MapColsDefault = 120;
    public const int MapRowsDefault = 40;
    private readonly QuestConfigurationRoot _config;
    private Thing _floor;
    private MapSquare _floorMapSquare;
    private MapSquare[,] _squares { get; set; } = null;

    public MapSquare[,] Squares
    {
        get
        {
            if (_squares == null)
            {
                _squares = new MapSquare[MapRowsDefault, MapColsDefault];
            }
            return _squares;
        }
    }

    public MapSquare FloorMapSquare
    {
        get
        {
            if (_floorMapSquare.Id == 0)
            {
                _floorMapSquare = new MapSquare(this.FloorThing.Id, this.FloorThing.Unicode, false);
            }
            return _floorMapSquare;

        }
    }

    public Thing FloorThing
    {
        get
        {
            if (_floor == null && _config != null)
            {
                _floor = _config.GetThingByName("floor");
            }
            return _floor;
        }
    }
    #endregion

    #region "CTOR"

    /// <summary>
    /// CTOR
    /// </summary>
    /// <param name="config">QuestConfigurationRoot</param>
    public MapLevel(QuestConfigurationRoot config) : base()
    {
        _config = config;
        FloodWithMapSquare(this.FloorMapSquare);
    }

    public MapLevel(QuestConfigurationRoot config, MapSquare square) : base()
    {
        _config = config;
        FloodWithMapSquare(square);
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
        int row = 0;
        while (!sr.EndOfStream && row < MapLevel.MapRowsDefault)
        {
            var line = sr.ReadLine();
            if (line == null) continue;
            var entries = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < entries.Length && col < MapLevel.MapColsDefault; col++)
            {
                if (int.TryParse(entries[col], out int squareId))
                {
                    var sq = _config.GetThingById(squareId);
                    this.Squares[row, col] = new MapSquare
                    {
                        Id = squareId,
                        Unicode = sq != null && (sq.Unicode != 0) ? Convert.ToChar(sq.Unicode) : char.Parse(MapSquare.SPACE),
                        Visible = false
                    };
                }
                else
                {
                    var floor = _config.GetThingByName("floor");
                    this.Squares[row, col] = new MapSquare(floor.Id, floor.Unicode, false);
                }
            }
            row++;
        }
    }

    public void ToFile(string mapFilename)
    {
        if (File.Exists(mapFilename)) File.Delete(mapFilename);

        var floor = _config.GetThingByName("floor");

        using StreamWriter sw = new(mapFilename);
        for (int x = 0; x < MapLevel.MapRowsDefault; x++)
        {
            for (int y = 0; y < MapLevel.MapColsDefault; y++)
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
    /// Flood entire map with MapSquare
    /// </summary>
    /// <param name="t">MapSquare</param>
    public void FloodWithMapSquare(MapSquare t)
    {
        for (int x = 0; x < MapLevel.MapRowsDefault; x++)
        {
            for (int y = 0; y < MapLevel.MapColsDefault; y++)
            {
                Squares[x, y] = t;
            }
        }
    }
    #endregion
}
