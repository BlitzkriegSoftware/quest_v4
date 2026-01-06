using System.Diagnostics.CodeAnalysis;
using Blitzkrieg.QuestV4.Lib.Models;

namespace Blitzkrieg.QuestV4.Lib.Configuration.Test;

[TestClass]
[ExcludeFromCodeCoverage]
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
    public void TestInit()
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
    public void Stat_ToString()
    {
        var s = QuestConfiguration.Stats[0].ToString();
        TestContext.WriteLine(s);
        Assert.IsFalse(string.IsNullOrWhiteSpace(s));
    }

    [TestMethod]
    public void Stat_List_ToString()
    {
        foreach (var stat in QuestConfiguration.Stats)
        {
            var s = stat.ToString();
            TestContext.WriteLine(s);
            Assert.IsFalse(string.IsNullOrWhiteSpace(s));
        }
    }

    [TestMethod]
    public void HasThings()
    {
        Assert.IsTrue(QuestConfiguration.Things.Any());
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

    [TestMethod]
    public void Monster_ToString()
    {
        var s = QuestConfiguration.Monsters[0].ToString();
        TestContext.WriteLine(s);
        Assert.IsFalse(string.IsNullOrWhiteSpace(s));
    }

    [TestMethod]
    public void Monster_List_ToString()
    {
        foreach (var monster in QuestConfiguration.Monsters)
        {
            var s = monster.ToString();
            TestContext.WriteLine(s);
            Assert.IsFalse(string.IsNullOrWhiteSpace(s));
        }
    }

    [TestMethod]
    public void Potion_ToString()
    {
        var s = QuestConfiguration.Potions[0].ToString();
        TestContext.WriteLine(s);
        Assert.IsFalse(string.IsNullOrWhiteSpace(s));
    }

    [TestMethod]
    public void Potion_List_ToString()
    {
        foreach (var potion in QuestConfiguration.Potions)
        {
            var s = potion.ToString();
            TestContext.WriteLine(s);
            Assert.IsFalse(string.IsNullOrWhiteSpace(s));
        }
    }

    [TestMethod]
    public void Scroll_ToString()
    {
        var s = QuestConfiguration.Scrolls[0].ToString();
        TestContext.WriteLine(s);
        Assert.IsFalse(string.IsNullOrWhiteSpace(s));
    }

    [TestMethod]
    public void Scroll_List_ToString()
    {
        foreach (var scroll in QuestConfiguration.Scrolls)
        {
            var s = scroll.ToString();
            TestContext.WriteLine(s);
            Assert.IsFalse(string.IsNullOrWhiteSpace(s));
        }
    }

    [TestMethod]
    public void Thing_ToString()
    {
        var s = QuestConfiguration.Things[0].ToString();
        TestContext.WriteLine(s);
        Assert.IsFalse(string.IsNullOrWhiteSpace(s));
    }

    [TestMethod]
    public void Things_List__ToString()
    {
        foreach (var thing in QuestConfiguration.Things)
        {
            var s = thing.ToString();
            TestContext.WriteLine(s);
            Assert.IsFalse(string.IsNullOrWhiteSpace(s));
        }
    }

    [TestMethod]
    public void Unicode_List()
    {
        for (int i = 32; i < 9999; i++)
        {
            char u = Convert.ToChar(i);
            TestContext.WriteLine($"{i}, {u}");
        }
    }

    [TestMethod]
    public void Monster_HitPoints()
    {
        var hp = Monster.HitPointsAdjusted(3, 10, 1.1);
        TestContext.WriteLine($"{hp}");
        Assert.IsGreaterThanOrEqualTo(0, hp);
    }


    [TestMethod]
    public void Monster_HitPointsRamp()
    {
        int baseHits = 10;
        for (int level = 1; level <= 20; level++)
        {
            for (double mod = 0.0; mod < 0.5; mod = mod + 0.05)
            {
                var hp = Monster.HitPointsAdjusted(level, baseHits, mod);
                TestContext.WriteLine($"Base: {baseHits}, Level: {level}, Mod: {mod:n2} -> {hp}");
                Assert.IsGreaterThanOrEqualTo(0, hp);
            }
        }

    }

}
