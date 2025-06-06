using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using static OVRPlugin;

namespace Samjocal.ReaperCompanionMod
{
    [BepInPlugin(MyGuid, PluginName, VersionString)]
    [BepInDependency("com.snmodding.nautilus")]
    public class ReaperCompanionPlugin : BaseUnityPlugin
    {
        private const string MyGuid = "com.samjocal.reapercompanionmod";
        private const string PluginName = "Reaper Companion Mod";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGuid);

        public static ManualLogSource Log;

        private void Awake()
        {
            Harmony.PatchAll();
            Logger.LogInfo(PluginName + " " + VersionString + " loaded.");
            Log = Logger;
        }
    }
}
