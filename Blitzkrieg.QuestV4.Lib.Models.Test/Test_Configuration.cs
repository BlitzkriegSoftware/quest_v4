using Blitzkrieg.QuestV4.Lib.Models;

namespace Blitzkrieg.QuestV4.Lib.Configuration.Test;

[TestClass]
public sealed class Test_Configuration
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
    public  void TestInit()
    {
        QuestConfiguration = ConfigurationJsonReader.FromFile(ConfigurationFilename);

    }

    [TestMethod]
    public void IsLoaded()
    {
        Assert.IsNotNull(QuestConfiguration);
    }

    [TestMethod]
    public void HasMonsters()
    {
        Assert.IsTrue(QuestConfiguration.Monsters.Any());
    }

    [TestMethod]
    public void HasPotions()
    {
        Assert.IsTrue(QuestConfiguration.Potions.Any());
    }

    [TestMethod]
    public void HasScrolls()
    {
        Assert.IsTrue(QuestConfiguration.Scrolls.Any());
    }

    [TestMethod]
    public void HasStats()
    {
        Assert.IsTrue(QuestConfiguration.Stats.Any());
    }

    [TestMethod]
    public void HasThings()
    {
        Assert.IsTrue(QuestConfiguration.Things.Any());
    }

    [TestMethod]
    public void Is_Cols_Ok()
    {
        Assert.IsGreaterThan(0, QuestConfiguration.MapInfo.Cols);
    }

    [TestMethod]
    public void Is_Rows_Ok()
    {
        Assert.IsGreaterThan(0, QuestConfiguration.MapInfo.Rows);
    }


    [TestMethod]
    public void Is_MinLevel_Ok()
    {
        Assert.IsGreaterThan(0, QuestConfiguration.MapInfo.MinLevel);
    }


    [TestMethod]
    public void Is_MaxLevel_Ok()
    {
        Assert.IsGreaterThan(0, QuestConfiguration.MapInfo.MaxLevel);
    }

    [TestMethod]
    public void MapInfo_Is_Folders_Ok()
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(QuestConfiguration.MapInfo.Folder));
    }

    [TestMethod]
    public void MapInfo_Is_FolderExt_Ok()
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(QuestConfiguration.MapInfo.FileExt));
    }


    [TestMethod]
    public void SaveGame_Is_Folders_Ok()
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(QuestConfiguration.SaveGameInfo.Folder));
    }

    [TestMethod]
    public void SaveGame_Is_FolderExt_Ok()
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(QuestConfiguration.SaveGameInfo.FileExt));
    }
}
