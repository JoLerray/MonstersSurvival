using UnityEngine;
using System;

public class Enemy : Character {
    
    public override void TakeDamage(uint damage, Action action = null) {
        
        action.Invoke();
        Stats.HealthPoints -= damage;
        Debug.Log("HealthPoints = " + Stats.HealthPoints);
    }
}
