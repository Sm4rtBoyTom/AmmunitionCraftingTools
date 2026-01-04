using UnityEngine;
using Il2Cpp;
using MelonLoader;
using UnityEngine.AddressableAssets;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

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

        public static Il2CppReferenceArray<GearItem> RequiredItemList(GearItem gear_1, GearItem gear_2)
        {
            GearItem[] list = [gear_1, gear_2];
            return list;
        }
        public static Il2CppReferenceArray<ToolsItem> Tools()
        {
            ToolsItem[] list = [Addressables.LoadAssetAsync<GameObject>("GEAR_SharpeningStone").WaitForCompletion().GetComponent<GearItem>().m_ToolsItem];
            return list;
        }
    }
}



