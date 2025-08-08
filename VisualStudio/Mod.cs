using System;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppNodeCanvas.Tasks.Actions;
using Il2CppTLD.Gameplay;
using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;
using ModComponent.API.Components;
using NPOI.SS.Formula.Functions;
using Unity.VisualScripting;
using UnityEngine.Playables;
using static UnityEngine.GridBrushBase;

namespace AmmoToolsMod
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg(System.ConsoleColor.White, "AmmoTools is ON!");
            Settings.instance.AddToModSettings("Ammunition Crafting Tools");
        }
        public static bool SceneLoaded;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (AmmoToolsUtils.IsScenePlayable(sceneName))
            {
                SceneLoaded = true;

                ChangeItemProperties();
            }
        }
        private static void ChangeItemProperties()
        {
            ToolsItem Tool_1;
            ToolsItem[] toolslist_1;

            Tool_1 = GearItem.LoadGearItemPrefab("GEAR_SharpeningStone").m_ToolsItem;

            toolslist_1 = [Tool_1];

            GameObject RevolverBullet = GearItem.LoadGearItemPrefab("GEAR_Bullet").gameObject;
            var rename = RevolverBullet.GetComponent<GearItem>();
            rename.m_DisplayNameOverrideLocID = ".357 Magnum Revolver Bullet";
            rename.m_DescriptionOverrideLocID = "Projectile Component of a .357 Magnum Revolver.";

            GameObject ArrowManufactured = GearItem.LoadGearItemPrefab("GEAR_ArrowManufactured").gameObject;

            if (Settings.instance.sharpenablearrows == true)
            {
            var sharpenable = ArrowManufactured.AddComponent<Sharpenable>();
            sharpenable.m_ConditionIncreaseMax = 5;
            sharpenable.m_ConditionIncreaseMin = 1;
            sharpenable.m_DurationMinutesMax = 20;
            sharpenable.m_DurationMinutesMin = 10;
            sharpenable.m_RequiresToolToSharpen = true;
            sharpenable.m_SharpenToolChoices = toolslist_1;
            sharpenable.m_SharpenAudio = "Play_Sharpening";
            }
            else if (Settings.instance.sharpenablearrows == false)
            {
                GameManager.DestroyImmediate(ArrowManufactured.GetComponent<Repairable>());
            }


            /*      if (Settings.instance.ExperimentalSpawning)
                    {
                        GameObject AmmoBoxRifle = GearItem.LoadGearItemPrefab("GEAR_RifleAmmoBox").gameObject;

                        var SpawnChance = AmmoBoxRifle.GetComponent<GearItem>();

                    SpawnChance.m_RolledSpawnChance = true;
                    SpawnChance.m_SpawnChance = 10;

                    var Stack = AmmoBoxRifle.GetComponent<StackableItem>();

                    Stack.m_DefaultUnitsInItem = 5;
                    Stack.m_Units = 5;

                   }
            */
        }
    }
}

