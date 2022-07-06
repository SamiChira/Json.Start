using Xunit;


namespace Json.Fact
{
    public class CharacterFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndInputIsNullShoulReturnFalse()
        {
            Character character = new Character('a');

            Assert.False(character.Match(null).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndInputDoesNotStartWithGivenPatternShouldReturnFalse()
        {
            Character character = new Character('a');

            Assert.False(character.Match("bac").Succes());
            Assert.False(character.Match("b").Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndInputStartsWithGivenPatternShouldReturnTrue()
        {
            Character character = new Character('a');

            Assert.True(character.Match("a").Succes());
            Assert.True(character.Match("abc").Succes());
        }
    }
}
