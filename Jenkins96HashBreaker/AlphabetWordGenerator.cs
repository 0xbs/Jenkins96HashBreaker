using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Jenkins96HashBreaker
{
    class AlphabetWordGenerator: IWordGenerator
    {
        private ulong LastWord = 0;
        private ulong LastWordFirst = 0;
        private ulong LastWordMax = 6278211847988224;
        private string Alphabet = "ABCDEFGHIJKLMOPQRSTUVWXYZ0123456789_-";
        private ulong LetterCount = 38;

        public AlphabetWordGenerator()
        {

        }

        /// <summary>Generate words, i.e. combinations of letters in the alphabet</summary>
        /// <param name="alphabet">A string containing all letter of the alphabet</param>
        /// <param name="skipWords">Skip skipWords words at the beginning</param>
        /// <param name="numWords">Generate numWords words, then return null</param>
        public AlphabetWordGenerator(string alphabet, ulong skipWords, ulong numWords) 
        {
            Alphabet = alphabet;
            LetterCount = Convert.ToUInt64(alphabet.Length);
            LastWord = skipWords;
            LastWordFirst = skipWords;
            LastWordMax = skipWords + numWords;
        }

        /// <summary>Refresh the word generator, i.e. make it behave as it has just been created</summary>
        public void Refresh()
        {
            LastWord = LastWordFirst;
        }

        /// <summary>Get the next word from the word generator or null if all words have been generated</summary>
        public string NextWord()
        {
            string res = null;
            if (LastWord <= LastWordMax)
                res = LongWordToString(LastWord);
            LastWord++;
            return res;
        }

        public string LongWordToString(ulong word)
        {
            StringBuilder sb = new StringBuilder();
            //string res = "";
            ulong mod;
            do
            {
                mod = word % LetterCount;
                word = word / LetterCount;
                sb.Insert(0, LongLetterToString(mod));
                //res = LongLetterToString(mod) + res;
            }
            while (word != 0);
            //return res;
            return sb.ToString();
        }

        public char LongLetterToString(ulong letter)
        {
            return Alphabet[Convert.ToInt32(letter)];
        }

        public ulong WordCount()
        {
            return LastWord;
        }

    }
}
