using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public abstract class EnvironmentZone : MonoBehaviour
{
    public abstract void EnterZone(Candle candle, ThirdPersonController player);
    public abstract void ExitZone(Candle candle, ThirdPersonController player);

    private void OnTriggerEnter(Collider other)
    {
        var candle = other.GetComponent<Candle>();
        if (candle == null) return;
        EnterZone(candle, candle.Player);
    }

    private void OnTriggerExit(Collider other)
    {
        var candle = other.GetComponent<Candle>();
        if (candle == null) return;
        ExitZone(candle, candle.Player);
    }
}
