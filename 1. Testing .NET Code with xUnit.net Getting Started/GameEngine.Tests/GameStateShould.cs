using Xunit.Abstractions;

namespace GameEngine.Tests
{

    [Trait("Category", "GameSate")]
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture fixture;
        private readonly ITestOutputHelper output;

        public GameStateShould(GameStateFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.output = output;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            output.WriteLine($"GameState ID={fixture.State.Id}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            fixture.State.Players.Add(player1);
            fixture.State.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            fixture.State.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        }

        [Fact]
        public void Reset()
        {
            output.WriteLine($"GameState ID={fixture.State.Id}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            fixture.State.Players.Add(player1);
            fixture.State.Players.Add(player2);

            fixture.State.Reset();

            Assert.Empty(fixture.State.Players);
        }
    }
}
