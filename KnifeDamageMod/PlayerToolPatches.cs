using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;
using KnifeDamageMod;

namespace Samjocal.KnifeDamageMod
{
    //Harmony Patch Class. Suggested to use one file per patched class.
    [HarmonyPatch(typeof(PlayerTool))]

    internal class PlayerToolPatches
    {
        [HarmonyPatch(nameof(PlayerTool.Awake))]
        [HarmonyPostfix]

        public static void Awake_Postfix(PlayerTool __instance)
        {
            if (__instance is Knife knife)
            {
                KnifeDamagePlugin.Log.LogInfo($"Knife damage is {knife.damage}");
                knife.damage *= 5.0f;
                KnifeDamagePlugin.Log.LogInfo($"Knife damage increased to {knife.damage}");
            }
        }
    }
}
