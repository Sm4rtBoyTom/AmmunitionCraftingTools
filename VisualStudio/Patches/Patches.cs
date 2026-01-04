using UnityEngine;
using Il2Cpp;
using MelonLoader;
using AmmoToolsMod;
using Il2CppAmazingAssets.TerrainToMesh;
using Unity.VisualScripting;

namespace AmmoToolsMod
{
    //Patches RadialObjectSpawner to spawn Sulfur.

    [HarmonyPatch(typeof(RadialObjectSpawner), "GetNextPrefabToSpawn")]
    internal class BirchSpawns
    {
        private static void Postfix(RadialObjectSpawner __instance, ref GameObject __result)
        {

            if (__instance != null && __instance.name.Contains("RadialSpawn_coal") && AmmoToolsUtils.Sulfur != null)
            {
                if (Utils.RollChance(Settings.instance.SulfurChance))
                {
                    __result = AmmoToolsUtils.Sulfur;
                }
            }
        }
    }
    //Patches RadialObjectSpawner to spawn Niter.

    [HarmonyPatch(typeof(RadialObjectSpawner), "GetNextPrefabToSpawn")]
    internal class OakSpawns
    {
        private static void Postfix(RadialObjectSpawner __instance, ref GameObject __result)
        {

            if (__instance != null && __instance.name.Contains("RadialSpawn_coal") && AmmoToolsUtils.Niter != null)
            {
                if (Utils.RollChance(Settings.instance.NiterChance))
                {
                    __result = AmmoToolsUtils.Niter;
                }
            }
        }
    }
    [HarmonyPatch(typeof(GearItem), "Awake")]
    public class RevolverBulletRename
    {
        internal static void Postfix( ref GearItem __instance)
        {
            if (__instance != null)
            {
                if (__instance.name.Contains("GEAR_Bullet"))
                {
                    __instance.GetComponent<GearItem>();
                    __instance.m_DisplayNameOverrideLocID = ".357 Magnum Revolver Bullet";
                    __instance.m_DescriptionOverrideLocID = "Projectile Component of a .357 Magnum Revolver.";
                }
            }
        }
    }
    [HarmonyPatch(typeof(GearItem), "Awake")]
    public class SharpenableArrow
    {
        internal static void Postfix(ref GearItem __instance)
        {
            if (__instance != null)
            {
                if (__instance.name.Contains("GEAR_ArrowManufactured"))
                {
                    if (Settings.instance.sharpenablearrows == true)
                    {
                        Sharpenable s = __instance.gameObject.AddComponent<Sharpenable>();
                        __instance.m_Sharpenable = s;
                        s.m_ConditionIncreaseMax = 5;
                        s.m_ConditionIncreaseMin = 1;
                        s.m_DurationMinutesMax = 20;
                        s.m_DurationMinutesMin = 10;
                        s.m_RequiresToolToSharpen = true;
                        s.m_SharpenToolChoices = AmmoToolsUtils.Tools();
                        s.m_SharpenAudio = "Play_Sharpening";
                    }
                }
            }
        }
    }
}
