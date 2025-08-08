using UnityEngine;
using Il2Cpp;
using MelonLoader;
using AmmoToolsMod;
using Il2CppAmazingAssets.TerrainToMesh;

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
}
