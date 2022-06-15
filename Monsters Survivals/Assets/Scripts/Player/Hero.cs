using UnityEngine;
using System;

public class Hero : Character
{  
    [SerializeField] private HeroAnimationSwicher _animationPlayer;
    
    public HeroAnimationSwicher AnimationPlayer {get {return _animationPlayer;}}

    public override void TakeDamage(uint damage,Action action = null) {

        Stats.HealthPoints -= damage;
        action.Invoke();
    }
}
