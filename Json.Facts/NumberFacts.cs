using Xunit;

namespace Json.Facts
{
    public class NumberFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullOrEmptyReturnsFalse()
        {
            var number = new Number();

            Assert.False(number.Match("").Succes());
            Assert.False(number.Match(null).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsAValidNegativeOrPositiveIntegerReturnsTrueAndNoRemainingText()
        {
            var number = new Number();

            Assert.True(number.Match("1").Succes() && number.Match("1").RemainingText() == "");
            Assert.True(number.Match("-0").Succes() && number.Match("-0").RemainingText() == "");
            Assert.True(number.Match("-1").Succes() && number.Match("-1").RemainingText() == "");
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredHasAValidIntegerReturnsTrueAndRemainingText()
        {
            var number = new Number();

            Assert.True(number.Match("12a").Succes() && number.Match("a").RemainingText() == "a");
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNotAValidNumberReturnsFalseAndRemainingText()
        {
            var number = new Number();

            Assert.False(number.Match("a").Succes() && number.Match("a").RemainingText() == "a");
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsANumberThatStartWhitZeroAndItHasOtherDigitsNotSeparedByDotReturnsTrueAndRemainindText()
        {
            var number = new Number();

            Assert.True(number.Match("01").Succes() && number.Match("01").RemainingText() == "1");
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsAValidFractionReturnsTrueAndNoRemainingText()
        {
            var number = new Number();

            Assert.True(number.Match("1.1").Succes() && number.Match("1.1").RemainingText() == "");
            Assert.True(number.Match("1.11111").Succes() && number.Match("1.11111").RemainingText() == "");
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsValidFractionReturnsTrueAndRemainingText()
        {
            var number = new Number();

            Assert.True(number.Match("1.1.1").Succes() && number.Match("1.1.1").RemainingText() == ".1");
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsAValidNumberAndHasExponentReturnsTrueAndNoRemainingText()
        {
            var number = new Number();

            Assert.True(number.Match("1E1").Succes() && number.Match("1E1").RemainingText() == "");
            Assert.True(number.Match("1e1").Succes() && number.Match("1e1").RemainingText() == "");
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsAValidNumberAndHasExponentWithPlusOrMinusReturnsTrueAndNoRemainingText()
        {
            var number = new Number();

            Assert.True(number.Match("1E+1").Succes() && number.Match("1E+1").RemainingText() == "");
            Assert.True(number.Match("1e-1").Succes() && number.Match("1e-1").RemainingText() == "");
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredExponentContainsOtherLettersReturnsTrueAndRemainingText()
        {
            var number = new Number();

            Assert.True(number.Match("1e1a").Succes() && number.Match("1e1a").RemainingText() == "a");
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredHasAInvalidExponentReturnsTrueAndNoRemainingText()
        {
            var number = new Number();

            Assert.True(number.Match("1ea").Succes() && number.Match("1ea").RemainingText() == "ea");
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsAValidNumberWithFractionAndExponentReturnsTrueAndNoRemainingText()
        {
            var number = new Number();

            Assert.True(number.Match("1.1e1").Succes() && number.Match("1.1e1").RemainingText() == "");
            Assert.True(number.Match("-1.1e1").Succes() && number.Match("-1.1e1").RemainingText() == "");
        }


    }
}
