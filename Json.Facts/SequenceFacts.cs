using Xunit;

namespace Json.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullOrEmptySuccesShouldReturnFalseAndTextEntered()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));

            Assert.False(ab.Match(null).Succes());
            Assert.False(ab.Match("").Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredMatchesGivenPattersReturnsTrueAndTheRemainingText()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));

            Assert.True(ab.Match("abcd").Succes());
            Assert.True(ab.Match("abcd").RemainingText() == "cd");
        }

        [Fact]
        public void WhenMatchIsCalledAndNotAllPatternsMatchGivenTextReturnsFalseAndTextEntered()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));

            Assert.False(ab.Match("ax").Succes());
            Assert.True(ab.Match("ax").RemainingText() == "ax");
            Assert.False(ab.Match("def").Succes());
            Assert.True(ab.Match("def").RemainingText() == "def");
        }

        [Fact]
        public void WhenMatchIsCalledAndSequenceContainsMorePatternsAndPatternsMatchGivenTextReturnsTrueAndRemainingText()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var abc = new Sequence(ab, new Character('c'));

            Assert.True(abc.Match("abcd").Succes());
            Assert.True(abc.Match("abcd").RemainingText() == "d");
        }

        [Fact]
        public void WhenMatchIsCalledAndSequenceContainsMorePatternsAndNotAllPatternsMatchGivenTextReturnsFalseAndTextEntered()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var abc = new Sequence(ab, new Character('c'));

            Assert.False(abc.Match("def").Succes());
            Assert.True(abc.Match("def").RemainingText() == "def");
            Assert.False(abc.Match("abx").Succes());
            Assert.True(abc.Match("abx").RemainingText() == "abx");
        }

        [Fact]
        public void WhenMatchIsCalledAndPatternsSequenceShouldValidateAHexNumberAndTextEnteredIsValidHexNumberReturnsTrueAndRemainingText()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));

            Assert.True(hexSeq.Match("u1234").Succes());
            Assert.True(hexSeq.Match("u1234").RemainingText() == "");
            Assert.True(hexSeq.Match("uabcdef").Succes());
            Assert.True(hexSeq.Match("uabcdef").RemainingText() == "ef");
            Assert.True(hexSeq.Match("uB005 ab").Succes());
            Assert.True(hexSeq.Match("uB005 ab").RemainingText() == " ab");
        }

        [Fact]
        public void WhenMatchIsCalledAndPatternsSequenceShouldValidateAHexNumberAndTextEnteredIsNotValidHexNumberReturnsFalseAndText()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));

            Assert.False(hexSeq.Match("abc").Succes());
            Assert.True(hexSeq.Match("abc").RemainingText() == "abc");
        }
    }
}
