using HarmonyLib;
using LB;
using MelonLoader;

namespace TheLightBrigadeTweaks
{

    [HarmonyPatch(typeof(FogSettings), "Blend")]
    public static class FogSettingsPatch
    {
        static void Postfix(ref FogSettings __result)
        {
            var reduceFogBy = Main.Instance.Settings.GetEntry<int>("Reduce fog by percent").Value;
            var multiplier = (float) ((float)reduceFogBy / 100);

            if (reduceFogBy >= 100)
            {
                __result.enabled = false;
                return;
            }
            
            if (multiplier > 0.2)
            {
                __result.fogDistanceStart = 1f;
            }
            
            __result.fogDistanceStart += (__result.fogDistanceStart * multiplier);
            __result.fogDistanceEnd += (__result.fogDistanceEnd * multiplier);
            __result.directionalFalloff += (__result.directionalFalloff * multiplier);
        }
    }
}
