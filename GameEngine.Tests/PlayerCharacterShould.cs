using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "Player")]
    public class PlayerCharacterShould : IDisposable
    {

        private readonly PlayerCharacter sut;

        private readonly ITestOutputHelper output;

        public PlayerCharacterShould(ITestOutputHelper output)
        {
            this.sut = new PlayerCharacter();

            this.output = output;
        }
        public void Dispose()
        {
            output.WriteLine($"Disposing PlayerCharacter {sut.FullName}");

            //sut.Dispose();
        }

        [Fact]
        public void BeInexpiriencedWhenNew()
        {
            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.StartsWith("Sarah", sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.EndsWith("Smith", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            sut.FirstName = "SARAH";
            sut.LastName = "SMITH";

            Assert.Equal("Sarah Smith", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubsringAssertExample()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Contains("ah Sm", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealh()
        {
            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            sut.Sleep(); // Expect increase between 1 to 100 inclusive

            Assert.InRange(sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void NotHaveAStuffOfWonder()
        {
            Assert.DoesNotContain("Staff of Wonder", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new[]
            {
            "Long Bow",
            "Short Bow",
            "Short Sword"
        };

            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        #region 13. Asserting That Events Are Raised

        [Fact]
        public void ReaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }

        #endregion


        [Fact(Skip = "Skipping Test")]
        public void BeNotInexpiriencedWhenNew()
        {
            Assert.False(sut.IsNoob);
        }
    }
}