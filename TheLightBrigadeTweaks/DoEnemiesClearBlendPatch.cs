using HarmonyLib;
using LB;

namespace TheLightBrigadeTweaks
{
    [HarmonyPatch(typeof(PlayerActor), "DoEnemiesClearBlend")]
    public static class DoEnemiesClearBlendPatch
    {
        static void Postfix(ref PlayerActor __instance)
        {
            if (!Main.Instance.Settings.GetEntry<bool>("Disable traps after clearing level").Value)
            {
                return;
            }
            Main.Instance.LoggerInstance.Msg($"Trap clearing enabled");

            var traps = UnityEngine.Object.FindObjectsOfType<TrapDevice>();

            if (traps.Length <= 0) return;
            foreach (var trap in traps)
            {
                UnityEngine.Object.Destroy(trap);
                trap.gameObject.SetActive(false);
                Main.Instance.LoggerInstance.Msg($"Clearing trap {trap.gameObject.name}");
            }
        }
    }
}
