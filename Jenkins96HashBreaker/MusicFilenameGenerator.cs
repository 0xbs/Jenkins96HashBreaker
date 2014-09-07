using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins96HashBreaker
{
    class MusicFilenameGenerator : IFilenameGenerator
    {
        private ulong FilenameCounter = 0;
        private string Prefix = "SOUND\\MUSIC\\DRAENOR\\MUS_60_";
        private string Suffix = ".MP3";
        private String MainPart = "";
        private AlphabetWordGenerator MainPartGen;
        private ListWordGenerator TypePartGen;// = new AlphabetWordGenerator("ABCH", 0, 4);

        public MusicFilenameGenerator(ulong skipFilenames, ulong numFileNames)
        {
            MainPartGen = new AlphabetWordGenerator("ABCDEFGHIJKLMOPQRSTUVWXYZ", skipFilenames, numFileNames);
            MainPart = MainPartGen.NextWord();

            List<string> musicTypeParts = new List<string>();
            musicTypeParts.Add("");
            musicTypeParts.Add("_A");
            musicTypeParts.Add("_H");
            musicTypeParts.Add("_HERO");
            musicTypeParts.Add("_01");
            musicTypeParts.Add("_A_01");
            musicTypeParts.Add("_A_HERO");
            musicTypeParts.Add("_A_HERO_01");
            //musicTypeParts.Add("_A_STINGER_01");
            //musicTypeParts.Add("_NIGHT_01");
            //musicTypeParts.Add("_NIGHT_HERO_01");
            TypePartGen = new ListWordGenerator(musicTypeParts);
        }

        public string NextFilename()
        {
            string TypePart = TypePartGen.NextWord();
            if (TypePart == null)
            {
                MainPart = MainPartGen.NextWord();
                if (MainPart == null)
                    return null;
                TypePartGen.Refresh();
                TypePart = TypePartGen.NextWord();
            }
            FilenameCounter++;
            StringBuilder sb = new StringBuilder();
            sb.Append(Prefix).Append(MainPart).Append(TypePart).Append(Suffix);
            return sb.ToString();
        }

        public ulong FilenameCount() {
            return FilenameCounter;
        }
    }
}
