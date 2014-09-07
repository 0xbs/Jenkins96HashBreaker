using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Jenkins96HashBreaker
{
    class HashBreakerStartParams
    {
        public bool simple = false;
        public ulong skipFilenames;
        public ulong numFilenames;
        public HashBreakerStartParams()
        {
            this.simple = true;
        }
        public HashBreakerStartParams(ulong skipFilenames, ulong numFilenames)
        {
            this.skipFilenames = skipFilenames;
            this.numFilenames = numFilenames;
        }
    }

    class HashBreaker
    {
        private Jenkins96 Hasher = new Jenkins96();
        private static List<ulong> Hashes;
        private static StreamWriter FoundHashesWriter;

        public HashBreaker(List<ulong> refHashes, StreamWriter refFoundHashesWriter)
        {
            Hashes = refHashes;
            FoundHashesWriter = refFoundHashesWriter;
        }

        public void LoopThroughFilenames(object o)
        {
            HashBreakerStartParams genParams = (HashBreakerStartParams)o;
            IFilenameGenerator gen;
            if (genParams.simple)
                gen = new SimpleMusicFilenameGenerator();
            else
                gen = new MusicFilenameGenerator(genParams.skipFilenames, genParams.numFilenames);
            string word;
            while ((word = gen.NextFilename()) != null)
            {
                if (gen.FilenameCount() % 100000 == 0)
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, word);
                    //Thread.Sleep(1000);
                ulong hash = Hasher.ComputeHash(word);
                if (Hashes.Contains(hash))
                {
                    Console.WriteLine("!!!>>> {0}={1}", hash, word);
                    FoundHashesWriter.WriteLine("{0}={1}", hash, word);
                }
            }
        }
    }
}
