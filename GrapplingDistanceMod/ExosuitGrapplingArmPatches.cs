using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samjocal.GrapplingDistanceMod;
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
            if (__instance.hook.attached || (__instance.rope && __instance.rope.isHooked))
            {
                return true;
            } 
            else if (__instance.hook.flying)
            {
                if ((__instance.hook.transform.position - __instance.front.position).magnitude < GrapplingDistancePlugin.ModOptions.MaxDistance)
                {
                    GrapplingDistancePlugin.Log.LogInfo($"Hook Distance less than 105f, FixedUpdate method bypassed.");
                    return false;
                }
            }
            GrapplingDistancePlugin.Log.LogInfo($"Hook Distance greater than 500f, FixedUpdate method called.");

            return true;
        }
        
    }
}
