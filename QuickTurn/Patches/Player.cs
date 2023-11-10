using HarmonyLib;
using Reptile;

namespace QuickTurn.Patches
{
    internal static class PlayerPatch
    {
        private static NewQuickTurnAbility newQuickTurnAbility;

        [HarmonyPatch(typeof(Player), nameof(Player.Init))]
        [HarmonyPostfix]
        private static void Player_Init_Postfix(Player __instance)
        {
            if (__instance.isAI) { return; }
            else
            {
                QuickTurnPlugin.player = __instance;
                newQuickTurnAbility = new NewQuickTurnAbility(__instance);
            }
        }


        [HarmonyPatch(typeof(Player), nameof(Player.FixedUpdateAbilities))]
        [HarmonyPostfix]
        private static void Player_FixedUpdateAbilities_Postfix(Player __instance)
        {
            if (__instance.isAI) { return; };
            newQuickTurnAbility.PassiveUpdate();
        }
    }
}