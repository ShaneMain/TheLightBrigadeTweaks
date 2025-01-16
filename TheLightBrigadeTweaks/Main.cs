using MelonLoader;

namespace TheLightBrigadeTweaks
{
    public class Main : MelonMod
    {
        private static Main _instance;

        public MelonPreferences_Category Settings;
        public MelonPreferences_Entry<int> ReduceFogBy;
        public MelonPreferences_Entry<bool> DisableTrapsAfterClearingLevel;
        public MelonPreferences_Entry<bool> DisableAllVibrations;

        public static Main Instance { get => _instance; set => _instance = value; }

        public override void OnEarlyInitializeMelon()
        {
            Instance = this;
        }

        public override void OnInitializeMelon()
        {
            Settings = MelonPreferences.CreateCategory("Settings");
            ReduceFogBy = Settings.CreateEntry("Reduce fog by percent", 100);
            DisableTrapsAfterClearingLevel = Settings.CreateEntry("Disable traps after clearing level", true);
        }

        public void SavePreferences()
        {
            Settings.SaveToFile();
        }

        public static void Log(string str)
        {
            Instance.LoggerInstance.Msg(str);
        }
    }
}
