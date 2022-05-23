using Xunit;

namespace Json.Facts
{
    public class AnyFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullOrEmptyReturnsFalse()
        {
            var any = new Any("eE");

            Assert.False(any.Match("").Succes());
            Assert.False(any.Match(null).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredStartsWithACharacterContainedByStringAcceptedReturnsTrueAndRemainingText()
        {
            var anyLetters = new Any("eE");
            var anyCharacters = new Any("+-");

            Assert.True(anyLetters.Match("ea").Succes());
            Assert.Equal("a", anyLetters.Match("ea").RemainingText());
            Assert.True(anyLetters.Match("Ea").Succes());
            Assert.Equal("a", anyLetters.Match("Ea").RemainingText());

            Assert.True(anyCharacters.Match("+2").Succes());
            Assert.Equal("2", anyCharacters.Match("+2").RemainingText());
            Assert.True(anyCharacters.Match("-2").Succes());
            Assert.Equal("2", anyCharacters.Match("-2").RemainingText());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredDoesNotStartWithACharacterContainedByStringAcceptedReturnsFalseAndInitialText()
        {
            var anyLetters = new Any("eE");
            var anyCharacters = new Any("+-");

            Assert.False(anyLetters.Match("a").Succes());
            Assert.Equal("a", anyLetters.Match("a").RemainingText());

            Assert.False(anyCharacters.Match("2").Succes());
            Assert.Equal("a", anyCharacters.Match("2").RemainingText());
        }
    }
}
