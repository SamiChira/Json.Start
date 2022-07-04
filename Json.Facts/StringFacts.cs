using Xunit;

namespace Json.Facts
{
    public class StringFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullOrEmptyNotQuotedReturnsFalse()
        {
            var test = new String();

            Assert.False(test.Match(string.Empty).Succes());
            Assert.False(test.Match(null).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullOrEmptyQuotedReturnsTrue()
        {
            var test = new String();

            Assert.True(test.Match(Quoted(string.Empty)).Succes());
            Assert.True(test.Match(Quoted(null)).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsPartaillyQuotedReturnsFalse()
        {
            var test = new String();

            Assert.False(test.Match("\"abc").Succes());
            Assert.False(test.Match("abc\"").Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsQuotedAndContainsOneOrMoreCharactersReturnsTrue()
        {
            var test = new String();

            Assert.True(test.Match(Quoted("a")).Succes());
            Assert.True(test.Match(Quoted("abc")).Succes());
            Assert.True(test.Match(Quoted("a1")).Succes());
            Assert.True(test.Match(Quoted("a1bT R123 ")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsUnnescapedControlCharactersReturnsFalse()
        {
            var test = new String();

            Assert.False(test.Match(Quoted("a\nb\rc")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsEscapedControlCharactersReturnsTrue()
        {
            var test = new String();

            Assert.True(test.Match(Quoted(@"a\nb\rc")).Succes());
        }

        [Fact]
        public void WhenMatchIsCallledAndTextEnteredContainsLargeUnicodeCharactersReturnsTrue()
        {
            var test = new String();

            Assert.True(test.Match(Quoted("⛅⚾")).Succes());
        }

        [Fact]
        public void WhenMatchIsCallledAndTextEnteredContainsEscapedControlCharactersReturnsTrue()
        {
            var test = new String();

            Assert.True(test.Match(Quoted(@"\""a\"" b")).Succes());
            Assert.True(test.Match(Quoted(@"a \\ b")).Succes());
            Assert.True(test.Match(Quoted(@"a \/ b")).Succes());
            Assert.True(test.Match(Quoted(@"a \b b")).Succes());
            Assert.True(test.Match(Quoted(@"a \f b")).Succes());
            Assert.True(test.Match(Quoted(@"a \n b")).Succes());
            Assert.True(test.Match(Quoted(@"a \r b")).Succes());
            Assert.True(test.Match(Quoted(@"a \t b")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainUnrecognizedEscapceCharactersReturnsFalse()
        {
            var test = new String();

            Assert.False(test.Match(Quoted(@"a\x")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredEndWithReverseSolidusReturnsFalse()
        {
            var test = new String();

            Assert.False(test.Match(Quoted(@"a\")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredEndsWhithAnUnfinishedHexNumber()
        {
            var test = new String();

            Assert.False(test.Match(Quoted(@"a\u")).Succes());
            Assert.False(test.Match(Quoted(@"a\u123")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsUnfinishedHexNumberReturnsFalse()
        {
            var test = new String();

            Assert.False(test.Match(Quoted(@"a \u124 sad \u1234")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredStartsWithAnUnfinishedHexNumberReturnsFalse()
        {
            var test = new String();

            Assert.False(test.Match(Quoted(@"\u123 sad")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsMultipleValidEscapeControlCharactersReturnsTrue()
        {
            var test = new String();

            Assert.True(test.Match(Quoted(@"a\b s\t v \f a \r a \n")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsMultipleValiUnicodeCharactersReturnsTrue()
        {
            var test = new String();

            Assert.True(test.Match(Quoted(@"a \u123F s \u1234 v \u1235 a \uf23b ")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsUnrecognizedEscapedCharacterReturnsFalse()
        {
            var test = new String();

            Assert.False(test.Match(Quoted(@"a \t a \v a \t")).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsDigitsReturnsTrue()
        {
            var test = new String();

            Assert.True(test.Match(Quoted("1234")).Succes());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
