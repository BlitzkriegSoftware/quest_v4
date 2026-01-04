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
    public void Test_MapLevel_FileRoundTrip()
    {
        string testMapFilename = "./test_map.csv";

        // Arrange
        var mapLevel = new MapLevel(QuestConfiguration);
        var floor = QuestConfiguration.GetThingByName("floor");
        for (int y = 0; y < mapLevel.Height; y++)
        {
            for (int x = 0; x < mapLevel.Width; x++)
            {
                mapLevel.Squares[x, y] = new MapSquare(floor.Id, floor.Unicode[0]);
            }
        }
        // Act
        mapLevel.ToFile(testMapFilename);
        // Assert
        Assert.IsTrue(File.Exists(testMapFilename), "Map file was not created.");

        // ---------

        mapLevel = new MapLevel(QuestConfiguration);
        mapLevel.FromFile(testMapFilename);

        // Assert
        Assert.AreEqual(120, mapLevel.Width, "Map width mismatch after round trip.");
        Assert.AreEqual(40, mapLevel.Height, "Map height mismatch after round trip.");
        for (int y = 0; y < mapLevel.Height; y++)
        {
            for (int x = 0; x < mapLevel.Width; x++)
            {
                Assert.AreEqual(floor.Id, mapLevel.Squares[x, y].Id, $"Map square Id mismatch at ({x},{y}) after round trip.");
            }
        }
    }

}
