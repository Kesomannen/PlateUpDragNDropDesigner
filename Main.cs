﻿using Kitchen;
using KitchenLib;
using KitchenMods;
using System.Reflection;
using Unity.Entities;
using UnityEngine;

namespace KitchenDragNDropDesigner
{
    public class Main : BaseMod
    {
        public const string MOD_GUID = "IcedMilo.PlateUp.DragNDropDesigner";
        public const string MOD_NAME = "Drag N' Drop Designer";
        public const string MOD_VERSION = "0.1.3";
        public const string MOD_AUTHOR = "IcedMilo";
        public const string MOD_GAMEVERSION = ">=1.1.4";

        private readonly HarmonyLib.Harmony m_harmony = new HarmonyLib.Harmony("IcedMilo.PlateUp.Harmony.DragNDropDesigner");

        public Main() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            // For log file output so the official plateup support staff can identify if/which a mod is being used
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");

            World.GetExistingSystem<PickUpAndDropAppliance>().Enabled = false;
            World.GetExistingSystem<RotateAppliances>().Enabled = false;
            World.GetExistingSystem<RotateChairs>().Enabled = false;
        }
        
        protected override void OnUpdate()
        {

        }

        protected override void OnPostActivate(Mod mod)
        {
            m_harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        #region Logging
        // You can remove this, I just prefer a more standardized logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
}
