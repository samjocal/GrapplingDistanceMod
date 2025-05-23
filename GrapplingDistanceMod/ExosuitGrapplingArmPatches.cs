using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapplingDistanceMod;
using HarmonyLib;

namespace Samjocal.GrapplingDistanceMod
{
    [HarmonyPatch(typeof(ExosuitGrapplingArm))]
    internal class ExosuitGrapplingArmPatches
    {
        
        [HarmonyPatch(nameof(ExosuitGrapplingArm.FixedUpdate))]
        [HarmonyPrefix]
        public static bool FixedUpdate_Prefix(ExosuitGrapplingArm __instance)
        {
            if(__instance.hook.flying)
            {
                if ((__instance.hook.transform.position - __instance.front.position).magnitude < 105f)
                {
                    GrapplingDistancePlugin.Log.LogInfo($"Hook Distance less than 500f, FixedUpdate method bypassed.");
                    return false;
                }
            }
            GrapplingDistancePlugin.Log.LogInfo($"Hook Distance greater than 500f, FixedUpdate method called.");

            return true;
        }
        
    }
}
