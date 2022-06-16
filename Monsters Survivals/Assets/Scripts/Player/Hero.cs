using UnityEngine;

public class Hero : Character
{  
    [SerializeField] private HeroAnimationSwitcher _animationPlayer;
    
    private HeroBehaviour _behaviour;

    public HeroBehaviour Behaviour { get {return _behaviour;}}

    public HeroAnimationSwitcher AnimationPlayer {get {return _animationPlayer;}}

    public override void TakeDamage(uint damage) {

        Stats.HealthPoints -= damage;
        _behaviour.SetBehaviorTakingDamage();
    }

    private void Start() {
        _behaviour = new HeroBehaviour(this);
    }
}
