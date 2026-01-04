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
            MelonLogger.Msg(System.ConsoleColor.DarkGray, "Crafting Bullets...");
            Settings.instance.AddToModSettings("Ammunition Crafting Tools");
        }
    }
}

