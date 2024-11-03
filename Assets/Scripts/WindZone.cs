using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;


public class WindZone : EnvironmentZone
{
    private Dictionary<Candle, Coroutine> extinguishCoroutines = new Dictionary<Candle, Coroutine>();


    public override void EnterZone(Candle candle, ThirdPersonController player)
    {
        if (player != null && player.IsCoverUp)
        {
            return;
        }

        if (candle.IsLit)
        {
            
            extinguishCoroutines.Add(candle, StartCoroutine(ExtinguishAfterDelay(candle, player, 1f)));
        }
    }


    public override void ExitZone(Candle candle, ThirdPersonController player)
    {
        if (extinguishCoroutines.ContainsKey(candle))
        {
            StopCoroutine(extinguishCoroutines[candle]);
            extinguishCoroutines.Remove(candle);
            Debug.Log("Extinguish timer reset because player left the wind zone.");
        }
    }

    private IEnumerator ExtinguishAfterDelay(Candle candle, ThirdPersonController player, float delay)
    {
        float time = 0.0f;
        while (time <= delay) {
            yield return null;
            if (player.IsCoverUp) ExitZone(candle, player);
            time += Time.deltaTime;
        }

        if (candle.IsLit)
        {
            candle.Extinguish();
        }
        extinguishCoroutines.Remove(candle);
    }
}

