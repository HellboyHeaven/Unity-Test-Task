using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

[RequireComponent(typeof(Collider))]
public class Candle : MonoBehaviour
{
    public bool IsLit { get; private set; } = true;
    [SerializeField] private Light light;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private ThirdPersonController player;
    private Collider _collider;
    private bool _wasCoverUp;

    public ThirdPersonController Player => player;

    private void Start() {
        _collider = GetComponent<Collider>();
    }

    private void Update() {
        _collider.enabled = !player.IsCoverUp;
        // if (player.IsCoverUp && _wasCoverUp == false)
        // {
        //     _collider.enabled = false;
        //     _collider.enabled = true;
        //     _wasCoverUp = true;
        // }
        // _wasCoverUp = player.IsCoverUp;
       
    }

    public void Extinguish()
    {
        if (IsLit)
        {
            IsLit = false;
            light.enabled = false;
            particle.Stop();
            Debug.Log("The candle has been extinguished.");
        }
    }

    public void Relight()
    {
        IsLit = true;
        light.enabled = true;
        particle.Play();
        Debug.Log("The candle is lit again.");
    }
}
