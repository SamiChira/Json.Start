using Xunit;

namespace Json.Facts
{
    public class ManyFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullOrEmptyReturnsTrue()
        {
            var many = new Many(new Character('a'));

            Assert.True(many.Match("").Succes());
            Assert.True(many.Match(null).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNotNullOrEmptyIfPatternMatchesTextOrNotReturnsTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));
            var digits = new Many(new Range('0', '9'));

            Assert.True(a.Match("abc").Succes() && a.Match("abc").RemainingText() == "bc");
            Assert.True(a.Match("aaaabc").Succes() && a.Match("aaaabc").RemainingText() == "bc");
            Assert.True(a.Match("bc").Succes() && a.Match("bc").RemainingText() == "bc");
            Assert.True(digits.Match("123").Succes() && digits.Match("123").RemainingText() == "");
            Assert.True(digits.Match("12345ab123").Succes() && digits.Match("12345ab123").RemainingText() == "ab123");
            Assert.True(digits.Match("ab").Succes() && digits.Match("ab").RemainingText() == "ab");


        }
    }
}
