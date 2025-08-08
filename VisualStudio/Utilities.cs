using UnityEngine;
using Il2Cpp;
using MelonLoader;
using UnityEngine.AddressableAssets;

namespace AmmoToolsMod
{
    internal static class AmmoToolsUtils
    {

        public static bool IsScenePlayable(string scene)
        {
            return !(string.IsNullOrEmpty(scene) || scene.Contains("MainMenu") || scene == "Boot" || scene == "Empty");
        }

        public static GameObject Sulfur = Addressables.LoadAssetAsync<GameObject>("GEAR_Sulfur").WaitForCompletion();

        public static GameObject Niter = Addressables.LoadAssetAsync<GameObject>("GEAR_Niter").WaitForCompletion();
    }
}



