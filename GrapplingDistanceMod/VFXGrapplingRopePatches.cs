using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapplingDistanceMod;
using HarmonyLib;

namespace Samjocal.GrapplingDistanceMod
{
    [HarmonyPatch(typeof(VFXGrapplingRope))]

    internal class VFXGrapplingRopePatches
    {
        [HarmonyPatch(nameof(VFXGrapplingRope.Start))]
        [HarmonyPostfix]
        public static void Start_Postfix(VFXGrapplingRope __instance)
        {
            if(__instance is VFXGrapplingRope grapplingRope)
            {
                grapplingRope.maxDistance = 105f;
                GrapplingDistancePlugin.Log.LogInfo($"Rope maxDistance variable set to {grapplingRope.maxDistance}");
            }

        }
        
        [HarmonyPatch(nameof(VFXGrapplingRope.LaunchHook))]
        [HarmonyPrefix]
        public static bool LaunchHook_Prefix(VFXGrapplingRope __instance, float maxDistance)
        {
            maxDistance = 105f;
            GrapplingDistancePlugin.Log.LogInfo($"LaunchHook Distance Param set to {maxDistance}");
            return true;
        }

    }
}
