using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "BossEnemy")]
    public class BossEnemyShould
    {
        private readonly ITestOutputHelper _output;

        private readonly BossEnemy sut;

        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output;

            sut = new BossEnemy();
        }

        #region 07. Asserting on Floating Point Values

        [Fact]
        public void HaveCorrectPower()
        {
            _output.WriteLine("Creating Boss Enemy");

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }

        #endregion
    }
}
