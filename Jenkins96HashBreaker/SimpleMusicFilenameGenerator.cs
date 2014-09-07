using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins96HashBreaker
{
    class SimpleMusicFilenameGenerator : IFilenameGenerator
    {
        private ulong FilenameCounter = 0;
        private string Prefix = "SOUND\\MUSIC\\DRAENOR\\MUS_60_";
        private string Suffix = ".MP3";
        private String MainPart = "";
        private ListWordGenerator MainPartGen;
        private String TypePart = "";
        private ListWordGenerator TypePartGen;
        private ListWordGenerator TypePartGen2;

        public SimpleMusicFilenameGenerator()
        {
            List<string> musicNames = new List<string>();
            musicNames.Add("WolfAtTheGates");
            musicNames.Add("MountainsOfNagrand");
            musicNames.Add("Mobilize");
            musicNames.Add("Eagle");
            musicNames.Add("CallOfTheWarrior");
            musicNames.Add("Blackrock");
            musicNames.Add("ALightInTheDarkness");
            musicNames.Add("AHerosSacrifice");
            musicNames.Add("WordExpo");
            musicNames.Add("Wonder");
            musicNames.Add("Warsong");
            musicNames.Add("WarriorsJourney");
            musicNames.Add("Village");
            musicNames.Add("Mystic");
            musicNames.Add("EtherealEssence");
            musicNames.Add("EagleOfDraenor");
            musicNames.Add("BFreedom");
            musicNames.Add("Freedom");
            musicNames.Add("ArmyLife");
            musicNames.Add("Voce");
            musicNames.Add("TsHaveIt");
            musicNames.Add("Tome");
            musicNames.Add("StrangeFever");
            musicNames.Add("SpiresOfArak");
            musicNames.Add("Shakedown");
            musicNames.Add("Shadowmoon");
            musicNames.Add("Sacrifice");
            musicNames.Add("PatiencePoint");
            musicNames.Add("PrevalentConfliction");
            musicNames.Add("NightSpires");
            musicNames.Add("Spires");
            musicNames.Add("Nagrand");
            musicNames.Add("ManDown");
            musicNames.Add("MalevolentPrescience");
            musicNames.Add("MalevolentMystique");
            musicNames.Add("LaboriousMisery");
            musicNames.Add("KhadgarsPlan");
            musicNames.Add("IronDawn");
            musicNames.Add("GrommashHellscream");
            musicNames.Add("EtherealEmbers");
            musicNames.Add("SiegeOfWorlds");
            musicNames.Add("Tanaan");
            musicNames.Add("Frostfire");
            musicNames.Add("Highmaul");
            musicNames.Add("Mystique");
            MainPartGen = new ListWordGenerator(musicNames);

            List<string> musicTypes = new List<string>();
            musicTypes.Add("");
            musicTypes.Add("_A");
            musicTypes.Add("_B");
            musicTypes.Add("_C");
            musicTypes.Add("_D");
            musicTypes.Add("_E");
            musicTypes.Add("_F");
            musicTypes.Add("_G");
            musicTypes.Add("_H");
            musicTypes.Add("_A_HERO");
            musicTypes.Add("_B_HERO");
            musicTypes.Add("_C_HERO");
            musicTypes.Add("_HERO");
            musicTypes.Add("_A_STINGER");
            musicTypes.Add("_NIGHT");
            musicTypes.Add("_NIGHT_HERO");
            TypePartGen = new ListWordGenerator(musicTypes);

            List<string> musicTypes2 = new List<string>();
            musicTypes2.Add("");
            musicTypes2.Add("0"); musicTypes2.Add("_0");
            musicTypes2.Add("1"); musicTypes2.Add("_1");
            musicTypes2.Add("2"); musicTypes2.Add("_2");
            musicTypes2.Add("3"); musicTypes2.Add("_3");
            musicTypes2.Add("4"); musicTypes2.Add("_4");
            musicTypes2.Add("5"); musicTypes2.Add("_5");
            musicTypes2.Add("6"); musicTypes2.Add("_6");
            musicTypes2.Add("7"); musicTypes2.Add("_7");
            musicTypes2.Add("8"); musicTypes2.Add("_8");
            musicTypes2.Add("9"); musicTypes2.Add("_9");
            musicTypes2.Add("00"); musicTypes2.Add("_00");
            musicTypes2.Add("01"); musicTypes2.Add("_01");
            musicTypes2.Add("02"); musicTypes2.Add("_02");
            musicTypes2.Add("03"); musicTypes2.Add("_03");
            musicTypes2.Add("04"); musicTypes2.Add("_04");
            musicTypes2.Add("05"); musicTypes2.Add("_05");
            musicTypes2.Add("06"); musicTypes2.Add("_06");
            musicTypes2.Add("07"); musicTypes2.Add("_07");
            musicTypes2.Add("08"); musicTypes2.Add("_08");
            musicTypes2.Add("09"); musicTypes2.Add("_09");
            musicTypes2.Add("10"); musicTypes2.Add("_10");
            TypePartGen2 = new ListWordGenerator(musicTypes2);
        }

        public string NextFilename()
        {
            string TypePart2 = TypePartGen2.NextWord();
            if (TypePart2 == null)
            {
                TypePartGen2.Refresh();
                TypePart2 = TypePartGen2.NextWord();
                TypePart = TypePartGen.NextWord();
                if (TypePart == null)
                {
                    TypePartGen.Refresh();
                    TypePart = TypePartGen.NextWord();
                    MainPart = MainPartGen.NextWord();
                    if (MainPart == null)
                        return null;
                }
            }
            FilenameCounter++;
            StringBuilder sb = new StringBuilder();
            sb.Append(Prefix).Append(MainPart).Append(TypePart).Append(TypePart2).Append(Suffix);
            return sb.ToString();
        }

        public ulong FilenameCount() {
            return FilenameCounter;
        }
    }
}
