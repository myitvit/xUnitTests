using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Collection("GameState collection")]
    public class TestClass2
    {
        private readonly GameStateFixture gameStateFixture;
        private readonly ITestOutputHelper output;

        public TestClass2(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            this.gameStateFixture = gameStateFixture;

            this.output = output;
        }

        [Fact]
        public void Test3()
        {
            output.WriteLine($"GameState ID={gameStateFixture.State.Id}");
        }

        [Fact]
        public void Test4()
        {
            output.WriteLine($"GameState ID={gameStateFixture.State.Id}");
        }
    }
}
