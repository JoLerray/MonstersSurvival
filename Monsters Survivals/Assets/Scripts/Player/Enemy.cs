using UnityEngine;
using System;

public class Enemy : Character {
    
    public override void TakeDamage(uint damage) {
        
        Stats.HealthPoints -= damage;
        Debug.Log("HealthPoints = " + Stats.HealthPoints);
    }
}
