using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace GrapplingDistanceMod
{
    public class GrapplingDistancePlugin : BaseUnityPlugin
    {
        private const string MyGuid = "com.samjocal.grapplingdistancemod";
        private const string PluginName = "Grappling Distance Mod";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGuid);

        private static ManualLogSource Log;

        private void Awake()
        {
            Harmony.PatchAll();
            Logger.LogInfo(PluginName + " " +  VersionString + " loaded.");
            Log = Logger;
        }
    }
}
