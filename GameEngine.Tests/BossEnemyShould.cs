namespace GameEngine.Tests
{
    [Trait("Category", "BossEnemy")]
    public class BossEnemyShould
    {

        [Fact]
        public void HaveCorrectPower()
        {
            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
    }
}
