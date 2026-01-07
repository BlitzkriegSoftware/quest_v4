using System.Diagnostics.CodeAnalysis;


namespace Blitzkrieg.QuestV4.Lib.Models.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class Test_Map
{

    /// <summary>
    /// Test context
    /// </summary>
    public TestContext TestContext { get; set; }

    /// <summary>
    /// File to read
    /// </summary>
    const string ConfigurationFilename = @"./settings.json";

    /// <summary>
    /// QuestConfiguration under test
    /// </summary>
    public QuestConfigurationRoot QuestConfiguration { get; set; } = new QuestConfigurationRoot();

    [TestInitialize]
    public void TestInit()
    {
        QuestConfiguration = ConfigurationJsonReader.FromFile(ConfigurationFilename);
    }

    [TestMethod]
    public void Test_Ctor()
    {
        var ml = new MapLevel(QuestConfiguration);
        Assert.IsNotNull(ml);
    }

    [TestMethod]
    public void Test_FloorThing()
    {
        var ml = new MapLevel(QuestConfiguration);
        var ft = ml.FloorThing;
        Assert.IsNotNull(ft);
        var fmq = ml.FloorMapSquare;
        Assert.IsGreaterThan(0, fmq.Id);
    }

    [TestMethod]
    public void Test_MapLevel_FileRoundTrip()
    {
        string testMapFilename = "./test_map.csv";

        // Arrange
        var floor = QuestConfiguration.GetThingByName("floor");
        var floorSquare = new MapSquare(floor.Id, floor.Unicode, false);
        var mapLevel = new MapLevel(QuestConfiguration, floorSquare);

        // Act
        mapLevel.ToFile(testMapFilename);

        // Assert
        Assert.IsTrue(File.Exists(testMapFilename), "Map file was not created.");

        // Round Trip

        mapLevel.FromFile(testMapFilename);

        // Assert
        for (int x = 0; x < MapLevel.MapRowsDefault; x++)
        {
            for (int y = 0; y < MapLevel.MapColsDefault; y++)
            {
                {
                    Assert.AreEqual(floor.Id, mapLevel.Squares[x, y].Id, $"Map square Id mismatch at ({x},{y}) after round trip.");
                }
            }
        }
    }

    [TestMethod]
    public void Test_MapLevel_FileRoundTrip2()
    {
        string testMapFilename = "./test_map2.csv";

        // Arrange
        var floor = QuestConfiguration.GetThingByName("floor");
        var floorSquare = new MapSquare(floor.Id, floor.Unicode, false);
        var mapLevel = new MapLevel(QuestConfiguration, floorSquare);

        // Act
        mapLevel.ToFile(testMapFilename);

        // Assert
        Assert.IsTrue(File.Exists(testMapFilename), "Map file was not created.");

        // Round Trip

        mapLevel = new MapLevel(QuestConfiguration, testMapFilename);

        // Assert
        for (int x = 0; x < MapLevel.MapRowsDefault; x++)
        {
            for (int y = 0; y < MapLevel.MapColsDefault; y++)
            {
                {
                    Assert.AreEqual(floor.Id, mapLevel.Squares[x, y].Id, $"Map square Id mismatch at ({x},{y}) after round trip.");
                }
            }
        }
    }

    [TestMethod]
    public void Test_MapIlluminateEventArgs()
    {
        var tiea = new MapIlluminateEventArgs(1, 2, 3);
        Assert.AreEqual(1, tiea.X);
        Assert.AreEqual(2, tiea.Y);
        Assert.AreEqual(3, tiea.Radius);
    }


}
