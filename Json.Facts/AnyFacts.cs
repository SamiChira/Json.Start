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
        public void WhenMatchIsCalledAndTextEnteredStartsWithACharacterContainedByStringAcceptedReturnsTrue()
        {
            var anyLetters = new Any("eE");
            var anyCharacters = new Any("+-");

            Assert.True(anyLetters.Match("ea").Succes());
            Assert.True(anyLetters.Match("Ea").Succes());
        }
    }
}
