using Il2Cpp;
using MelonLoader;
using System;
using Il2CppSystem.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Il2CppTLD.Gear;
using Il2CppNodeCanvas.Tasks.Conditions;
using UnityEngine;
using Il2CppTLD.UI.Scroll;
using Il2CppTLD.Cooking;
using Il2CppNodeCanvas.Tasks.Actions;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using Il2CppRewired.Utils;
using Il2CppRewired.ComponentControls.Data;
using System.Security;

namespace AmmoToolsMod
{


    internal class Patches
    {
        [HarmonyPatch(typeof(Il2CppTLD.Gear.BlueprintManager), nameof(Il2CppTLD.Gear.BlueprintManager.LoadAddressableBlueprints))]
        internal static class BluePrintAdressables
        {
            private static void Postfix(Il2CppTLD.Gear.BlueprintManager __instance)
            {

                foreach (BlueprintData data in __instance.m_AllBlueprints) 
                {
                    if (data.name != "BLUEPRINT_GEAR_Bullet_A") continue;
                    data.m_AppearsInStoryOnly = true;
                }
                foreach (BlueprintData data in __instance.m_AllBlueprints)
                {
                    if (data.name != "BLUEPRINT_GEAR_RifleAmmoSingle_A") continue;
                       data.m_AppearsInStoryOnly = true;
                }
                foreach (BlueprintData data in __instance.m_AllBlueprints)
                {
                    if (data.name != "BLUEPRINT_GEAR_NoiseMaker_A") continue;
                    data.m_AppearsInStoryOnly = true;
                }
                foreach (BlueprintData data in __instance.m_AllBlueprints)
                {
                    if (data.name != "BLUEPRINT_GEAR_RevolverAmmoSingle_A") continue;
                    data.m_AppearsInStoryOnly = true;
                }
                foreach (BlueprintData data in __instance.m_AllBlueprints)
                {
                    if (data.name != "BLUEPRINT_GEAR_GunpowderCan_A") continue;
                    data.m_AppearsInStoryOnly = true;
                }
            }

        }
    }
}


