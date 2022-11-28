using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        private readonly EnemyFactory sut;

        private readonly ITestOutputHelper output;

        public EnemyFactoryShould(ITestOutputHelper output)
        {
            this.sut = new EnemyFactory();

            this.output = output;
        }

        #region 10. Making Asserts Against Object Types

        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            Enemy enemy = sut.Create("Zombie King", true);

            // Assert and get cast result
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            // Additional asserts on typed object
            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            Enemy enemy = sut.Create("Zombie King", true);

            // Assert.IsType<Enemy>(enemy);

            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        #endregion

        #region 11. Asserting on Object Instances

        [Fact]
        public void CreateSerparateInstances()
        {
            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }

        #endregion

        #region 12. Asserting That Code Throws the Correct Exceptions

        [Fact]
        public void NotAllowNullName()
        {
            //Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyCreationException ex =
                Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }

        #endregion
    }
}
