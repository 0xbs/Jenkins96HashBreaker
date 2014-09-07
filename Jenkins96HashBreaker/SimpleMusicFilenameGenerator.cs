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
        private ListWordGenerator TypePartGen;

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
            musicNames.Add("MountainsOfNagrand");
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
            musicTypes.Add("");
            musicTypes.Add("_A");
            musicTypes.Add("_B");
            musicTypes.Add("_C");
            musicTypes.Add("_H");
            musicTypes.Add("_01");
            musicTypes.Add("_02");
            musicTypes.Add("_03");
            musicTypes.Add("_04");
            musicTypes.Add("_05");
            musicTypes.Add("_06");
            musicTypes.Add("_07");
            musicTypes.Add("_08");
            musicTypes.Add("_A_01");
            musicTypes.Add("_B_01");
            musicTypes.Add("_C_01");
            musicTypes.Add("_H_01");
            musicTypes.Add("_A_HERO");
            musicTypes.Add("_B_HERO");
            musicTypes.Add("_C_HERO");
            musicTypes.Add("_HERO");
            musicTypes.Add("_A_HERO_01");
            musicTypes.Add("_B_HERO_01");
            musicTypes.Add("_C_HERO_01");
            musicTypes.Add("_HERO_01");
            musicTypes.Add("_A_STINGER_01");
            musicTypes.Add("_NIGHT_01");
            musicTypes.Add("_NIGHT_HERO_01");
            TypePartGen = new ListWordGenerator(musicTypes);
        }

        public string NextFilename()
        {
            string TypePart = TypePartGen.NextWord();
            if (TypePart == null)
            {
                MainPart = MainPartGen.NextWord();
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
