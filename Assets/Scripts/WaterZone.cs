using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class WaterZone : EnvironmentZone
{
    public override void EnterZone(Candle candle, ThirdPersonController player)
    {
        if (!player.IsCoverUp && candle.IsLit)
        {
            candle.Extinguish();
            Debug.Log("The candle was extinguished immediately by water.");
        }
    }

    public override void ExitZone(Candle candle, ThirdPersonController player)
    {
        // В данном случае выход из зоны воды не требует дополнительных действий.
        Debug.Log("Player left the water zone.");
    }
}