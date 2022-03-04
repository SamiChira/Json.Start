using Xunit;
using static Json.JsonString;

namespace Json.Facts
{
    public class JsonStringFacts
    {
        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            Assert.True(IsJsonString(Quoted("abc")));
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            Assert.False(IsJsonString("abc\""));
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            Assert.False(IsJsonString("\"abc"));
        }

        [Fact]
        public void IsNotNull()
        {
            Assert.False(IsJsonString(null));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Assert.False(IsJsonString(string.Empty));
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            Assert.True(IsJsonString(Quoted(string.Empty)));
        }

        [Fact]
        public void HasStartAndEndQuotes()
        {
            Assert.False(IsJsonString("\""));
        }


        [Fact]
        public void DoesNotContainControlCharacters()
        {
            Assert.False(IsJsonString(Quoted("a\nb\rc")));
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted("⛅⚾")));
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            Assert.True(IsJsonString(Quoted(@"\""a\"" b")));
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            Assert.True(IsJsonString(Quoted(@"a \\ b")));
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            Assert.True(IsJsonString(Quoted(@"a \/ b")));
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            Assert.True(IsJsonString(Quoted(@"a \b b")));
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            Assert.True(IsJsonString(Quoted(@"a \f b")));
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            Assert.True(IsJsonString(Quoted(@"a \n b")));
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            Assert.True(IsJsonString(Quoted(@"a \r b")));
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            Assert.True(IsJsonString(Quoted(@"a \t b")));
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted(@"a \u26Be b")));
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            Assert.False(IsJsonString(Quoted(@"a\x")));
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            Assert.False(IsJsonString(Quoted(@"a\")));
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            Assert.False(IsJsonString(Quoted(@"a\u")));
            Assert.False(IsJsonString(Quoted(@"a\u123")));
        }

        [Fact]
        public void DoesNotContainUnfinishedHexNumber()
        {
            Assert.False(IsJsonString(Quoted(@"a \u1234 sad \u12")));
        }

        [Fact]
        public void DoesNotStartWithAnUnfinishedHexNumber()
        {
            Assert.False(IsJsonString(Quoted(@"\u123 sad")));
        }

        [Fact]
        public void CanContainMultipleValidEscapeControlCharacters()
        {
            Assert.True(IsJsonString(Quoted(@"a \b s \t v \f a \r a \n")));
        }

        [Fact]
        public void CanContainMultipleValiUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted(@"a \u123F s \u1234 v \u1235 a \uf23b ")));
        }

        [Fact]
        public void DoesNotContainUnrecognizedEscapedCharacter()
        {
            Assert.False(IsJsonString(Quoted(@"a \t a \v a \t")));
        }

        [Fact]
        public void CanContainDigits()
        {
            Assert.True(IsJsonString(Quoted("1234")));
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
