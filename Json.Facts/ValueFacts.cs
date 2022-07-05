using Xunit;

namespace Json.Facts
{
    public class ValueFacts
    {
        [Fact]
        public void MatchIsCalledAndTextEnteredIsNullOrEmptyShouldReturnFalse()
        {
            var value = new Value();

            Assert.False(value.Match(null).Succes());
            Assert.False(value.Match(string.Empty).Succes());
        }

        [Fact]
        public void MatchIsCalledAndTextEnteredIsAValidBooleanReturnsTrue()
        {
            var value = new Value();

            Assert.True(value.Match("true").Succes());
            Assert.True(value.Match("false").Succes());
        }

        [Fact]
        public void MatchIsCalledAndTextEnteredIsAValidNumberReturnsTrue()
        {
            var value = new Value();

            Assert.True(value.Match("123").Succes());
            Assert.True(value.Match("1.23").Succes());
            Assert.True(value.Match("1.2e3").Succes());
        }

        [Fact]
        public void MatchIsCalledAndTextEnteredIsADoubleQuotedString()
        {
            var value = new Value();

            Assert.True(value.Match("\"\"").Succes());
            Assert.True(value.Match("\"abc\"").Succes());
        }

        [Fact]
        public void MatchIsCalledAndTextEnteredIsAValidArrayReturnsTrue()
        {
            var value = new Value();

            Assert.True(value.Match("[ ]").Succes());
            Assert.True(value.Match("[ 1 , 2 , 3 ]").Succes());
        }

        [Fact]
        public void MatchIsCalledAndTextEnteredIsAValidObjectReturnsTrue()
        {
            var value = new Value();

            Assert.True(value.Match("{ }").Succes());
            Assert.True(value.Match("{ \"abc\" : 123 }").Succes());
            Assert.True(value.Match("{ \"abc\" : \"abc\" }").Succes());
            Assert.True(value.Match("{ \"abc\" : true }").Succes());
        }

        /*[Fact]
        public void MatchIsCalledAndTextEnteredIs()
        {
            var value = new Value();

        }*/
    }
}
