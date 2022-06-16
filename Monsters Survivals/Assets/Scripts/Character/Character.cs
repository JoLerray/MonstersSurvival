using UnityEngine;
using System;

[RequireComponent (typeof(Stats))]

public abstract class Character : MonoBehaviour
{
    private Stats _stats;

    public Stats Stats {get {return _stats;}}
    
    private void Awake() {

        _stats = GetComponent<Stats>();
    }

    public abstract void TakeDamage(uint damage);
}
