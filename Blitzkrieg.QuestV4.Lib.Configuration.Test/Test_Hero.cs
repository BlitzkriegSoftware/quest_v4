namespace Blitzkrieg.QuestV4.Lib.Configuration.Test;

[TestClass]
public class Test_Hero
{

    /// <summary>
    /// Test context
    /// </summary>
    public TestContext TestContext { get; set; }

    [TestInitialize]
    public void TestInit()
    {
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
}
