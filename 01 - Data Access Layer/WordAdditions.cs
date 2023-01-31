using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public partial class Word
    {
        public override bool Equals(object? obj)
        {
            return obj is Word word &&
                   WordValue == word.WordValue &&
                   WordLength == word.WordLength;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(WordValue, WordLength);
        }

    }
}
