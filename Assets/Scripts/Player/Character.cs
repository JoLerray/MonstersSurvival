using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private Stats _stats;

    public Stats Stats {get {return _stats;}}
    
    private void Start() {

        if(_stats == null)
            throw new ArgumentNullException("Not set Character STATS !");
    }

    public abstract void TakeDamage(uint damage, Action action);
}
