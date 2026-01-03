using System.Diagnostics.CodeAnalysis;

namespace Blitzkrieg.QuestV4.Lib.Models.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class Test_Hero
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
    public void Test_Hero_Ctor()
    {
        var hero = new Hero("Frog");
        Assert.IsNotNull(hero);
        Assert.IsFalse(string.IsNullOrEmpty(hero.PlayerName));
        Assert.IsFalse(string.IsNullOrEmpty(hero.ToString()));
        Assert.IsGreaterThan(0, hero.Level);
        Assert.IsGreaterThan(0, hero.Depth);
        Assert.IsGreaterThan(-1, hero.Deaths);
        Assert.IsGreaterThan(-1, hero.Experience);
        Assert.IsGreaterThan(0, hero.Inventory.Count);
        Assert.IsGreaterThan(0, hero.Stats.Count);
    }

    [TestMethod]
    public void Test_FromSaveGame()
    {
        var h2 = new Hero("x");
        var saveGame = new SaveGameRoot()
        {
            Deaths = 1,
            Depth = 1,
            Experience = 1,
            Inventory = h2.Inventory,
            Level = 1,
            MapFileName = "map.map",
            PlayerName = "hero",
            Stats = h2.Stats,
        };
        var hero = Hero.FromSaveGame(saveGame);
        Assert.IsNotNull(hero);
        Assert.IsTrue(hero.IsValid());
    }

    [TestMethod]
    public void Test_ComputeScore()
    {
        var hero = new Hero("Frog")
        {
            Deaths = 3,
            Experience = 1500
        };
        var (score, log) = hero.ComputeScore();
        Assert.IsTrue(score > 0);
        Assert.IsNotNull(log);
        Assert.IsNotEmpty(log);
        TestContext.WriteLine($"Score: {score}");
        TestContext.WriteLine($"Log: {string.Join("\n", log)}");
    }

    [TestMethod]
    public void Test_IsValid()
    {
        var hero = new Hero("Frog")
        {
            Deaths = 2,
            Experience = 500,
            X = 10,
            Y = 15,
            Depth = 3
        };
        Assert.IsTrue(hero.IsValid());
        Assert.IsTrue(hero.GeoOk());
    }

    [TestMethod]
    public void Test_ComputeHitPoints()
    {
        var hero = new Hero("Frog");
        var hp = hero.ComputeHitPoints();
        Assert.IsGreaterThan(0, hp);
        TestContext.WriteLine($"Hit Points: {hp}");
    }

    [TestMethod]
    public void Test_ComputeMana()
    {
        var hero = new Hero("Frog");
        var mp = hero.ComputeMana();
        Assert.IsGreaterThan(0, mp);
        TestContext.WriteLine($"Magic Points: {mp}");
    }

    [TestMethod]
    public void Test_Damage()
    {
        var hero = new Hero("Frog")
        {
            Deaths = 2,
            Experience = 500,
            X = 10,
            Y = 15,
            Depth = 3
        };
        Assert.IsGreaterThanOrEqualTo(0, hero.Damage);
    }

    [TestMethod]
    public void Test_ManaUsed()
    {
        var hero = new Hero("Frog")
        {
            Deaths = 2,
            Experience = 500,
            X = 10,
            Y = 15,
            Depth = 3
        };
        Assert.IsGreaterThanOrEqualTo(0, hero.ManaUsed);
    }

    [TestMethod]
    public void Test_UsePotion()
    {
        var hero = new Hero("Frog")
        {
            Deaths = 2,
            Experience = 500,
            X = 10,
            Y = 15,
            Depth = 3
        };

        hero.Inventory.Add(new InventoryItem()
        {
            Id = 40,
            Name = "st",
            Quantity = 3
        });

        hero.Inventory.Add(new InventoryItem()
        {
            Id = 40,
            Name = "en",
            Quantity = 3
        });
        hero.Inventory.Add(new InventoryItem()
        {
            Id = 40,
            Name = "iq",
            Quantity = 3
        });

        hero.Damage = 100;
        var msg = hero.DrinkPotion(QuestConfiguration, "heal");
        Assert.AreEqual(90, hero.Damage);
        hero.ManaUsed = 100;
        msg = hero.DrinkPotion(QuestConfiguration, "mana");
        Assert.AreEqual(90, hero.ManaUsed);

        foreach (string key in hero.STAT_LIST)
        {
            msg = hero.DrinkPotion(QuestConfiguration, key);
            Assert.AreEqual(1 + Hero.STAT_INITIAL_VALUE, hero.StatValue(key), key);
        }

        msg = hero.DrinkPotion(QuestConfiguration, "xx");
        Assert.AreEqual(Hero.NOTHING_HAPPENS, msg);
    }

}
