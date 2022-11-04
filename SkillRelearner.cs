namespace SkillRelearner
{
    using BepInEx;
    using HarmonyLib;
    using UnityEngine;

    [BepInPlugin(GUID, NAME, VERSION)]
    public class SkillRelearner : BaseUnityPlugin
    {
        public const string GUID = "com.ehaugw.skillrelearner";
        public const string VERSION = "2.0.0";
        public const string NAME = "Skill Relearner";

        internal void Awake()
        {
            var harmony = new Harmony(GUID);
            harmony.PatchAll();
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(CharacterSkillKnowledge), "AddItem")]
    public class CharacterSkillKnowledge_AddItem
    {
        [HarmonyPostfix]
        public static void Postfix(CharacterSkillKnowledge __instance, ref Item _item)
        {
            if (__instance.transform.GetComponentInParent<Character>() is Character character && character.IsLocalPlayer)
            {
                for (int slotIndex = 0; slotIndex < character.QuickSlotMngr.QuickSlotCount; slotIndex++)
                {
                    QuickSlot slot = character.QuickSlotMngr.GetQuickSlot(slotIndex);
                    if (slot.ItemID == _item.ItemID)
                    {
                        slot.SetQuickSlot(_item);
                    }
                }
            }
        }
    }
}