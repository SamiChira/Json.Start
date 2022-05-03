﻿using Xunit;


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
    }
}