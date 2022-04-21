using Xunit;


namespace Json.Facts
{
    public class CharacterFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndInputIsNullShoulReturnFalse()
        {
            Character character = new Character('a');

            Assert.False(character.Match(null));
        }

        [Fact]
        public void WhenMatchIsCalledAndInputDoesNotStartWithGivenPatternShouldReturnFalse()
        {
            Character character = new Character('a');

            Assert.False(character.Match("bac"));
            Assert.False(character.Match("b"));
        }

        [Fact]
        public void WhenMatchIsCalledAndInputStartsWithGivenPatternShouldReturnTrue()
        {
            Character character = new Character('a');

            Assert.True(character.Match("a"));
            Assert.True(character.Match("abc"));
        }

        [Fact]
        public void WhenOverloadMatchIsCalledAndInputIsNotInGivenLimitsShouldReturnFalse()
        {
            Character digitOne = new Character('1');
            Character letterA = new Character('a');

            Assert.False(digitOne.Match('2', '9'));
            Assert.False(letterA.Match('b', 'z'));
        }

        [Fact]
        public void WhenOverloadMatchIsCalledAndInputIsInGivenLimitsShouldReturnTrue()
        {
            Character digitOne = new Character('1');
            Character letterA = new Character('a');

            Assert.True(digitOne.Match('1', '9'));
            Assert.True(letterA.Match('a', 'z'));
        }

        [Fact]
        public void WhenMatchUnicodeIsCalledAndInputIsNullShouldReturnFalse()
        {
            Character character = new Character('a');

            Assert.False(character.MatchUnicode(null));
        }

        [Fact]
        public void WhenMatchUnicodeIsCalledAndInputedUnicodeIsValidUnicodeReturnsTrue()
        {
            Character character = new Character('a');

            Assert.True(character.MatchUnicode("\\u1234"));
        }

        /*
        [Fact]
        public void ()
        {

        }*/
    }
}
