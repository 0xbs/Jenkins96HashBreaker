using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins96HashBreaker
{
    class ListWordGenerator : IWordGenerator
    {
        private ulong LastWord = 0;
        private ulong LastWordFirst = 0;
        private ulong LastWordMax;
        private List<string> Words;

        public ListWordGenerator(List<string> words)
        {
            this.Words = words;
            LastWordMax = Convert.ToUInt64(words.Count) - 1;
        }

        public ListWordGenerator(List<string> words, ulong skipWords, ulong numWords)
        {
            this.Words = words;
            ulong wordsInList = Convert.ToUInt64(words.Count);
            if (skipWords >= wordsInList || skipWords + numWords >= wordsInList)
                throw new ArgumentOutOfRangeException();
            LastWord = skipWords;
            LastWordFirst = skipWords;
            LastWordMax = skipWords + numWords;
        }
        public string NextWord()
        {
            string res = null;
            if (LastWord <= LastWordMax)
                res = Words[Convert.ToInt32(LastWord)];
            LastWord++;
            return res;
        }

        public void Refresh()
        {
            LastWord = LastWordFirst;
        }

        public ulong WordCount()
        {
            return LastWord;
        }
    }
}
