using System.Diagnostics.CodeAnalysis;

using Blitzkrieg.QuestV4.Lib.Models;

namespace Blitzkrieg.QuestV4.Lib.Configuration.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class Test_Save_Game
{
    /// <summary>
    /// Test context
    /// </summary>
    public TestContext TestContext { get; set; }

    /// <summary>
    /// File to read
    /// </summary>
    const string SaveFilename = @"./test_save_game.json";

    /// <summary>
    /// SaveGame under test
    /// </summary>
    public SaveGameRoot SaveGame { get; set; } = new SaveGameRoot();

    [TestInitialize]
    public void TestInit()
    {
        SaveGame = SaveGameJsonIO.FromFile(SaveFilename);
    }


    [TestMethod]
    public void IsLoaded()
    {
        Assert.IsNotNull(SaveGame);
    }

    [TestMethod]
    public void Experience_OK()
    {
        Assert.IsGreaterThan(0, SaveGame.Experience); 
    }

    [TestMethod]
    public void Level_OK()
    {
        Assert.IsGreaterThan(0, SaveGame.Level);
    }

    [TestMethod]
    public void Deaths_OK()
    {
        Assert.IsGreaterThan(0, SaveGame.Deaths);
    }

    [TestMethod]
    public void Depth_OK()
    {
        Assert.IsGreaterThan(0, SaveGame.Depth);
    }

    [TestMethod]
    public void MapFileName_OK()
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(SaveGame.MapFileName));
    }
    [TestMethod]
    public void Stats_OK()
    {
       Assert.HasCount(3, SaveGame.Stats);
        foreach(var stat in SaveGame.Stats)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(stat.Key));
            Assert.IsGreaterThan(0, stat.Value);
        }
    }
    [TestMethod]
    public void Inventory_OK()
    {
        Assert.HasCount(4, SaveGame.Inventory);
        foreach(var item in SaveGame.Inventory)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(item.Name));
            Assert.IsGreaterThan(0, item.Quantity);
            Assert.IsGreaterThan(0, item.Id);
        }
    }

    [TestMethod]
    public void SaveGame_ToString()
    {
        var s = SaveGame.ToString();
        TestContext.WriteLine(s);
        Assert.IsFalse(string.IsNullOrWhiteSpace(s));
    }

    [TestMethod]
    public void SaveGame_IsValid()
    {
        Assert.IsTrue(SaveGame.IsValid());
    }

    [TestMethod]
    public void SaveGame_RoundTrip()
    {
        // Save to temp file
        string tempFilename = Path.GetTempFileName();
        SaveGameJsonIO.ToFile(tempFilename, SaveGame);
        // Read back
        var loadedSaveGame = SaveGameJsonIO.FromFile(tempFilename);
        // Compare
        Assert.AreEqual(SaveGame.PlayerName, loadedSaveGame.PlayerName);
        Assert.AreEqual(SaveGame.Level, loadedSaveGame.Level);
        Assert.AreEqual(SaveGame.Experience, loadedSaveGame.Experience);
        Assert.AreEqual(SaveGame.MapFileName, loadedSaveGame.MapFileName);
        Assert.HasCount(SaveGame.Stats.Count, loadedSaveGame.Stats);
        Assert.HasCount(SaveGame.Inventory.Count, loadedSaveGame.Inventory);
        // Clean up
        File.Delete(tempFilename);
    }

}


