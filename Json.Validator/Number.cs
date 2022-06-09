﻿using System;

namespace Json
{
    public class Number : IPattern
    {
        readonly IPattern pattern;

        public Number()
        {
            var plusOrMinus = new Optional(new Any("+-"));
            var digits = new OneOrMore(new Range('0', '9'));

            var integer = new Sequence(plusOrMinus, new Choice(new Character('0'), digits));
            var fraction = new Optional(new Sequence(new Character('.'), digits));
            var exponent = new Optional(new Sequence(new Any("eE"), plusOrMinus, digits));

            this.pattern = new Sequence(integer, fraction, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
