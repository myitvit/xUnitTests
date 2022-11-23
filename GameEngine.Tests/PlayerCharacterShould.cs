namespace GameEngine.Tests;

public class PlayerCharacterShould
{
    [Fact]
    public void BeInexpiriencedWhenNew()
    {
        PlayerCharacter sut = new PlayerCharacter();

        Assert.True(sut.IsNoob);
    }
}